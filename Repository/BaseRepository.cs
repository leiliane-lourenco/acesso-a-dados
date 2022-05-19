using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AcessoADados.Repository  //adonete
{
    public abstract class BaseRepository
    {
        protected string Conexao = @"Data Source=LEILIANE-PC\SQL2019;Initial Catalog=Curso_Csharp;User ID=sa;Password=123";
         

        public void ExecutarQuery (string querySql)
        {
            SqlConnection ConexaoComBanco = new SqlConnection(Conexao);      
            SqlCommand comandoExecutadoNoBanco = new SqlCommand(querySql, ConexaoComBanco);
            ConexaoComBanco.Open();
            comandoExecutadoNoBanco.ExecuteNonQuery();
            ConexaoComBanco.Close();
        }
        public SqlDataReader ExecutarSelect(string querySql)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexao);
            SqlCommand command = new SqlCommand(querySql, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dadosDoBanco = command.ExecuteReader();
            return dadosDoBanco;
        }
             

    }
}
