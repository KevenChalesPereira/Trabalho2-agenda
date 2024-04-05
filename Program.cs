using System.Security.Cryptography.X509Certificates;

namespace Trabalho2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contatos c = new Contatos("Teste","123456789");
            List<Contatos> lista_contatos = new List<Contatos>();

            string? nom, numer;


            //Inserir dados
            /*nom = Console.ReadLine();
            numer = Console.ReadLine();

            c.adicionar(nom, numer);
            lista_contatos.Add(c);

            Console.WriteLine(c.nome + " " +  c.telefone);*/


            /* Editar dados
            Console.WriteLine("Nome Antigo: " + c.nome);
            Console.Write("Nome Novo: ");
            nom = Console.ReadLine();

            Console.WriteLine("\nTelefone Antigo: " + c.telefone);
            Console.Write("Telefone Novo: ");
            numer = Console.ReadLine();

            c.editar(nom, numer);
            Fim editar dados*/

            /* Excluir contato

          Contatos excluiu =  lista_contatos.Find(item => item.nome == "nome" && item.telefone == "tel");
            excluiu.excluir();
            */

            /* Fazer a parte de leitura do arquivo
            StreamReader sr = new StreamReader("agenda.txt");
            sr.ReadLine();
            */

            lista_contatos.Add(novo("Kéven","999"));
            lista_contatos.Add(novo("Link", "888"));
            lista_contatos.Add(c);

           /*
            *  Criação e escrita de arquivo
            StreamWriter sw = new StreamWriter("agenda.txt", false);
            
            foreach(Contatos contato in lista_contatos)
            {
                sw.WriteLine(contato.nome);
                sw.WriteLine(contato.telefone);
                sw.WriteLine(" ");
            }

            sw.Close();
           */

          

            //Procurar na list
            /*Where retorna uma lista com os objetos encontrados, salvar em uma variavel do mesmo tipo de dados e utilizar o foreach para exibir os valores
              string pesquisa = Console.ReadLine();
              List<Contatos> list_encotrados =  lista_contatos.Where(item => item.nome.ToLower().Contains(pesquisa.ToLower())).ToList();

               foreach (Contatos x in list_encotrados)
               {
                   Console.WriteLine(x.nome + " " + x.telefone);
               }

               */

        }
        public static Contatos novo(String nome, String numero){
            Contatos c = new Contatos(nome, numero);
            return c;
        }
       
       
    }

}
