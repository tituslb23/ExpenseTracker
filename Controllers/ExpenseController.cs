using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker2._0.Model;

namespace ExpenseTracker2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExpenseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Expense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseModel>>> GetExpenses()
        {
            var expense = await (from expenses in _context.Expenses
                                 from category in _context.Categories
                                 where expenses.CategoryId == category.CategoryId
                                 select new ExpenseDataModel
                                 {
                                     ExpenseId = expenses.ExpenseId,
                                     ExpenseName = expenses.ExpenseName,
                                     Description = expenses.Description,
                                     CategoryId = expenses.CategoryId,
                                     CategoryName = category.CategoryName,
                                     CategoryLimit = category.CategoryLimit,
                                     Amount = expenses.Amount
                                 }).ToListAsync();



            return Ok(expense);
        }

        // GET: api/Expense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseModel>> GetExpenseModel(int id)
        {
            var expenseModel  = await (from expenses in _context.Expenses
                                 from category in _context.Categories
                                 where expenses.ExpenseId == id
                                 select new ExpenseDataModel
                                 {
                                     ExpenseId = expenses.ExpenseId,
                                     ExpenseName = expenses.ExpenseName,
                                     Description = expenses.Description,
                                     CategoryId = expenses.CategoryId,
                                     CategoryName = category.CategoryName,
                                     CategoryLimit = category.CategoryLimit,
                                     Amount = expenses.Amount
                                 }).FirstOrDefaultAsync();

            if (expenseModel == null)
            {
                return NotFound();
            }

            return Ok(expenseModel);
        }

        // PUT: api/Expense/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenseModel(int id, ExpenseModel expenseModel)
        {
            if (id != expenseModel.ExpenseId)
            {
                return BadRequest();
            }

            _context.Entry(expenseModel).State = EntityState.Modified;
            var existingExpense = await _context.Expenses.FindAsync(id);


            try
            {


                existingExpense.ExpenseName = expenseModel.ExpenseName;
                existingExpense.Description = expenseModel.Description;
                existingExpense.CategoryId = expenseModel.CategoryId;
                existingExpense.Amount = expenseModel.Amount;


                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(existingExpense);
        }

        // POST: api/Expense
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExpenseModel>> PostExpenseModel(ExpenseModel expenseModel)
        {
            var category = await _context.Categories.FindAsync(expenseModel.CategoryId);
            if (category == null)
            {
                return NotFound();
            }

            var newExpense = new ExpenseModel
            {
                ExpenseName = expenseModel.ExpenseName,
                Description = expenseModel.Description,
                CategoryId = expenseModel.CategoryId,
                Amount = expenseModel.Amount
            };



            _context.Expenses.Add(newExpense);
            await _context.SaveChangesAsync();

            return await GetExpenseModel(newExpense.CategoryId);
        }

        // DELETE: api/Expense/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenseModel(int id)
        {
            var expenseModel = await _context.Expenses.FindAsync(id);
            if (expenseModel == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(expenseModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpenseModelExists(int id)
        {
            return _context.Expenses.Any(e => e.ExpenseId == id);
        }
    }
}
