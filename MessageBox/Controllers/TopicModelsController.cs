using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MessageBox.Data;
using MessageBox.Models;

namespace MessageBox.Controllers
{
  public class TopicModelsController : Controller
  {
    private readonly ApplicationDbContext _context;

    public TopicModelsController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: TopicModels
    public async Task<IActionResult> Index()
    {
      return View(await _context.Topics.ToListAsync());
    }

    // GET: TopicModels/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var topicModel = await _context.Topics
          .FirstOrDefaultAsync(m => m.Id == id);
      if (topicModel == null)
      {
        return NotFound();
      }

      return View(topicModel);
    }

    // GET: TopicModels/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: TopicModels/Create
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

    // GET: TopicModels/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var topicModel = await _context.Topics.FindAsync(id);
      if (topicModel == null)
      {
        return NotFound();
      }
      return View(topicModel);
    }

    // POST: TopicModels/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,TopicName,AdminsOnly")] TopicModel topicModel)
    {
      if (id != topicModel.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(topicModel);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!TopicModelExists(topicModel.Id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(topicModel);
    }

    // GET: TopicModels/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var topicModel = await _context.Topics
          .FirstOrDefaultAsync(m => m.Id == id);
      if (topicModel == null)
      {
        return NotFound();
      }

      return View(topicModel);
    }

    // POST: TopicModels/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var topicModel = await _context.Topics.FindAsync(id);
      if (topicModel != null)
      {
        _context.Topics.Remove(topicModel);
      }

      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool TopicModelExists(int id)
    {
      return _context.Topics.Any(e => e.Id == id);
    }
  }
}
