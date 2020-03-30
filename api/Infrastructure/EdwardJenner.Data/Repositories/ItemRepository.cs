using EdwardJenner.Domain.Interfaces.Repositories;
using EdwardJenner.Models.Models;
using EdwardJenner.Models.Settings;

namespace EdwardJenner.Data.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        protected override string GetCollectionName() => "items";

        public ItemRepository(MongoConnection mongoConnection) : base(mongoConnection)
        {
        }
    }
}
