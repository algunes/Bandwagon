using AutoMapper;
using Bandwagon.DTOs;
using Bandwagon.Models;

namespace Bandwagon.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source --> Target
            CreateMap<Command, CommandReadDTO>();
            CreateMap<CommandCreateDTO, Command>();
            CreateMap<CommandUpdateDTO, Command>();
            CreateMap<Command, CommandUpdateDTO>();
        }

    }
}