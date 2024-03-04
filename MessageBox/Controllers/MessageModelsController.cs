
//  Message controller

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBox.Data;
using MessageBox.Models;


namespace MessageBox.Controllers
{
  public class MessageModelsController : Controller
  {
    private readonly ApplicationDbContext _context;

    public MessageModelsController(ApplicationDbContext context)
    {
      _context = context;
    }


    // POST: MessageModels/Create
    // Create new message
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] int ParentTopicId, [FromForm] string PosterId, [Bind("Id,Title,Text")] MessageModel messageModel)
    {
      if (ModelState.IsValid)
      {
        //  Set timestamp, and fill in Id for the current poster and parent topic
        messageModel.Date = DateTime.Now;
        messageModel.Poster = _context.Users.Find(PosterId);
        messageModel.ParentTopic = _context.Topics.Find(ParentTopicId);
        _context.Add(messageModel);
        await _context.SaveChangesAsync();

        //  Redirect to topic view again
        return Redirect($"~/ViewForum/Index/{ParentTopicId}");
      }

      return View(messageModel);
    }

  }
}
