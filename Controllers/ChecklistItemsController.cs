using System.Collections.Generic;
using BlazorRVAPI.Data;
using BlazorRVAPI.Models.Checklist;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRVAPI.Controllers
{
    [ApiController]
    [Route("api/checklistItems")]
    public class ChecklistItemsController : ControllerBase
    {
        private readonly IBlazorRVAPIRepo _repository;

        public ChecklistItemsController(IBlazorRVAPIRepo repository)
        {
            _repository = repository;
        }

        //GET api/checklistItems
        [HttpGet]
        public ActionResult<IEnumerable<ChecklistItem>> GetAllChecklistItems()
        {
            var checklistItemList = _repository.GetAllChecklistItems();
            return Ok(checklistItemList);
        }

        //GET api/checklistItems/{id}
        [HttpGet("{id}", Name = "GetChecklistItemById")]
        public ActionResult<ChecklistItem> GetChecklistItemById(int id)
        {
            var checklistItem = _repository.GetChecklistItemById(id);
            if (checklistItem != null)
            {
                return Ok(checklistItem);
            }

            return NotFound();
        }

        //POST api/checklistItems
        [HttpPost]
        public ActionResult<ChecklistItem> CreateChecklistItem(ChecklistItem checklistItem)
        {
            _repository.CreateChecklistItem(checklistItem);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetChecklistItemById), new { Id = checklistItem.Id }, checklistItem);
        }

        //PUT api/checklistItems/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateChecklistItem(int id, ChecklistItem checklistItem)
        {
            // verify resourse exists
            var checklistItemFromRepo = _repository.GetChecklistItemById(id);
            if (checklistItemFromRepo == null)
            {
                return NotFound();
            }

            _repository.UpdateChecklistItem(checklistItem);
            _repository.SaveChanges();

            //return 204 - No Content
            return NoContent();
        }

        //PATCH api/checklistItems/{id}
        [HttpPatch("{id}")]
        public ActionResult PatchChecklistItem(int id, JsonPatchDocument<ChecklistItem> patchDoc)
        {
            // verify resourse exists
            var checklistItemFromRepo = _repository.GetChecklistItemById(id);
            if (checklistItemFromRepo == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(checklistItemFromRepo, ModelState);
            if (!TryValidateModel(checklistItemFromRepo))
            {
                return ValidationProblem(ModelState);
            }

            _repository.UpdateChecklistItem(checklistItemFromRepo);
            _repository.SaveChanges();

            //return 204 - No Content
            return NoContent();
        }

        //DELETE api/checklistitems/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteChecklistItem(int id)
        {
            // verify resourse exists
            var checklistItemFromRepo = _repository.GetChecklistItemById(id);
            if (checklistItemFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteChecklistItem(checklistItemFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // Some association between Checklist and ChecklistItems
        // [HttpGet("{id}", Name = "GetChecklistItemForChecklist")]
        // public ActionResult GetChecklistItemForChecklist (int checklistId, int checklistItemId)
        // {
        //      // verify Checklist and ChecklistItem exist
        //     var checklistFromRepo = _repository.GetChecklistById(checklistId);
        //     var checklistItemFromRepo = _repository.GetChecklistItemById(checklistItemId);
        //     if (checklistFromRepo == null || checklistItemFromRepo == null)
        //     {
        //         return NotFound();
        //     }

        //     // grab the ChecklistItem from the Checklist
        //     var checklistItemFromChecklist = _repository.GetChecklistItemForChecklist(checklistId, checklistItemId)

        //     return Ok(checklistItemFromChecklist);
        // }

        // [HttpPost]
        // public ActionResult CreateChecklistItemForChecklist (int checklistId, ChecklistItem checklistItem)
        // {
        //      // verify Checklist exists
        //     var checklistFromRepo = _repository.GetChecklistById(checklistId);
        //     if (checklistFromRepo == null)
        //     {
        //         return NotFound();
        //     }

        //     _repository.AddChecklistItem(checklistId, checklistItem);
        //     _repository.SaveChanges();

        //     return CreatedAtRoute(nameof(GetChecklistItemForChecklist), new { Id = checklistItem.Id }, checklistItem);
        // }
    }
}