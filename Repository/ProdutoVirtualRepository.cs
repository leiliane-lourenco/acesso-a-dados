using AcessoADados.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AcessoADados.Repository
{
    public class ProdutoVirtualRepository : BaseRepository
    {
        public ProdutoVirtualRepository()
        {

        }
        public List<ProdutoVirtual> ObterTodos()
        {
            SqlConnection conexao = new SqlConnection(Conexao);
            string querySql = $"SELECT  ID, CODIGO, DESCRICAO, PRECO, TIPO FROM PRODUTO_VIRTUAL";

            SqlCommand command= new SqlCommand(querySql, conexao);

            conexao.Open();
            SqlDataReader dadosDoBanco = command.ExecuteReader();

            List<ProdutoVirtual> listaDeProdutosVt = new List<ProdutoVirtual>();

            ProdutoVirtual produtoVt = null;

            while (dadosDoBanco.Read())
            {
                Guid id = Guid.Parse(dadosDoBanco.GetValue(0).ToString());
                string codigoProdutoVt = dadosDoBanco.GetValue(1).ToString();
                string descricaoProdutoVt = dadosDoBanco.GetValue(2).ToString();
                decimal precoProdutoVt = decimal.Parse(dadosDoBanco.GetValue(3).ToString());
                string tipoProdutoVt = dadosDoBanco.GetValue(4).ToString();

                produtoVt = new ProdutoVirtual(id, codigoProdutoVt, descricaoProdutoVt, precoProdutoVt, tipoProdutoVt);

                listaDeProdutosVt.Add(produtoVt);
            }
            dadosDoBanco.Close();
            conexao.Close();
            return listaDeProdutosVt;
        }
        public ProdutoVirtual ObterPorCodigo (string codigo)
        {
            SqlConnection conexao = new SqlConnection(Conexao);

            string querySql = $"SELECT ID, CODIGO, DESCRICAO, PRECO, TIPO FROM PRODUTO_VIRTUAL WHERE CODIGO = 'E22' ";

            SqlCommand command = new SqlCommand(querySql, conexao);
            conexao.Open();
            SqlDataReader dadosDoBanco = command.ExecuteReader();

            ProdutoVirtual produtoVt = null;
            while (dadosDoBanco.Read())
            {
                Guid id = Guid.Parse(dadosDoBanco.GetValue(0).ToString());
                string codigoProdutoVt = dadosDoBanco.GetValue(1).ToString();
                string descricaoProdutoVt = dadosDoBanco.GetValue(2).ToString();
                decimal precoProdutoVt = decimal.Parse(dadosDoBanco.GetValue(3).ToString());
                string tipoProdutoVt = dadosDoBanco.GetValue(4).ToString();

                produtoVt = new ProdutoVirtual(id, codigoProdutoVt, descricaoProdutoVt, precoProdutoVt, tipoProdutoVt);
            }
            dadosDoBanco.Close();
            conexao.Close();
            return produtoVt;
        }
        public bool Inserir (ProdutoVirtual produtoVt)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexao);

            string querySql = $"INSERT INTO  PRODUTO_VIRTUAL" +
                              $" VALUES ('{produtoVt.Id}', " +
                              $"         '{produtoVt.Codigo}', " +
                              $"         '{produtoVt.Descricao}', " +
                              $"          {produtoVt.Preco}, " +
                              $"         '{produtoVt.Tipo}') ";

            ExecutarQuery(querySql);
            return true;
        }
        public bool Alterar(ProdutoVirtual produtoVt)
        {
            string querySql = $" UPDATE PRODUTO_VIRTUAL " +
                              $"SET DESCRICAO = '{produtoVt.Descricao}' " +
                              $"WHERE " +
                              $"           ID = '{produtoVt.Id}' " +
                              $"AND " +
                              $"       CODIGO = '{produtoVt.Codigo}' ";

            ExecutarQuery(querySql);
            return true;
        }
        public bool Excluir(ProdutoVirtual produtoVt)
        {

            string querySql = $"DELETE FROM PRODUTO_VIRTUAL " +
                              $"WHERE  " +
                              $"ID = '{produtoVt.Id}'";

            ExecutarQuery(querySql);
            return true;

        }




    }
}

