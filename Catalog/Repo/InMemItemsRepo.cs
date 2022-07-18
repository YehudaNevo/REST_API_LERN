using System.Collections.Generic;
using Catalog.Repo;
using System.Linq;
using Catalog.Entities;
namespace Catalog.Repo
{
    public class InMemItemsRepo: IItemRepo
    {
        private readonly List<Item> items = new()
        {
            new Item{Id = Guid.NewGuid(),Name = "A",Price = 1,CreatedDate =  DateTimeOffset.UtcNow},
            new Item{Id = Guid.NewGuid(),Name = "B",Price = 2,CreatedDate =  DateTimeOffset.UtcNow},
            new Item{Id = Guid.NewGuid(),Name = "C",Price = 3,CreatedDate =  DateTimeOffset.UtcNow},
            new Item{Id = Guid.NewGuid(),Name = "D",Price = 4,CreatedDate =  DateTimeOffset.UtcNow},
            new Item{Id = Guid.NewGuid(),Name = "E",Price = 5,CreatedDate =  DateTimeOffset.UtcNow},
        };
        public  IEnumerable<Item> GetItems()
        {
            return items;
        }
        public  Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        void IItemRepo.CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(ele => ele.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid guid)

        {
            var index = items.FindIndex(ele => ele.Id == guid );
            if (index >= 0)
            {
                items.RemoveAt(index);
            }
        }
    }
}