using AutoMapper;
using MessageService.Models;

namespace MessageService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MessageRequest, Message>();
            CreateMap<MessageResponse, Message>().ReverseMap();
        }
    }
}
