using EdwardJenner.Domain.Interfaces.Repositories;
using EdwardJenner.Models.Models;
using EdwardJenner.Models.Settings;

namespace EdwardJenner.Data.Repositories
{
    public class RatingRepository : BaseRepository<Rating>, IRatingRepository
    {
        protected override string GetCollectionName() => "ratings";

        public RatingRepository(MongoConnection mongoConnection) : base(mongoConnection)
        {
        }
    }
}
