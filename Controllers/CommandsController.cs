using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bandwagon.Models;
using Bandwagon.Data;
using AutoMapper;
using Bandwagon.DTOs;
using Microsoft.AspNetCore.JsonPatch;

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

        //PUT api/Commands/{id}
        [HttpPut("{id}")]
        public ActionResult<CommandUpdateDTO> UpdateCommand(int id, CommandUpdateDTO commandUpdateDTO)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(commandUpdateDTO, commandModelFromRepo);
                _repository.UpdateCommand(commandModelFromRepo);
                _repository.SaveChanges();

                return Ok();
            } 
        }

        //PATCH api/Commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDTO> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                var commandToPatch = _mapper.Map<CommandUpdateDTO>(commandModelFromRepo);
                patchDoc.ApplyTo(commandToPatch, ModelState);

                if(!TryValidateModel(commandToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                else
                {
                    _mapper.Map(commandToPatch, commandModelFromRepo);
                    _repository.SaveChanges();
                    return Ok();
                }
            }
        }

        //DELETE api/Commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                _repository.DeleteCommand(commandModelFromRepo);
                _repository.SaveChanges();
                return Ok();
            }
        }


    }
}