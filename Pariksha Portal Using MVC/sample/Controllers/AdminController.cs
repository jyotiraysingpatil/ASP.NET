using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sample.Models;
using sample.Data;

using System.Threading.Tasks;

namespace sample.Controllers
{
    public class AdminController : Controller
    {
        private readonly ExamContext _context;

        public AdminController(ExamContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.admins.ToListAsync());
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Admins admin)
        {
            var existingAdmin = await _context.admins.FirstOrDefaultAsync(a => a.username == admin.username && a.password == admin.password);
            if (existingAdmin != null)
            {
                return RedirectToAction("AddCategory");
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(admin);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Admins admin)
        {
            if (ModelState.IsValid)
            {
                _context.admins.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(admin);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Categories category)
        {
            if (ModelState.IsValid)
            {
                category.admin_id = 1;
                _context.categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddQuiz");
            }
            return View(category);
        }

        public IActionResult AddQuiz()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddQuiz(Quizzes quiz)
        {
            if (ModelState.IsValid)
            {
                quiz.cat_id= 1;
                _context.quizzes.Add(quiz);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddQuestion");
            }
            return View(quiz);
        }
        
        public IActionResult AddQuestion()
        {
            return View();
        }
        [HttpPost]  
        public async Task<IActionResult> AddQuestion(Questions questions)
        {
            if (ModelState.IsValid)
            {
                questions.quiz_id= 1;
                _context.questions.Add(questions);  
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(questions);
        }
    }
}
