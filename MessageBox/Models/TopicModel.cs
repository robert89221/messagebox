
namespace MessageBox.Models
{
  public class TopicModel
  {
    public int Id { get; set; }

    public string? TopicName { get; set; }
    public bool AdminsOnly { get; set; }

    //  Related data

    public List<MessageModel> Messages { get; set; } = [];
  }
}
