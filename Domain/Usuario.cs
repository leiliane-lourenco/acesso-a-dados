using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoADados.Domain
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public Usuario(string nome, string cpf, string email, string endereco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Endereco = endereco;
        }
        public Usuario(Guid id, string nome, string cpf, string email, string endereco)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Endereco = endereco;
        }


    }
}
