using EstudoRepository.Entities;
using EstudoRepository.Repositories;

namespace EstudoService
{
    public class PessoaService
    {
        public void Adicionar(Pessoa pessoa)
        {
            PessoaRepository repo = new PessoaRepository();
            repo.Adicionar(pessoa);
        }
        public void Atualizar(Pessoa pessoa)
        {
            PessoaRepository repo = new PessoaRepository();
            repo.Atualizar(pessoa);
        }
        public List<Pessoa> Listar()
        {
            PessoaRepository repo = new PessoaRepository();
            List<Pessoa> retorno = repo.ListarPessoa();
            return retorno;
        }
        public Pessoa ObterPorId(int id)
        {
            PessoaRepository repo = new PessoaRepository();
            Pessoa retorno = repo.ObterPorId(id);
            return retorno;
        }
    }
}