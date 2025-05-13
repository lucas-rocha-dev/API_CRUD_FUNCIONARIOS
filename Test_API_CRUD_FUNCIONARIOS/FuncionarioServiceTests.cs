using API_CRUD_FUNCIONARIOS.Context;
using API_CRUD_FUNCIONARIOS.Models.Entities;
using API_CRUD_FUNCIONARIOS.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_API_CRUD_FUNCIONARIOS
{
    [TestClass]
    public class FuncionarioServiceTests
    {


        private FuncionarioContext _context;
        private FuncionarioService _service;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<FuncionarioContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Nome único
                .Options;

            _context = new FuncionarioContext(options);
            _service = new FuncionarioService(_context);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public async Task CreateFuncionario_DeveRetornarFuncionarioCadastrado()
        {
            var funcionario = new Funcionario { NOME = "João", SALARIO = 3000, CARGO = "Dev" };

            var response = await _service.CreateFuncionario(funcionario);

            Assert.IsTrue(response.STATUS);
            Assert.IsNotNull(response.DADOS);
            Assert.AreEqual("Funcionario cadastrado", response.MENSAGEM);
        }

        [TestMethod]
        public async Task GetAllFuncionarios_DeveRetornarLista()
        {      

            await _context.Funcionarios.AddAsync(new Funcionario { NOME = "Maria", SALARIO = 4000, CARGO = "QA" });
            await _context.SaveChangesAsync();

            var response = await _service.GetAllFuncionarios();

            Assert.IsTrue(response.STATUS);
            Assert.IsTrue(response.DADOS.Count > 0);
            Assert.AreEqual("Todos funcionarios listados", response.MENSAGEM);
        }

        [TestMethod]
        public async Task GetPerId_Existente_DeveRetornarFuncionario()
        {
            var funcionario = new Funcionario { NOME = "Carlos", SALARIO = 3500, CARGO = "Analista" };
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();

            var response = await _service.GetPerId(funcionario.ID);

            Assert.IsTrue(response.STATUS);
            Assert.IsNotNull(response.DADOS);
            Assert.AreEqual("Funcionario encontrado!", response.MENSAGEM);
        }

        [TestMethod]
        public async Task GetPerId_Inexistente_DeveRetornarMensagemNaoEncontrado()
        {
            var response = await _service.GetPerId(999);

            Assert.IsTrue(response.STATUS);
            Assert.IsNull(response.DADOS);
            Assert.AreEqual("Funcionario não existe!", response.MENSAGEM);
        }

        [TestMethod]
        public async Task DeletePerId_Existente_DeveDeletarFuncionario()
        {
            var funcionario = new Funcionario { NOME = "Ana", SALARIO = 2800, CARGO = "RH" };
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();

            var response = await _service.DeletePerId(funcionario.ID);

            Assert.IsTrue(response.STATUS);
            Assert.AreEqual("Funcionario DELETADO!", response.MENSAGEM);
            Assert.IsNull(await _context.Funcionarios.FindAsync(funcionario.ID));
        }

        [TestMethod]
        public async Task DeletePerId_Inexistente_DeveRetornarMensagem()
        {
            var response = await _service.DeletePerId(12345);

            Assert.IsTrue(response.STATUS);
            Assert.IsNull(response.DADOS);
            Assert.AreEqual("Funcionario não encontrado", response.MENSAGEM);
        }

        [TestMethod]
        public async Task EditPerId_Existente_DeveEditarFuncionario()
        {
            var funcionario = new Funcionario { NOME = "Pedro", SALARIO = 5000, CARGO = "Gestor" };
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();

            funcionario.NOME = "Pedro Silva";
            funcionario.SALARIO = 5500;
            funcionario.CARGO = "Gestor Senior";

            var response = await _service.EditPerId(funcionario);

            Assert.IsTrue(response.STATUS);
            Assert.AreEqual("Funcionario Editado!", response.MENSAGEM);
            Assert.AreEqual("Pedro Silva", response.DADOS.NOME);
        }


    }
}
