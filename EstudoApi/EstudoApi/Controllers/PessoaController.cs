using EstudoRepository.Entities;
using EstudoService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EstudoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Pessoa> Get()
        {
            PessoaService service = new PessoaService();
            var pessoa = service.Listar();
            return pessoa;
        }

        [HttpGet("{id}")]
        public Pessoa Get(int id)
        {
            PessoaService service = new PessoaService();
            var pessoa = service.ObterPorId(id);
            return pessoa;
        }

        [HttpPost]
        public void Post(Pessoa pessoa)
        {
            PessoaService service = new PessoaService();
             service.Adicionar(pessoa);
        }

        [HttpPut("{id}")]
        public void Put(int id, Pessoa pessoa)
        {
            PessoaService service = new PessoaService();
            pessoa.Id = id;
            service.Atualizar(pessoa);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
