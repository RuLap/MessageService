namespace MessageService.Models
{
    public class Message
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public List<int> Recipients { get; set; }
    }
}
