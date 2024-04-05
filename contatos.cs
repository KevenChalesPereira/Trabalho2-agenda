using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho2
{
    internal class Contatos
    {
        /* objetos com valores nulos são invalidos e não vão para o arquivo*/
        public String? nome { get; set; } 
        public String? telefone { get; set; } 


        public Contatos()
        {
            
        }
        public Contatos(string nome, string telefone)
        {
            this.nome = nome;
            this.telefone = telefone;
            
        }

   

        public void editar( string n_nome, string n_telefone)
        {
            this.nome = n_nome;
            this.telefone = n_telefone;
        }
        public void excluir()
        {
            this.nome = null;
            this.telefone = null;
        }
    }

 
}
