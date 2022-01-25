using PRDCRfriend.Data;
using PRDCRfriend.Models;
using PRDCRfriend.Models.SessionModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace PRDCRfriend.Services
{
    public class ProducerService
    {
        private readonly Guid _userId;

        public ProducerService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateProducer(ProducerCreate model)
        {
            var entity =
                new Producer()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };
            using (var ctx = new ApplicationDbContext())
            {
                var existingProducer =
                  ctx
                  .Producers
                  .SingleOrDefault(e => e.OwnerId == _userId);
                if (existingProducer != null)
                    return false;

                    ctx.Producers.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProducerListItem> GetProducers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Producers
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ProducerListItem
                        {
                            Id = e.Id,
                            FirstName = e.FirstName,
                            LastName = e.LastName
                        }
                   );
                return query.ToArray();


            }
        }

        public ProducerDetail GetProducerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Producers
                    .Single(e => e.OwnerId == _userId);
                return
                    new ProducerDetail
                    {
                        Id = entity.Id,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Sessions = entity.Sessions.Select(a => new SessionListItem
                        {
                            Id = a.Id,
                            ProjectTitle = a.ProjectTitle,
                            Date = a.Date.ToShortDateString(),
                            Time = a.Time.ToShortDateString(),
                            //Artist = a.Artist.FullName()

                        }).ToList()
                    };
            }
        }

        public bool UpdateProducer(ProducerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Producers
                    .Single(e => e.Id == model.Id && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProducer(int producerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Producers
                    .Single(e => e.Id == producerId && e.OwnerId == _userId);
                ctx.Producers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
