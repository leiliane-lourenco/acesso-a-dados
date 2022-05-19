using AcessoADados.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AcessoADados.Repository
{
    class UsuarioRepository : BaseRepository
    {
        public UsuarioRepository()
        {

        }
        public Usuario ObterPorCpf(string cpf)
        {
            string querySql = $" SELECT  ID, NOME, CPF, EMAIL, ENDERECO FROM USUARIO WHERE  CPF = '{cpf}' ";
            SqlDataReader dadosDoBanco = ExecutarSelect(querySql);
            Usuario usuario = null;

            while (dadosDoBanco.Read())
            {
                usuario = CriarUsuario(dadosDoBanco);                
            }
            dadosDoBanco.Close();

            return usuario;
        }
        public List<Usuario> ObterTodos()
        {
            string querySql = $" SELECT ID, NOME, CPF, EMAIL, ENDERECO FROM USUARIO ";

            SqlDataReader dadosDoBanco = ExecutarSelect(querySql);

            List<Usuario> listaDeUsuarios = new List<Usuario>();

            while (dadosDoBanco.Read())
            {
                Usuario usuario = CriarUsuario(dadosDoBanco);

                listaDeUsuarios.Add(usuario);

            }
            dadosDoBanco.Close();
           
            return listaDeUsuarios;

        }
        private Usuario CriarUsuario(SqlDataReader dadosDoBanco)
        {
           
            Guid id = Guid.Parse(dadosDoBanco.GetValue(0).ToString());
            string nomeUsuario = dadosDoBanco.GetValue(1).ToString();
            string cpfUsuario = dadosDoBanco.GetValue(2).ToString();
            string emailUsuario = dadosDoBanco.GetValue(3).ToString();
            string endereçoUsuario = dadosDoBanco.GetValue(4).ToString();

            Usuario usuario = new Usuario(id, nomeUsuario, cpfUsuario, emailUsuario, endereçoUsuario);
            return (usuario);
        }
        public bool Inserir(Usuario usuario)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexao);

            string querySql = $"INSERT INTO USUARIO" +
                              $" VALUES ('{usuario.Id}'," +
                              $"         '{usuario.Nome}', " +
                              $"         '{usuario.Cpf}'," +
                              $"         '{usuario.Email}', " +
                              $"         '{usuario.Endereco}')";

            ExecutarQuery(querySql);
            return true;
        }
        public bool Alterar(Usuario usuario)
        {
            string querySql = $"UPDATE USUARIO " +
                              $" SET NOME = '{usuario.Nome}'," +
                              $" ENDERECO = '{usuario.Endereco}', " +
                              $"     EMAIL ='{usuario.Email}' " +
                              $" WHERE  " +
                              $"       ID = '{usuario.Id}' " +
                              $" AND " +
                              $"      CPF = '{usuario.Cpf}' ";

            ExecutarQuery(querySql);
            return true;
        }
        public bool Excluir(Usuario usuario)
        {
            string querySql = $" DELETE FROM USUARIO " +
                              $" WHERE " +
                              $" ID = '{usuario.Id}' ";


            ExecutarQuery(querySql);
            return true;
        }


    }
}
