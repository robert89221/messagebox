
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
    public async Task<IActionResult> Index()
    {
      return View(await _context.Topics.Include("Messages").ToListAsync());
    }


    // GET: AllForums/Create
    public IActionResult Create()
    {
      return View();
    }


    // POST: AllForums/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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


    private bool TopicModelExists(int id)
    {
      return _context.Topics.Any(e => e.Id == id);
    }
  }
}
