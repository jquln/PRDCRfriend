using PRDCRfriend.Data;
using PRDCRfriend.Models.SessionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int day = 01;
            int month = 01;
            int year = 2022;
            int hour = 17;
            int minute = 30;
            int second = 30;
            DateTime date = new DateTime(year, month, day, hour, minute, second);
            var entity =
                new Session()
                {

                    ProjectTitle = model.ProjectTitle,
                    Time = model.Time,
                    Duration = model.Duration,
                    ProducerId = model.ProducerId,
                    ArtistId = model.ArtistId,
                    //ArtistFirstName = model.ArtistFirstName,
                    //ArtistLastName = model.ArtistLastName
                };
            using (var ctx = new ApplicationDbContext())
            {
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
                    Time = model.Time,
                    Duration = model.Duration
                    
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

                        var artistdbObject = ctx.Artists.OrderByDescending(x => x.ArtistId).FirstOrDefault();
                        session.ArtistId = artistdbObject.ArtistId;
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
            var newStart = session.Time;
            var newEnd = session.Time + session.Duration;

            using (var ctx = new ApplicationDbContext())
            {

                var producer = ctx.Producers.Single(x => x.ProducerId == session.ProducerId);

                if (producer != null)
                {

                    foreach (var sesh in producer.Sessions)
                    {
                        var oldStart = sesh.Time;
                        var oldEnd = sesh.Time + session.Duration;

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
                                    SessionId = e.SessionId,
                                    ProjectTitle = e.ProjectTitle,
                                    Time = e.Time.ToShortDateString(),
                                   // Artist = e.Artist.FullName(),
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
                    .Single(e => e.SessionId == id && e.OwnerId == _userId);
                return
                    new SessionDetail
                    {
                        SessionId = entity.SessionId,
                        ProjectTitle = entity.ProjectTitle,
                        StartTime = entity.Time,
                        EndTime = entity.Time + entity.Duration,
                        Duration = entity.Duration,
                        ArtistId = entity.ArtistId,
                        Artist = entity.Artist.FullName(),
                        ProducerId = entity.ProducerId,
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
                    .Single(e => e.SessionId == model.SessionId && e.OwnerId == _userId);

                entity.SessionId = model.SessionId;
                entity.ProjectTitle = model.ProjectTitle;
                entity.Time = model.Time;
                entity.Duration = model.Duration;
                entity.ArtistId = model.ArtistId;
                

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
                    .Single(e => e.SessionId == sessionId && e.OwnerId == _userId);

                ctx.Sessions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
