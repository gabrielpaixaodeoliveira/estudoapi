using EstudoRepository.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoRepository.Repositories
{
    public class PessoaRepository
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PICHAU\\Documents\\EstudoApi\\EstudoApi\\EstudoRepository\\estudodb.mdf;Integrated Security=True;Connect Timeout=30";
        public void Adicionar(Pessoa pessoa)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int ativo = pessoa.Ativo ? 1 : 0;
                String query = $@"INSERT INTO TB_PESSOA
                                  (Nome, Cpf, DtNascimento, Email, Telefone, Celular, Ativo)
                                VALUES( 
                                    '{pessoa.Nome}',
                                    '{pessoa.Cpf}',
                                    '{pessoa.DtNascimento.ToString("yyyy-MM-dd")}',
                                    '{pessoa.Nome}',
                                    '{pessoa.Telefone}',
                                    '{pessoa.Telefone}',
                                     {ativo})";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                }
            }
        }
        public void Atualizar(Pessoa pessoa)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query = $@"UPDATE TB_PESSOA
                                  SET 
                                    Nome = '{pessoa.Nome}',
                                    Cpf = '{pessoa.Cpf}',
                                    DtNascimento = '{pessoa.DtNascimento.ToString("yyyy-MM-dd")}',
                                    Email = '{pessoa.Email}',
                                    Telefone = '{pessoa.Telefone}',
                                    Celular = '{pessoa.Telefone}',
                                    Ativo = 0
                                WHERE Id = {pessoa.Id}";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                }
            }

        }
        public List<Pessoa> ListarPessoa()
        {
            List<Pessoa> retorno = new List<Pessoa>();
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                String query = "SELECT * from TB_PESSOA";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Pessoa pessoa = new Pessoa();
                        pessoa.Id = Convert.ToInt32(reader["Id"]);
                        pessoa.Nome = reader["Nome"].ToString();
                        pessoa.Cpf = reader["Cpf"].ToString();
                        pessoa.DtNascimento = Convert.ToDateTime(reader["DtNascimento"]);
                        pessoa.Email = reader["Email"].ToString();
                        pessoa.Telefone = reader["Telefone"].ToString();
                        pessoa.Celular = reader["Celular"].ToString();
                        pessoa.Ativo = Convert.ToBoolean(reader["Ativo"]);
                        retorno.Add(pessoa);
                    }
                    reader.Close();
                }
            }

            return retorno;
        }
        public Pessoa ObterPorId(int id)
        {
            Pessoa retorno = new Pessoa();
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                String query = $"SELECT * from TB_PESSOA WHERE ID = {id}";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        retorno.Id = Convert.ToInt32(reader["Id"]);
                        retorno.Nome = reader["Nome"].ToString();
                        retorno.Cpf = reader["Cpf"].ToString();
                        retorno.DtNascimento = Convert.ToDateTime(reader["DtNascimento"]);
                        retorno.Email = reader["Email"].ToString();
                        retorno.Telefone = reader["Telefone"].ToString();
                        retorno.Celular = reader["Celular"].ToString();
                        retorno.Ativo = Convert.ToBoolean(reader["Ativo"]);
                    }
                    reader.Close();
                }
            }
            return retorno;
        }
        public void Excluir(int id)
        {

        }
    }
}
