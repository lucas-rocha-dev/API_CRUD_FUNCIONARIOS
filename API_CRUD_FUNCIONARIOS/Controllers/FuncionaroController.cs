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

        [HttpGet("GetFuncionaro")]
        public async Task<ActionResult<Response<Funcionario>>> FuncionariGet()
        {
            var response = await _service.FuncionariGet();

            return Ok(response);

        }
    }
}
