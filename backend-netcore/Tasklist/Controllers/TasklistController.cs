using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasklist.Domain.DTO;
using Tasklist.Domain.Interfaces;
using Tasklist.Domain.Validations;

namespace Tasklist.API.Controllers
{
    [Route("api/[controller]")]
    public class TasklistController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly DbContext _unitOfWork;

        public TasklistController(ITaskService taskService, DbContext context)
        {
            _taskService = taskService;
            _unitOfWork = context;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_taskService.Listar());
            }
            catch (EntityValidationException e)
            {
                return BadRequest(e.Erros);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]TaskDto value)
        {
            //DbContext é injetado como scoped. Então caso se faça necessário o uso de transactions,
            //basta usar _unitOfWork.Database.BeginTransaction(); e _unitOfWork.Database.CommitTransaction();
            try
            {
                return Ok(_taskService.Cadastrar(value));
            }
            catch (EntityValidationException e)
            {
                return BadRequest(e.Erros);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TaskDto value)
        {
            try
            {
                return Ok(_taskService.Atualizar(id, value));
            }
            catch (EntityValidationException e)
            {
                return BadRequest(e.Erros);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }

        [HttpPut("AlterarStatus/{id}")]
        public IActionResult AlterarStatus(int id)
        {
            try
            {
                return Ok(_taskService.AlterarStatus(id));
            }
            catch (EntityValidationException e)
            {
                return BadRequest(e.Erros);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_taskService.Apagar(id));
            }
            catch (EntityValidationException e)
            {
                return BadRequest(e.Erros);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }
    }
}
