using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpendSmart.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SpendSmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SpendSmartDbContext _context;

        public HomeController(ILogger<HomeController> logger, SpendSmartDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expenses(string searchTerm, DateTime? startDate, DateTime? endDate, int page = 1, int pageSize = 25)
        {
            var query = _context.Expenses.AsQueryable();

            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(e => e.DateOfAction >= startDate.Value && e.DateOfAction <= endDate.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                int? searchId = int.TryParse(searchTerm, out int id) ? id : (int?)null;
                query = query.Where(e => e.description.Contains(searchTerm) || (searchId.HasValue && e.Id == searchId.Value));
            }

            var totalExpenses = query.Count();
            var totalPages = (int)Math.Ceiling(totalExpenses / (double)pageSize);
            var expenses = query
                .OrderBy(e => e.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalExpenses = expenses.Sum(x => x.value);
            ViewBag.PageSize = pageSize;
            ViewBag.SearchTerm = searchTerm;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            return View(expenses);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult AddExpense()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(Expense model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _context.Expenses.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Expenses");
        }

        public IActionResult EditExpense()
        {
            return View("EnterExpenseId");
        }

        [HttpPost]
        public IActionResult CheckExpenseId(int expenseId)
        {
            if (expenseId <= 0)
            {
                TempData["ErrorMessage"] = "Invalid expense ID.";
                return RedirectToAction("EditExpense");
            }

            var expenseInDb = _context.Expenses.SingleOrDefault(x => x.Id == expenseId);

            if (expenseInDb == null)
            {
                TempData["ErrorMessage"] = "Expense not found.";
                return RedirectToAction("EditExpense");
            }

            return View("EditExpense", expenseInDb);
        }





        [HttpPost]
        public IActionResult EditExpenseForm(Expense model)
        {
            if (!ModelState.IsValid)
            {
                // Output validation errors for debugging
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); // or use a logger to log the errors
                }

                // If the model state is not valid, re-display the edit form with validation messages
                return View("EditExpense", model);
            }

            // Find the existing expense in the database
            var expenseInDb = _context.Expenses.SingleOrDefault(e => e.Id == model.Id);

            if (expenseInDb == null)
            {
                // If the expense is not found, return a not found result
                return NotFound();
            }

            // Update the expense details
            expenseInDb.description = model.description;
            expenseInDb.value = model.value;
            expenseInDb.DateOfAction = DateTime.Now; // Set the DateOfAction to the current date and time

            try
            {
                // Save the changes to the database
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Log or handle the exception
                return View("EditExpense", model); // Return to the form in case of an error
            }

            // Redirect to the Expenses view after saving
            return RedirectToAction("Expenses");
        }




        public IActionResult DeleteExpenseInput()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmDeleteExpense(int id)
        {
            var expenseInDb = _context.Expenses.SingleOrDefault(x => x.Id == id);
            if (expenseInDb == null)
            {
                ViewBag.ErrorMessage = "Expense not found.";
                return View("DeleteExpenseInput");
            }

            return View("ConfirmDeleteExpense", expenseInDb);
        }

        [HttpPost]
        public IActionResult DeleteExpense(int id)
        {
            var expenseInDb = _context.Expenses.SingleOrDefault(x => x.Id == id);
            if (expenseInDb == null)
            {
                ViewBag.ErrorMessage = "Expense not found.";
                return View("DeleteExpenseInput");
            }

            _context.Expenses.Remove(expenseInDb);
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }

        // GET: /Home/GetQuote
        public IActionResult GetQuote()
        {
            return View();
        }

        // POST: /Home/SubmitQuote
        [HttpPost]
        public async Task<IActionResult> SubmitQuote(QuoteRequest quoteRequest)
        {
            if (ModelState.IsValid)
            {
                _context.QuoteRequests.Add(quoteRequest);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Your quote request has been submitted successfully!";
                return RedirectToAction("GetQuote");
            }

            return View("GetQuote", quoteRequest);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
