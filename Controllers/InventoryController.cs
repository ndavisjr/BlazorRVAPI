using System.Collections.Generic;
using BlazorRVAPI.Data;
using BlazorRVAPI.Models.Inventory;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRVAPI.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly IBlazorRVAPIRepo _repository;

        public InventoryController(IBlazorRVAPIRepo repository)
        {
            _repository = repository;
        }

        //GET api/inventory
        [HttpGet]
        public ActionResult<IEnumerable<InventoryItem>> GetAllInventoryItems()
        {
            var inventoryItemList = _repository.GetAllInventoryItems();
            return Ok(inventoryItemList);
        }

        //GET api/inventory/{id}
        [HttpGet("{id}", Name = "GetInventoryItemById")]
        public ActionResult<InventoryItem> GetInventoryItemById(int id)
        {
            var inventoryItem = _repository.GetInventoryItemById(id);
            if (inventoryItem != null)
            {
                return Ok(inventoryItem);
            }

            return NotFound();
        }

        //POST api/inventory
        [HttpPost]
        public ActionResult<InventoryItem> CreateInventoryItem(InventoryItem inventoryItem)
        {
            _repository.CreateInventoryItem(inventoryItem);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetInventoryItemById), new { Id = inventoryItem.Id }, inventoryItem);
        }

        //PUT api/inventory/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateInventoryItem(int id, InventoryItem inventoryItem)
        {
            // verify resourse exists
            var inventoryItemFromRepo = _repository.GetInventoryItemById(id);
            if (inventoryItemFromRepo == null)
            {
                return NotFound();
            }

            _repository.UpdateInventoryItem(inventoryItem);
            _repository.SaveChanges();

            //return 204 - No Content
            return NoContent();
        }

        //PATCH api/inventory/{id}
        [HttpPatch("{id}")]
        public ActionResult PatchInventory(int id, JsonPatchDocument<InventoryItem> patchDoc)
        {
            // verify resourse exists
            var inventoryItemFromRepo = _repository.GetInventoryItemById(id);
            if (inventoryItemFromRepo == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(inventoryItemFromRepo, ModelState);
            if (!TryValidateModel(inventoryItemFromRepo))
            {
                return ValidationProblem(ModelState);
            }

            _repository.UpdateInventoryItem(inventoryItemFromRepo);
            _repository.SaveChanges();

            //return 204 - No Content
            return NoContent();
        }

        //DELETE api/inventory/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteInventoryItem(int id)
        {
            // verify resourse exists
            var inventoryItemFromRepo = _repository.GetInventoryItemById(id);
            if (inventoryItemFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteInventoryItem(inventoryItemFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}