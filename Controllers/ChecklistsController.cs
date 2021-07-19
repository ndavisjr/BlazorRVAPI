using System.Collections.Generic;
using BlazorRVAPI.Data;
using BlazorRVAPI.Models.Checklist;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRVAPI.Controllers
{
    [ApiController]
    [Route("api/checklists")]
    public class ChecklistsController : ControllerBase
    {
        private readonly IBlazorRVAPIRepo _repository;

        public ChecklistsController(IBlazorRVAPIRepo repository)
        {
            _repository = repository;
        }

        //GET api/checklists
        [HttpGet]
        public ActionResult<IEnumerable<Checklist>> GetAllChecklists()
        {
            var checklistsList = _repository.GetAllChecklists();
            return Ok(checklistsList);
        }

        //GET api/checklists/{id}
        [HttpGet("{id}", Name = "GetChecklistById")]
        public ActionResult<Checklist> GetChecklistById(int id)
        {
            var checklist = _repository.GetChecklistById(id);
            if (checklist != null)
            {
                return Ok(checklist);
            }

            return NotFound();
        }

        //POST api/checklists
        [HttpPost]
        public ActionResult<Checklist> CreateChecklist(Checklist checklist)
        {
            _repository.CreateChecklist(checklist);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetChecklistById), new { Id = checklist.Id }, checklist);
        }

        //PUT api/checklists/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateChecklist(int id, Checklist checklist)
        {
            // verify resourse exists
            var checklistFromRepo = _repository.GetChecklistById(id);
            if (checklistFromRepo == null)
            {
                return NotFound();
            }

            _repository.UpdateChecklist(checklist);
            _repository.SaveChanges();

            //return 204 - No Content
            return NoContent();
        }

        //PATCH api/checklists/{id}
        [HttpPatch("{id}")]
        public ActionResult PatchChecklist(int id, JsonPatchDocument<Checklist> patchDoc)
        {
            // verify resourse exists
            var checklistFromRepo = _repository.GetChecklistById(id);
            if (checklistFromRepo == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(checklistFromRepo, ModelState);
            if (!TryValidateModel(checklistFromRepo))
            {
                return ValidationProblem(ModelState);
            }

            _repository.UpdateChecklist(checklistFromRepo);
            _repository.SaveChanges();

            //return 204 - No Content
            return NoContent();
        }

        //DELETE api/checklists/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteChecklist(int id)
        {
            // verify resourse exists
            var checklistFromRepo = _repository.GetChecklistById(id);
            if (checklistFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteChecklist(checklistFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // Some association between Checklist and ChecklistItems


    }
}