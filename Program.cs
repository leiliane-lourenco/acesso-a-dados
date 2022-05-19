using AcessoADados.Domain;
using AcessoADados.Repository;
using System;
using System.Collections.Generic;

namespace AcessoADados //JSON VIEWER CHROME- USAR NO CRHOME
{
    class Program
    {
        //string conexao para acessar

        static void Main(string[] args)
        {
            Console.WriteLine("=========================== PRODUTO ===============================");
            Produto produto = new Produto("R1250", "Raquete", 115, "Artigos Esportivos");

            ProdutoRepository produtoRepository = new ProdutoRepository();

            produtoRepository.Inserir(produto);
            produto.Descricao = "Raquete de Ping Pong";

            produtoRepository.Alterar(produto);

            produtoRepository.Excluir(produto);

            Produto produtoBD = produtoRepository.ObterPorCodigo("B6014");
            if (produtoBD == null)
                Console.WriteLine("Produto não encontrado");
            else
                Console.WriteLine($"Produto encontrado - ID {produtoBD.Id}");
            Console.WriteLine(" ");

            List<Produto> listaDeProdutos = produtoRepository.ObterTodos();
            foreach (Produto produtos in listaDeProdutos)
            {
                Console.WriteLine($" ID: {produtos.Id} CÓDIGO:{produtos.Codigo }  DESCRIÇAO: {produtos.Descricao} ");
            }

            Console.WriteLine("=========================== USUARIO ===============================");
            Usuario usuario = new Usuario("Chris", "258", "chris@gmail", "Rua Pacificador");

            UsuarioRepository usuarioRepository = new UsuarioRepository();

            usuarioRepository.Inserir(usuario);
            usuario.Nome = "Christian";

            usuarioRepository.Alterar(usuario);

            usuarioRepository.Excluir(usuario);

            Usuario usuarioBD = usuarioRepository.ObterPorCpf("9654");
            if (usuarioBD == null)
                Console.WriteLine("CPF não encontrado");
            else
                Console.WriteLine($"CPF encontrado - ID {usuarioBD.Id}");

            List<Usuario> listaDeUsuarios = usuarioRepository.ObterTodos();
            foreach (Usuario usuarios in listaDeUsuarios)
            {
                Console.WriteLine($" ID: {usuarios.Id} CPF:{usuarios.Cpf }  NOME: {usuarios.Nome} ");
            }

            Console.WriteLine("=========================== PRODUTO VIRTUAL ===============================");
            ProdutoVirtual produtoVirtual = new ProdutoVirtual("E111", "Cidade dos Etéreos", 111, "Ebook");
            ProdutoVirtualRepository produtoVirtualRepository = new ProdutoVirtualRepository();
            produtoVirtualRepository.Inserir(produtoVirtual);
            produtoVirtual.Descricao = "Lar da Srtª Peregrine - Cidade dos Etéreos";
            produtoVirtualRepository.Alterar(produtoVirtual);
            produtoVirtualRepository.Excluir(produtoVirtual);
            Console.WriteLine($"Produto '{produtoVirtual.Descricao}' foi excluido com sucesso!! ");
            ProdutoVirtual produtoVtBD = produtoVirtualRepository.ObterPorCodigo("B444");
            if (produtoVtBD == null)
                Console.WriteLine("Produto não encontrado");
            else
                Console.WriteLine($"Produto encontrado {produtoVtBD.Id}");
            List<ProdutoVirtual> listaDeProdutosVt = produtoVirtualRepository.ObterTodos();
            foreach (ProdutoVirtual produtosVt in listaDeProdutosVt)
            {
                Console.WriteLine($" ID: {produtosVt.Id} CÓDIGO:{produtosVt.Codigo }  DESCRIÇAO: {produtosVt.Descricao} ");
            }




        }
    }
}


