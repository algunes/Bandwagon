using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bandwagon.Models;
using Bandwagon.Data;
using AutoMapper;
using Bandwagon.DTOs;

namespace Bandwagon.Controllers 
{
    // api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase 
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;   
            _mapper = mapper;                     
        }
        
        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            if(commandItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commandItems));
            }
            else
            {
                return NotFound();
            }

        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDTO> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDTO>(commandItem));
            }
            else
            {
                return NotFound();
            }
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCretaeDTO)
        {
            if(commandCretaeDTO != null)
            {
                var commandModel = _mapper.Map<Command>(commandCretaeDTO);
                _repository.CreateCommand(commandModel);
                _repository.SaveChanges();

                var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);
                
                //return Ok(commandReadDTO);

                return CreatedAtRoute(nameof(GetCommandById), new {Id=commandReadDTO.Id}, commandReadDTO);
            }
            else
            {
                return NotFound();
            }
        }

    }
}