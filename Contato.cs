using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho2
{
    internal class Contato
    {
        /* objetos com valores nulos são invalidos e não vão para o arquivo*/
        public String? nome { get; set; } 
        public String? email { get; set; }
        public List<String>? telefone { get; set; } 


        public Contato()
        {
            
        }
        public Contato(string nome, string email, List<string> telefone)
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            
        }

        public void excluir()
        {
            this.nome = null;
            this.telefone = null;
            this.email = null;
            Console.Clear();
            Console.WriteLine("Contato excluido com sucesso!");
        }
    }

 
}
