using PRDCRfriend.Data;
using PRDCRfriend.Models.PlannerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Services
{
    public class ProjectPlannerService
    {
        private readonly Guid _userId;
        public ProjectPlannerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProjectPlanner(PlannerCreate model)
        {
            var entity =
                new ProjectPlanner()
                {
                    PlannerId = model.PlannerId,
                    ProjectTitle = model.ProjectTitle,
                    ProducerId = model.ProducerId,
                    ArtistName = model.ArtistName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ProjectPlanners.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlannerProducerListItem> GetPlanners()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .ProjectPlanners
                    .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                            new PlannerProducerListItem
                            {
                               PlannerId =e.PlannerId,
                               ProducerId =e.ProducerId,
                               ProjectTitle =e.ProjectTitle
                            }
                      );
                return query.ToArray();

            }
        }

    }
}
