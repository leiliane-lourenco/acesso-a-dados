using AcessoADados.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AcessoADados.Repository  //macoratti.net
{
    public class ProdutoRepository : BaseRepository
    {
        public ProdutoRepository()
        {

        }
        public List<Produto> ObterTodos()
        {           
            string querySql = $"SELECT ID, CODIGO, DESCRICAO, PRECO, TIPO FROM PRODUTO";

            SqlDataReader dadosDoBanco = ExecutarSelect(querySql);

            List<Produto> listaDeProdutos = new List<Produto>();
            Produto produto = null;

            while (dadosDoBanco.Read())
            {
                produto = CriarProduto(dadosDoBanco);
                listaDeProdutos.Add(produto);
            }
            dadosDoBanco.Close();
            //conexao.Close();
            return listaDeProdutos;

        }        
        public Produto ObterPorCodigo(string codigo)
        {
            string querySql = $" SELECT ID, CODIGO, DESCRICAO, PRECO, TIPO FROM PRODUTO WHERE CODIGO = '{codigo}' ";

            SqlDataReader dadosDoBanco = ExecutarSelect(querySql);

            Produto produto = null;
            while (dadosDoBanco.Read())
            {
                produto = CriarProduto(dadosDoBanco); 
            }
            dadosDoBanco.Close();
            //conexao.Close();

            return produto;
        }
        private Produto CriarProduto(SqlDataReader dadosDoBanco)
        {
            Guid id = Guid.Parse(dadosDoBanco.GetValue(0).ToString());
            string codigoProduto = dadosDoBanco.GetValue(1).ToString();
            string descricaoProduto = dadosDoBanco.GetValue(2).ToString();
            decimal precoProduto = decimal.Parse(dadosDoBanco.GetValue(3).ToString());
            string tipoProduto = dadosDoBanco.GetValue(4).ToString();

            Produto produto = new Produto(id, codigoProduto, descricaoProduto, precoProduto, tipoProduto);
            return (produto);
        }
        public bool Inserir(Produto produto)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexao);

            string querySql = $"INSERT INTO PRODUTO" +
                              $" VALUES ('{produto.Id}'," +
                              $"         '{produto.Codigo}', " +
                              $"         '{produto.Descricao}'," +
                              $"          {produto.Preco}, " +
                              $"         '{produto.Tipo}')";

            ExecutarQuery(querySql);
            return true;
        }
        public bool Alterar(Produto produto)
        {
            string querySql = $" UPDATE PRODUTO " +
                               $" SET DESCRICAO = '{produto.Descricao}', " +
                               $"         PRECO = {produto.Preco}," +
                               $"          TIPO = '{produto.Tipo}' " +
                               $"WHERE " +
                               $"            ID = '{produto.Id}' " +
                               $"AND " +
                               $"        CODIGO = '{produto.Codigo}'";

            ExecutarQuery(querySql);
            return true;
           
        }
        public bool Excluir(Produto produto)
        {
            string querySql = $"DELETE FROM PRODUTO " +
                              $"WHERE  " +
                              $"ID = '{produto.Id}'";

            ExecutarQuery(querySql);
            return true;
        }

    }
}
