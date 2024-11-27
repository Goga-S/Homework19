using Data;
using Homework19_EFcore.Validation;
using Homework20_EFcore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Model;

namespace Homework20_EFcore.Controllers
{
    [ApiController]
    [Route("api")]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _repo;
        public TaskController(ITaskRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("AddTask")]
        public async Task<IActionResult> AddTask(Tasks task)
        {
            var validator = new TaskAddValidation();
            var validation = validator.Validate(task);
            if (validation.IsValid)
            {
                var result = _repo.AddTask(task);
                if (result == 0)
                {
                    return NotFound("Person for that Id does not exist, please indicate valid Id!");
                }
                else
                    return Ok($"Task number: {result} has been registered!");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("AddPerson")]
        public async Task<IActionResult> AddPerson(Person person)
        {
            var validator = new PersonAddValidation();
            var validation = validator.Validate(person);
            if (validation.IsValid)
            {
                var result = _repo.AddPerson(person);

                return Ok($"Person with Id: {result} has been registered!");
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpDelete("deleteTask")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = _repo.DeleteTask(id);
            if (result == 0)
            {
                return NotFound(id);
            }
            else
            {

                return Ok($"Task number: {id} has been deleted!");
            };
        }

        [HttpPut("updateTask")]
        public async Task<IActionResult> UpdateTask(Tasks task)
        {
            var validator = new TaskEditValidationcs();
            var validation = validator.Validate(task);
            if (validation.IsValid)
            {
                var result = _repo.UpdateTask(task);
                if (result == 0) { return NotFound(task.Id); }
                else { return Ok($"Task number {result} has been updated"); }

            }
            else
            {
                return BadRequest();
            }

            
        }
        [HttpGet("getAllTasks")]

        public async Task<IActionResult> getAllTasks()
        {
            var result = _repo.GetAllTasks();
            if(result == null)
            {
                return NoContent();
            } else
            return Ok();
        }


        [HttpDelete("deleteAllTask")]

        public async Task<IActionResult> DeleteAllTasks(bool status)
        {
            var result = _repo.DeleteAllTasks(status);
            if (result == 0)
            {
                return NotFound();
            } else
            {
                return Ok(result);
            }
        }
    }

}
