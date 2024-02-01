using AutoMapper;
using MessageService.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Controllers
{
    [ApiController]
    [Route("api")]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;

        public MessageController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Route("message")]
        public IActionResult GetMessage(int recipientId)
        {
            var message = Messenger.RecieveMessage(recipientId);
            if (message == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<MessageResponse>(message);            

            return new JsonResult(result);
        }

        [HttpGet]
        [Route("messages")]
        public IActionResult GetMessages(int recipientId)
        {
            var messages = Messenger.RecieveMessages(recipientId);
            if (messages == null)
            {
                return NotFound();
            }

            var result = messages.Select(_mapper.Map<Message, MessageResponse>);          

            return new JsonResult(result);
        }

        [HttpPost]
        [Route("message")]
        public IActionResult SendMessage(MessageRequest message)
        {
            if (message is null)
            {
                return BadRequest();
            }

            Messenger.SendMessage(_mapper.Map<Message>(message));

            return Ok();
        }

        [HttpPost]
        [Route("messages")]
        public IActionResult SendMessages(List<MessageRequest> messages)
        {
            if (messages.Count == 0)
            {
                return BadRequest();
            }

            var result = new List<Message>();
            foreach (var message in messages)
            {
                if (message is null)
                {
                    return BadRequest();
                }

                result.Add(_mapper.Map<Message>(message));
            }

            Messenger.SendMessages(result);

            return Ok();
        }
    }
}