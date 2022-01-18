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
            var entity =
                new Session()
                {
                    SessionId = model.SessionId,
                    ProjectTitle = model.ProjectTitle,
                    Time = model.Time,
                    Duration = model.Duration,
                    ArtistId = model.ArtistId,
                    ProducerId = model.ProducerId
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
                    Time = DateTime.Now,
                    Duration = model.Duration,
                    ProducerId =model.ProducerId,
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
                        Time = e.Time.ToShortDateString(),
                        ProjectTitle = e.ProjectTitle,
                        Artist = e.Artist.FullName()
                    }).ToArray();
            }
        }


    }
}
