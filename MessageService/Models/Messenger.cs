using AutoMapper;

namespace MessageService.Models
{
    public class Messenger
    {
        public static List<Message> Messages1 { get; set; } = new List<Message>();

        private static Dictionary<int, Queue<Message>> Messages = new Dictionary<int, Queue<Message>>();

        public static bool SendMessage(Message message)
        {
            foreach (var recipient in message.Recipients)
            {
                if (Messages.TryGetValue(recipient, out var recipientMessages))
                {
                    recipientMessages.Enqueue(message);
                }
                else
                {
                    Messages.Add(recipient, new Queue<Message>(new[] { message }));
                }
            }

            return true;
        }

        public static bool SendMessages(List<Message> messages)
        {
            foreach (var message in messages)
            {
                foreach (var recipient in message.Recipients)
                {
                    if (Messages.TryGetValue(recipient, out var recipientMessages))
                    {
                        recipientMessages.Enqueue(message);
                    }
                    else
                    {
                        Messages.Add(recipient, new Queue<Message>(new[] { message }));
                    }
                }
            }

            return true;
        }

        public static Message RecieveMessage(int recipeintId)
        {
            try
            {
                if (Messages.TryGetValue(recipeintId, out var recipientMessages))
                {
                    return recipientMessages.Dequeue();
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }

        public static IEnumerable<Message> RecieveMessages(int recipeintId)
        {
            try
            {
                if (Messages.TryGetValue(recipeintId, out var recipientMessages))
                {
                    return recipientMessages.AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }
    }
}
