using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sample.Data;
using sample.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample.Controllers
{
    public class UserController : Controller
    {
        private readonly ExamContext _context;

        public UserController(ExamContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Users user)
        {
            if (ModelState.IsValid)
            {
                _context.users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Users user)
        {
            var existingUser = await _context.users
                .FirstOrDefaultAsync(u => u.username == user.username && u.password == user.password);
            if (existingUser != null)
            {
                // Placeholder for session handling
                // HttpContext.Session.SetInt32("User  ID", existingUser .user_id);
                return RedirectToAction("ViewQuizzes");
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(user);
        }

        public async Task<IActionResult> ViewQuizzes()
        {
            var quizzes = await _context.quizzes.ToListAsync();
            return View(quizzes);
        }

        public async Task<IActionResult> AttemptQuiz(int id)
        {
            var questions = await _context.questions.Where(q => q.quiz_id == id).ToListAsync();
            if (questions == null || !questions.Any())
            {
                ModelState.AddModelError("", "No questions found for this quiz.");
                return RedirectToAction("ViewQuizzes");
            }
            return View(questions);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitQuiz(List<Questions> questions)
        {
            if (questions == null || !questions.Any())
            {
                ModelState.AddModelError(string.Empty, "No questions were provided for the quiz.");
                return RedirectToAction("ViewQuizzes"); // Redirect to a relevant view
            }

            // Assuming you have a way to get the current user's ID
            var currentUser = 8; // Replace with the actual user ID from session or context

            var quizResult = new QuizResults
            {
                quiz_id = questions.First().quiz_id, // Assuming all questions belong to the same quiz
                user_id = currentUser,
                totalObtainedMarks = CalculateTotalMarks(questions) // Implement this method to calculate marks
            };

            // Add the quiz result to the database
            _context.quizresults.Add(quizResult);
            await _context.SaveChangesAsync();

            // Redirect to ViewQuizResult using the quiz_res_id of the newly created result
            return RedirectToAction("ViewQuizResult", new { id = quizResult.quiz_res_id });
        }

        private int CalculateTotalMarks(List<Questions> questions)
        {
            // Implement your logic to calculate the total marks based on the provided questions
            // For example, you might check if the selected answers match the correct answers
            return questions.Count(q => q.answer == q.SelectedAnswer); // Assuming SelectedAnswer is set correctly
        }

        [HttpPost]
        public async Task<IActionResult> ViewQuizResult(int id)
        {
            var result = await _context.quizresults.FirstOrDefaultAsync(r => r.quiz_res_id == id);
            if (result == null)
            {
                return NotFound(); // Return a 404 if the result is not found
            }
            return View(result);
        }
    }
}