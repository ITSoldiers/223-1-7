using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL
{
    internal class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
