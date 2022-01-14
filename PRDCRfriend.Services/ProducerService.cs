using PRDCRfriend.Data;
using PRDCRfriend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
            using (var ctx = new ApplicationDbContext())
            {
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
                    .Producers.AsEnumerable()
                    .Select(
                        e =>
                        new ProducerListItem
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName
                        }).ToArray();
                return query;

            }
        }

        public ProducerDetail GetProducerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Producers
                    .Single(e => e.ProducerId == id && e.OwnerId == _userId);
                return
                    new ProducerDetail
                    {
                        ProducerId = entity.ProducerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName
                    };
            }
        }

    }
}
