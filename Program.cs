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

            


            //ler o arquivo de texto da agenda
            if (!File.Exists("agenda.txt"))
                File.Create("agenda.txt");
            lista = File.ReadAllLines("agenda.txt").ToList();


            foreach (String linha in lista)
            {

                lista2 = linha.Split(separador).ToList();
                lista_contatos.Add(baixar_lista(lista2));

            }

            int escolha_menu = -1;

            while (escolha_menu != 0)
            {
            menu:
                
                Console.WriteLine("|---MENU---|");
                Console.WriteLine("Add novo(1)");
                Console.WriteLine("Editar num(2)");
                Console.WriteLine("Ecluir con(3)");
                Console.WriteLine("Ver contatos(4)");
                Console.WriteLine("Sair(0)");
                Console.Write("O que deseja fazer ?");
                escolha_menu = int.Parse(Console.ReadLine());

                switch (escolha_menu)
                {
                    //-- Novo contato -- //
                    case 1:
                        Contato c = new Contato();
                    adicionar:
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        if (contato_existe(lista_contatos, nome) == 0)
                        {
                            c.nome = nome;
                        }
                        else
                        {
                            Console.WriteLine("Este contato já existe!");
                            goto adicionar;
                        }
                        Console.Write("E-mail:");
                        c.email = Console.ReadLine();
                        Console.Write("Número de telefone: ");
                        lista_numeros.Add(Console.ReadLine());
                        int sair = 1;
                        string add_nv = "";
                        while (sair != 0)
                        {
                            Console.Write("Deseja adicionar outro número ? (s/n)");
                            add_nv = Console.ReadLine();


                            if (add_nv.Equals("s"))
                            {
                                Console.Write("Novo número: ");
                                lista_numeros.Add(Console.ReadLine());
                            }
                            else if (add_nv.Equals("n"))
                            {
                                sair = 0;
                            }

                            else
                            {
                                Console.WriteLine("Digite uma resposta valida!");

                            }

                        }
                        c.telefone = lista_numeros;
                        lista_contatos.Add(c);
                        Console.Clear();
                        Console.WriteLine("Contato adicionado com sucesso!");
                        escrever_arquivo(lista_contatos);

                        break;

                    //Editar contato
                    case 2:
                    editar:

                        Contato editar_c;
                        string nome_editar;
                        int posicao = 0;
                        Console.Clear();
                        Console.Write("Nome do contato que deseja editar: ");
                        nome_editar = Console.ReadLine();

                        if (nome_editar.Equals("menu"))
                            goto menu;

                        editar_c = lista_contatos.Find(item => item.nome.ToLower() == nome_editar.ToLower());
                        posicao = lista_contatos.FindIndex(item => item.nome.ToLower() == nome_editar.ToLower());

                        if (editar_c != null)
                        {
                            //Editar só o nome
                            Console.WriteLine("Nome atual: " + editar_c.nome);
                            Console.Write("Novo nome: ");
                            editar_c.nome = Console.ReadLine();

                            //Editar só email
                            Console.WriteLine("E-mail atual: " + editar_c.email);
                            Console.Write("Novo email: ");
                            editar_c.email = Console.ReadLine();

                            //Editar telefones
                            int tem = 0;
                            foreach (string telefone in editar_c.telefone)
                            {
                                if (!telefone.Equals(separador) || !telefone.Equals("") || !telefone.Equals(" "))
                                {
                                    Console.WriteLine("[" + tem + "]" + telefone);
                                    tem++;
                                }
                            }
                            int indice;
                            Console.Write("Indice do telefone que deseja editar:");
                            indice = int.Parse(Console.ReadLine());
                            while (indice > tem)
                            {
                                Console.WriteLine("Numero invalido, digite novamente!");
                                indice = int.Parse(Console.ReadLine());
                            }

                            Console.WriteLine("Telefone antigo: " + editar_c.telefone[indice]);
                            Console.Write("Novo telefone:");
                            editar_c.telefone[indice] = Console.ReadLine();

                            lista_contatos[posicao] = editar_c;
                            Console.Clear();
                            Console.WriteLine("Editado com sucesso!");
                            escrever_arquivo(lista_contatos);

                        }
                        else
                        {
                            Console.WriteLine("Contato não existe, tente novamente!");
                            goto editar;
                        }
                        break;

                    //Excluir contato
                    case 3:
                    excluir:
                        Console.Write("Contato que deseja excluir:");
                        string nome_cont = Console.ReadLine();
                        Contato excluiu = lista_contatos.Find(item => item.nome.Equals(nome_cont));
                        if (nome_cont.Equals("menu"))
                        {
                            goto menu;
                        }
                        lista_contatos.Remove(excluiu);

                        if (excluiu != null)
                        excluiu.excluir();
                        else
                        {

                            Console.WriteLine("Erro ao excluir contato, tente novamente!");
                            goto excluir;
                        }
                       
                        escrever_arquivo(lista_contatos);
                        break;

                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("|---CONTATOS---|");
                        if(lista_contatos.Count() < 1)
                        {
                            Console.WriteLine("NENHUM CONTATO ENCONTRADO!");
                        }
                        foreach (Contato linha in lista_contatos)
                        {
                            Console.Write(linha.nome + " " + linha.email + " ");

                            foreach (string tel in linha.telefone)
                            {
                                Console.Write(tel + " ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("|---CONTATOS---|\n");

                        break;

                    case 0:
                        Console.WriteLine("Saindo...!");
                        break;
                }
                
            }
          
                    // Criação e escrita de arquivo 
                  

        }
        public static Contato baixar_lista(List<string> lista)
        {
            if (lista.Count() > 0)
            {
                int qtd_lista = lista.Count();
                string nome = lista[0];
                string email = lista[1];
                List<string> numeros = new List<string>();

                for (int i = 2; i < qtd_lista; i++)
                {
                    numeros.Add(lista[i]);
                }
                Contato contato = new Contato(nome, email, numeros);


                return contato;
            }
            else
                return null;
        
        }
       public static int contato_existe(List<Contato> lista_contatos, String nome)
        {
              List<Contato> list_encotrados =  lista_contatos.Where(item => item.nome.ToLower().Contains(nome.ToLower())).ToList();
            if(list_encotrados.Count > 0 )
            {
                return 1;
                //existe
            }
            else
            {
                return 0;
                //não exites
            }
            
        }

        public static void escrever_arquivo(List<Contato> lista_contatos)
        {
            StreamWriter sw = new StreamWriter("agenda.txt", false);

            foreach (Contato contato in lista_contatos)
            {
                if (contato.nome.Equals(null) || contato.nome.Equals(""))
                    return;
                else
                {
                    sw.Write(contato.nome + separador + contato.email + separador);

                    foreach (string telefone in contato.telefone)
                    {
                        sw.Write(telefone + separador);
                    }
                    sw.WriteLine();
                }
            }

            sw.Close();

        }

    }

}
