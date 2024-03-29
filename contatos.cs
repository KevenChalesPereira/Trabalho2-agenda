using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho2
{
    internal class Contatos
    {
        public String nome { get; set; } = "";
        public String telefone { get; set; } = "";


        public Contatos()
        {
            
        }
        public Contatos(string nome, string telefone)
        {
            this.nome = nome;
            this.telefone = telefone;
            
        }

        public void adicionar(String nome, String telefone)
        {
        this.nome = nome;
        this.telefone = telefone;
        }

        public void editar(Contatos c, string n_nome, string n_telefone)
        {
            c.nome = n_nome;
            c.telefone = n_telefone;
        }
    }

 
}
