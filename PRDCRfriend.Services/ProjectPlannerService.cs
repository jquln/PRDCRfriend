using PRDCRfriend.Data;
using PRDCRfriend.Models.PlannerModels;
using PRDCRfriend.Models.ProjectPlannerModels;
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

        public bool CreatePlanner(PlannerCreate model)
        {
            var entity =
                new ProjectPlanner()
                {
                  
                    ProjectTitle = model.ProjectTitle,
                    Date = model.Date,
                    Content = model.Content,
                    ProducerId = model.ProducerId,
                    Artist = model.Artist
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ProjectPlanners.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool CreateProjectPlannerWithProducer(PlannerProducerCreate model)
        {

            var planner =
                new ProjectPlanner()
                {
                    ProjectTitle = model.ProjectTitle,
                    Date = model.Date,
                    //ProducerId = model.ProducerId,
                    Artist = model.Artist,
                    Content = model.Content,

                };

            var producer = new Producer()
            {
                ProducerId = model.ProducerId,
                ProjectPlanners = model.ProjectPlanners,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ProjectPlanners.Add(planner);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlannerProducerListItem> GetPlanners()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .ProjectPlanners.ToArray();
                    return query
                    .Select(
                            e =>
                            new PlannerProducerListItem
                            {
                                PlannerId = e.PlannerId,
                                ProducerId = e.ProducerId,
                                ProjectTitle = e.ProjectTitle,
                                Date = e.Date.ToShortDateString(),
                                //Artist = e.Artist.FullName(),
                               
                            }).ToArray();

            }
        }

        public PlannerDetail GetPlannerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                    .ProjectPlanners
                    .Single(e => e.PlannerId == id);
                return
                    new PlannerDetail
                    {
                        PlannerId = entity.PlannerId,
                        ProjectTitle = entity.ProjectTitle,
                        Date = entity.Date,
                        Content = entity.Content,
                        
                        
                        
                        // ArtistId = entity.ArtistId,
                         //Artist = entity.Artist.FullName(),
                        //ProducerId = entity.ProducerId,
                        // Producer = entity.Producer.FullName()

                    };
            }
        }

        public bool UpdateProjectPlanner(ProjectPlannerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .ProjectPlanners
                    .Single(e => e.PlannerId == model.PlannerId);

                entity.PlannerId = model.PlannerId;
                entity.ProjectTitle = model.ProjectTitle;
                entity.Date = model.Date;
                entity.Content = model.Content;
                entity.Artist = model.Artist;
                entity.ProducerId = model.ProducerId;
               
                


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProjectPlanner(int plannerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ProjectPlanners
                    .Single(e => e.PlannerId == plannerId);

                ctx.ProjectPlanners.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
