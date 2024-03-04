
//  Controller for topic view

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBox.Data;
using MessageBox.Models;


namespace MessageBox.Controllers
{
  public class AllForumsController : Controller
  {
    private readonly ApplicationDbContext _context;

    public AllForumsController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: AllForums
    // Render all topics
    public async Task<IActionResult> Index()
    {
      return View(await _context.Topics.Include(t => t.Messages).ToListAsync());
    }


    // GET: AllForums/Create
    // Render view for creating a new topic
    public IActionResult Create()
    {
      return View();
    }


    // POST: AllForums/Create
    // Create new topic
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,TopicName,AdminsOnly")] TopicModel topicModel)
    {
      if (ModelState.IsValid)
      {
        _context.Add(topicModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(topicModel);
    }

  }
}
