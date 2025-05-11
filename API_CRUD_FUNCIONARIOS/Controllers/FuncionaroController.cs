using API_CRUD_FUNCIONARIOS.Context;
using API_CRUD_FUNCIONARIOS.Models;
using API_CRUD_FUNCIONARIOS.Models.Entities;
using API_CRUD_FUNCIONARIOS.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD_FUNCIONARIOS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionaroController : ControllerBase
    {
        private readonly IFuncionarioService _service;

        public FuncionaroController(IFuncionarioService service) {
            _service = service;
        }


        [HttpPost("CreateFuncionario")]
        public async Task<ActionResult<Response<Funcionario>>> CreateFuncionario(Funcionario funcionario)
        {
           var response = await _service.CreateFuncionario(funcionario);

            return Ok(response);

        }

        [HttpGet("GetAllFuncionarios")]
        public async Task<ActionResult<Response<Funcionario>>> GetAllFuncionarios()
        {
            var response = await _service.GetAllFuncionarios();

            return Ok(response);

        }
        [HttpGet("GetPerId")]
        public async Task<ActionResult<Response<Funcionario>>> GetPerId(int id)
        {
            var response = await _service.GetPerId(id);
            return Ok(response);
        }

        [HttpDelete("DeletePerId")]
        public async Task<ActionResult> DeletePerId(int id) {
            var respostas = await _service.DeletePerId(id);
            return Ok(respostas);
        
        }
    }
}
