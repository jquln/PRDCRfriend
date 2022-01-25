using PRDCRfriend.Data;
using PRDCRfriend.Models.ArtistModels;
using PRDCRfriend.Models.SessionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Services
{
    public class ArtistService
    {
        private readonly Guid _userId;

        public ArtistService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateArtist(ArtistCreate model)
        {
            var entity =
                new Artist()
                {
                    //OwnerId = _userId,
                    ProjectTitle = model.ProjectTitle,
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ArtistListItem> GetArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Artists.AsEnumerable()
                    .Select(
                        e =>
                        new ArtistListItem
                        {
                            Id = e.Id,
                            Name = e.FullName(),
                            ProjectTitle = e.ProjectTitle
                        }).ToArray();
                return query;

            }
        }

        public ArtistDetail GetArtistById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.Id == id);
                return
                    new ArtistDetail
                    {
                        Id = entity.Id,
                        LastName = entity.LastName,
                        FirstName= entity.FirstName,
                        ProjectTitle = entity.ProjectTitle,
                        Email = entity.Email,
                        PhoneNumber= entity.PhoneNumber,
                        Sessions = entity.Sessions.Select(a => new SessionListItem
                        {
                            Id = a.Id,
                            ProjectTitle = a.ProjectTitle,
                            Date = a.Date.ToShortDateString(),
                            Time = a.Time.ToShortDateString(),
                            Artist = a.Artist.FullName()

                        }).ToList()
                    };
            }
        }

        public bool UpdateArtist(ArtistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Artists
                    .Single(e => e.Id == model.Id);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.ProjectTitle = model.ProjectTitle;
                entity.Email = model.Email;
                entity.PhoneNumber = model.PhoneNumber;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteArtist(int artistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.Id == artistId);
                ctx.Artists.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
