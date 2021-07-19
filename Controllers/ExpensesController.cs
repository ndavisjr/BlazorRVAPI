using System.Collections.Generic;
using BlazorRVAPI.Data;
using BlazorRVAPI.Models.Expense;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRVAPI.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    public class ExpensesController : ControllerBase
    {
        private readonly IBlazorRVAPIRepo _repository;

        public ExpensesController(IBlazorRVAPIRepo repository)
        {
            _repository = repository;
        }

        //GET api/expenses
        [HttpGet]
        public ActionResult<IEnumerable<Expense>> GetAllExpenses()
        {
            var expenseList = _repository.GetAllExpenses();
            return Ok(expenseList);
        }

        //GET api/expenses/{id}
        [HttpGet("{id}", Name = "GetExpenseById")]
        public ActionResult<Expense> GetExpenseById(int id)
        {
            var expense = _repository.GetExpenseById(id);
            if (expense != null)
            {
                return Ok(expense);
            }

            return NotFound();
        }

        //POST api/expenses
        [HttpPost]
        public ActionResult<Expense> CreateExpense(Expense expense)
        {
            _repository.CreateExpense(expense);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetExpenseById), new { Id = expense.Id }, expense);
        }

        //PUT api/expenses/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateExpenses(int id, Expense expense)
        {
            // verify resourse exists
            var expenseFromRepo = _repository.GetExpenseById(id);
            if (expenseFromRepo == null)
            {
                return NotFound();
            }

            _repository.UpdateExpense(expense);
            _repository.SaveChanges();

            //return 204 - No Content
            return NoContent();
        }

        //PATCH api/expenses/{id}
        [HttpPatch("{id}")]
        public ActionResult PatchExpense(int id, JsonPatchDocument<Expense> patchDoc)
        {
            // verify resourse exists
            var expenseFromRepo = _repository.GetExpenseById(id);
            if (expenseFromRepo == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(expenseFromRepo, ModelState);
            if (!TryValidateModel(expenseFromRepo))
            {
                return ValidationProblem(ModelState);
            }

            _repository.UpdateExpense(expenseFromRepo);
            _repository.SaveChanges();

            //return 204 - No Content
            return NoContent();
        }

        //DELETE api/expenses/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteExpense(int id)
        {
            // verify resourse exists
            var expenseFromRepo = _repository.GetExpenseById(id);
            if (expenseFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteExpense(expenseFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}