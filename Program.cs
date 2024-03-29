using System.Security.Cryptography.X509Certificates;

namespace Trabalho2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contatos c = new Contatos();
            List<Contatos> lista_contatos = new List<Contatos>();

            string? nom, numer;

            //Inserir dados
            /*nom = Console.ReadLine();
            numer = Console.ReadLine();

            c.adicionar(nom, numer);
            lista_contatos.Add(c);

            Console.WriteLine(c.nome + " " +  c.telefone);

            //Editar dados
            Console.WriteLine("Nome Antigo: " + c.nome);
            Console.Write("Nome Novo: ");
            nom = Console.ReadLine();

            Console.WriteLine("\nTelefone Antigo: " + c.telefone);
            Console.Write("Telefone Novo: ");
            numer = Console.ReadLine();

            c.editar(nom, numer);
            //Fim editar dados*/

            
            lista_contatos.Add(novo("Kéven","999"));
            lista_contatos.Add(novo("Link", "888"));
           //Procurar na list
            lista_contatos.Find();
         
            foreach (Contatos x in lista_contatos)
            {
                Console.WriteLine(x.nome + " " + x.telefone);
            }
            
            
            
        }
        public static Contatos novo(String nome, String numero){
            Contatos c = new Contatos(nome, numero);
            return c;
        }
       
       
    }

}
