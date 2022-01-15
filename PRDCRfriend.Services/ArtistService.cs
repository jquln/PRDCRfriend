using PRDCRfriend.Data;
using PRDCRfriend.Models.ArtistModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Services
{
    public class ArtistService
    {
        private readonly Guid _artistId;

        public ArtistService(Guid artistId)
        {
            _artistId = artistId;
        }

        public bool CreateArtist(ArtistCreate model)
        {
            var entity =
                new Artist()
                {
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
                            ArtistId = e.ArtistId,
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
                    .Single(e => e.ArtistId == id && e.OwnerId == _artistId);
                return
                    new ArtistDetail
                    {
                        ArtistId = entity.ArtistId,
                        LastName = entity.LastName,
                        FirstName= entity.FirstName,
                        ProjectTitle = entity.ProjectTitle,
                        Email = entity.Email,
                        PhoneNumber= entity.PhoneNumber
                    };
            }
        }

    }
}
