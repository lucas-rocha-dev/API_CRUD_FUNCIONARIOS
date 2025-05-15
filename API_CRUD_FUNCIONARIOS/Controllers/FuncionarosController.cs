using API_CRUD_FUNCIONARIOS.Context;
using API_CRUD_FUNCIONARIOS.Dto;
using API_CRUD_FUNCIONARIOS.Models;
using API_CRUD_FUNCIONARIOS.Models.Entities;
using API_CRUD_FUNCIONARIOS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace API_CRUD_FUNCIONARIOS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarosController : ControllerBase
    {
        private readonly IFuncionarioService _service;

        public FuncionarosController(IFuncionarioService service) {
            _service = service;
        }


        [HttpPost]
        public async Task<ActionResult<Response<Funcionario>>> CreateFuncionario([FromBody] FuncionarioCreateDto funcionario)
        {
           var response = await _service.CreateFuncionario(funcionario);

            return Ok(response);

        }

        [HttpGet]
        public async Task<ActionResult<Response<Funcionario>>> GetAll()
        {
            var response = await _service.GetAllFuncionarios();

            return Ok(response);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Funcionario>>> GetById(int id)
        {
            var response = await _service.GetById(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            var respostas = await _service.Delete(id);
            return Ok(respostas);
        
        }
        [HttpPut]
        public async Task<ActionResult> EditById(Funcionario funcionario)
        {
            var respostas = await _service.EditById(funcionario);
            return Ok(respostas);
        }
    }
}
