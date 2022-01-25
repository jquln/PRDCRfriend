using PRDCRfriend.Data;
using PRDCRfriend.Models.SessionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PRDCRfriend.Services
{
    public class SessionService
    {
        private readonly Guid _userId;
        public SessionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSession(SessionCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    new Session()
                    {
                        OwnerId = _userId,
                        ArtistId = model.ArtistId,
                        ProjectTitle = model.ProjectTitle,
                        Date = model.Date,
                        Time = model.Time,
                        Duration = model.Duration,
                        ProducerId = ctx.Producers.Single(x => x.OwnerId == _userId).Id,
                        //Id = e.Id,
                        //ProjectTitle = e.ProjectTitle,
                        //Date = e.Date.ToShortDateString(),
                        //Time = e.Time.ToShortTimeString(),
                        //Artist = e.Artist.FullName(),
                        //Artist = model.Artist,
                        //ArtistFirstName = model.ArtistFirstName,
                        //ArtistLastName = model.ArtistLastName
                    };

                if (SessionNoOverlap(entity))
                {

                    ctx.Sessions.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
                else return false;
            }
        }

        public bool CreateSessionWithArtist(SessionProducerCreate model)
        {

            var session =
                new Session()
                {
                    
                    ProjectTitle = model.ProjectTitle,
                    Date = model.Date,
                    Time = model.Time,
                    Duration = model.Duration,
                    ProducerId = model.ProducerId,

                };

            var artist = new Artist()
            {
                FirstName = model.ArtistFirstName,
                LastName = model.ArtistLastName,
                PhoneNumber = model.ArtistPhoneNumber
            };

            if (SessionNoOverlap(session))
            {

                using (var ctx = new ApplicationDbContext())
                {

                    ctx.Artists.Add(artist);

                    if (ctx.SaveChanges() == 1)
                    {
                        var artistdbObject = ctx.Artists.OrderByDescending(x => x.Id).FirstOrDefault();
                        session.Id = artistdbObject.Id;
                        ctx.Artists.Add(artist);
                        return ctx.SaveChanges() == 1;

                    }
                    return false;
                }
            }
            return false;
        }

        public bool SessionNoOverlap(Session session)
        {
            var newStart = session.Date;
            var newEnd = session.Date + session.Duration;

            using (var ctx = new ApplicationDbContext())
            {

                var producer = ctx.Producers.Single(x => x.OwnerId == _userId);

                if (producer != null)
                {

                    foreach (var sesh in producer.Sessions)
                    {
                        var oldStart = sesh.Date;
                        var oldEnd = sesh.Date + session.Duration;

                        bool overlap = oldStart < newEnd && newStart < oldEnd;
                        if (overlap)
                        {
                            return false;
                        }
                    }
                    return true;
                }

                return false;
            }
        }

        public IEnumerable<SessionListItem> GetSessions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sessions.ToArray();
                return query.Select(
                    e =>
                    new SessionListItem
                    {
                        Id = e.Id,
                        ArtistId = e.ArtistId,
                        ProjectTitle = e.ProjectTitle,
                        Date = e.Date.ToShortDateString(),
                        Time = e.Time.ToShortTimeString(),
                        Artist = e.Artist.FullName(),
                        // Producer = e.SessionId.ToString()
                    }).ToArray();


            }
        }

        public SessionDetail GetSessionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                    .Sessions
                    .Single(e => e.Id == id);
                return
                    new SessionDetail
                    {
                        Id = entity.Id,
                        ProjectTitle = entity.ProjectTitle,
                        Date = entity.Date,
                        Time = entity.Date + entity.Duration,
                        Duration = entity.Duration,
                        // ArtistId = entity.ArtistId,
                        Artist = entity.Artist.FullName(),
                        //ProducerId = entity.ProducerId,
                        Producer = entity.Producer.FullName()

                    };
            }
        }

        public bool UpdateSession(SessionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Sessions
                    .Single(e => e.Id == model.Id);

                //entity.Id = model.Id;
                entity.ProjectTitle = model.ProjectTitle;
                entity.Date = model.Date;
                entity.Time = model.Time;
                //entity.Duration = model.Duration;
                //entity.ArtistId = model.ArtistId;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSession(int sessionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Sessions
                    .Single(e => e.Id == sessionId && e.OwnerId == _userId);

                ctx.Sessions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
