namespace MessageService.Models
{
    public class MessageRequest
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public List<int> Recipients { get; set; }
    }
}
