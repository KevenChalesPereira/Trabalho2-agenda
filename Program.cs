using System.Security.Cryptography.X509Certificates;

namespace Trabalho2
{
    internal class Program
    {
        const char separador = (char)160;
        static void Main(string[] args)
        {
            List<Contato> lista_contatos = new List<Contato>();

            
            Contato c = new Contato();

            List<string> lista_numeros = new List<string>();

            if (!File.Exists("agenda.txt"))
                File.Create("agenda.txt");

            lista_numeros.Add("123");
            lista_numeros.Add("456");
            lista_numeros.Add("789");

            c.nome = "Kéven";
            c.email = "Teste";
            c.telefone = lista_numeros;
            lista_contatos.Add(c);
            /* Excluir contato

          Contatos excluiu =  lista_contatos.Find(item => item.nome == "nome" && item.telefone == "tel");
            excluiu.excluir();
            */

            // Criação e escrita de arquivo 
             StreamWriter sw = new StreamWriter("agenda.txt", true);

             foreach(Contato contato in lista_contatos)
             {
                 sw.Write(contato.nome + separador + contato.email + separador);
                 
                foreach(string telefone in contato.telefone)
                {
                    sw.Write(telefone + separador);
                }
                sw.WriteLine();
             }
            sw.Close();
            

            // StreamReader sr = new StreamReader("agenta.txt");

            List<String> lista = new List<String>();
            List<String> lista2= new List<String>();

            

            lista = File.ReadAllLines("agenda.txt").ToList();

            
            foreach(String linha  in lista) {

                lista2 = linha.Split(separador).ToList();
                lista_contatos.Add(upar_lista(lista2));

            }

            foreach(Contato linha in lista_contatos) {
                Console.WriteLine(linha.nome + " " + linha.email);

                foreach(string tel in linha.telefone)
                {
                    Console.WriteLine(tel + "");
                }
           }
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
        public static Contato upar_lista(List<string> lista)
        {
            int qtd_lista = lista.Count();
            string nome = lista[0];
            string email = lista[1];
            List<string> numeros = new List<string>();

            for(int i = 2; i < qtd_lista; i++)
            {
                numeros.Add(lista[i]);
            }
            Contato contato = new Contato(nome,email,numeros);
            
            return contato;
        }
       
       
    }

}
