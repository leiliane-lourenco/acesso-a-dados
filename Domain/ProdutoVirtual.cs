﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoADados.Domain
{
    public class ProdutoVirtual
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Tipo { get; set; }

        public ProdutoVirtual(string codigo, string descricao, decimal preco, string tipo)
        {
            Id = Guid.NewGuid();
            Codigo = codigo;
            Descricao = descricao;
            Preco = preco;
            Tipo = tipo;
        }
        public ProdutoVirtual(Guid id, string codigo, string descricao, decimal preco, string tipo)
        {
            Id = id;
            Codigo = codigo;
            Descricao = descricao;
            Preco = preco;
            Tipo = tipo;
        }
    }
}
