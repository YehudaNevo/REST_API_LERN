using Microsoft.AspNetCore.Mvc;
using Catalog.Repo;
using Catalog.Entities;
using Catalog.Dtos;
namespace Catalog.Controllers
{   
   
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepo repo;

        public ItemsController(IItemRepo repo)
        {
            this.repo = repo;
        }

         // GET / items 
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repo.GetItems().Select( item => item.AsDto());
            return items;

        }
        // GET / items/ {id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {

        var item = repo.GetItem(id);
        if (item is null)
        {
            return NotFound();
        }
        return item.AsDto();
        }
        //Post/item
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto createItemDto)

        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = createItemDto.Name,
                Price = createItemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            repo.CreateItem(item);

            return CreatedAtAction(nameof(GetItem),new {id = item.Id},item.AsDto());


        }
        // PUT/ items / {id}
       [HttpPut("{id}")]
       public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
       {
            var currentItem = repo.GetItem(id);
            if (currentItem is null)
            {
                return NotFound();
            }
            Item updatedItem = currentItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repo.UpdateItem(updatedItem);
            
            return NoContent();
       } 
    // DELETE / items / {id}
       [HttpDelete("id")]
       public ActionResult DeleteItem(Guid id)
       {
        var itemToDelete = repo.GetItem(id);
            if (itemToDelete is null)
            {
                return NotFound();
            }
            repo.DeleteItem(id);
            return NoContent();
       }
    }

}
