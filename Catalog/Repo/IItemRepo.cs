using Catalog.Entities;

namespace Catalog.Repo
{
 public interface IItemRepo
    {
        Item GetItem(Guid Id);
        IEnumerable<Item> GetItems();

        public void CreateItem(Item item);

        public void UpdateItem(Item item);

        public void DeleteItem(Guid guid);
    }
}