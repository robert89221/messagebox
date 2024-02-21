
namespace MessageBox.Models
{
  public class MessageModel
  {
    public int Id { get; set; }

    public string? Title { get; set; }
    public string? Text { get; set; }
    public DateTime Date { get; set; }

    public TopicModel? ParentTopic { get; set; }
  }
}
