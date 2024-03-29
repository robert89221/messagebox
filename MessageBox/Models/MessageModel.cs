﻿
using Microsoft.AspNetCore.Identity;

namespace MessageBox.Models
{
  public class MessageModel
  {
    public int Id { get; set; }

    public string? Title { get; set; }
    public string? Text { get; set; }
    public DateTime Date { get; set; }

    //  Related data

    public IdentityUser? Poster { get; set; }
    public TopicModel? ParentTopic { get; set; }
  }
}
