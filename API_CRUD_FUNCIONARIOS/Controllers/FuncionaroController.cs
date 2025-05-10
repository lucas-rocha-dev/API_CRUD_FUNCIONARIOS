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
        public ActionResult<Response<Funcionario>> CreateFuncionario(Funcionario funcionario)
        {
           var response = _service.CreateFuncionario(funcionario);

            return response;

        }

        [HttpGet("GetFuncionaro")]
        public ActionResult<Response<Funcionario>> FuncionariGet()
        {
            var response = _service.FuncionariGet();

            return Ok(response);

        }
    }
}
