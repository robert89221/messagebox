
//  Topic controller

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBox.Data;


namespace MessageBox.Controllers
{
  public class ViewForumController : Controller
  {
    private readonly ApplicationDbContext _context;

    public ViewForumController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: ViewForum/Index/1003
    // Render topic view
    public async Task<IActionResult> Index(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      //  Include all messages and poster data in query
      var topicModel = await _context.Topics.Include(t => t.Messages).ThenInclude(m => m.Poster).FirstOrDefaultAsync(m => m.Id == id);
      if (topicModel == null)
      {
        return NotFound();
      }

      return View(topicModel);
    }


    // POST: ViewForum/Delete/5
    // Delete a post
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete([FromForm] int ParentTopicId, int id)
    {
      var messageModel = await _context.Messages.FindAsync(id);
      if (messageModel != null)
      {
        _context.Messages.Remove(messageModel);
      }

      await _context.SaveChangesAsync();

      //  Redirect to topic view
      return Redirect($"~/ViewForum/Index/{ParentTopicId}");
    }

  }
}
