using System.Security.Cryptography.X509Certificates;

namespace Trabalho2
{
    internal class Program
    {
        const char separador = (char)160;
        static void Main(string[] args)
        {
            List<Contato> lista_contatos = new List<Contato>();
            List<String> lista = new List<String>();
            List<String> lista2 = new List<String>();
            List<string> lista_numeros = new List<string>();

            Contato c = new Contato();


            //ler o arquivo de texto da agenda
            if (!File.Exists("agenda.txt"))
                File.Create("agenda.txt");
            lista = File.ReadAllLines("agenda.txt").ToList();


            foreach (String linha in lista)
            {

                lista2 = linha.Split(separador).ToList();
                lista_contatos.Add(baixar_lista(lista2));

            }



            Console.WriteLine("O que deseja fazer ?");
            Console.WriteLine("Add novo");
            Console.WriteLine("Editar num");
            Console.WriteLine("Ecluir con");
            Console.WriteLine("Ver contatos");

            // -- TESTE -- //
            /*lista_numeros.Add("123");
             lista_numeros.Add("456");
             lista_numeros.Add("789");

             c.nome = "Kéven";
             c.email = "Teste";
            c.telefone = lista_numeros;
            
            lista_contatos.Add(c);
            */

            foreach (Contato linha in lista_contatos)
            {
                Console.Write(linha.nome + " " + linha.email + " ");

                foreach (string tel in linha.telefone)
                {
                    Console.Write(tel + "");
                }
                Console.WriteLine();
            }

            //-- Novo contato -- //
            /* Console.WriteLine("Nome:");
             c.nome = Console.ReadLine();
             Console.WriteLine("E-mail:");
             c.email = Console.ReadLine();
             Console.WriteLine("Número de telefone (1):");
             lista_numeros.Add(Console.ReadLine());
             int sair = 1;
             string add_nv = "";
             while(sair != 0)
             {
                 Console.WriteLine("Deseja adicionar outro número ? (s/n)");
                 add_nv = Console.ReadLine();


                     if (add_nv.Equals("s"))
                     {
                         Console.WriteLine("Novo número:");
                         lista_numeros.Add(Console.ReadLine());
                     }
                     else if(add_nv.Equals("n"))
                     {
                     Console.WriteLine("Ok!");
                         sair = 0;
                     }

                 else
                 {
                     Console.WriteLine("Digite uma resposta valida!");

                 }

                 }
            c.telefone = lista_numeros;
             lista_contatos.Add(c);
            */




            /* Excluir contato

          Contatos excluiu =  lista_contatos.Find(item => item.nome == "nome");
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


          // EXIBIR CONTATOS
            
          
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
        public static Contato baixar_lista(List<string> lista)
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
