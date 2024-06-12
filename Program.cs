using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

namespace Trabalho2
{
    internal class Program
    {
        const char separador = (char)160;
        static void Main(string[] args)
        {
            List<Contato> lista_contatos = new List<Contato>();
            List<String> lista_temp1 = new List<String>();
            List<String> lista_temp2 = new List<String>();
            List<String> lista_numeros = new List<String>();

            


            //ler o arquivo de texto da agenda
            if (!File.Exists("agenda.txt"))
                File.Create("agenda.txt");
            lista_temp1 = File.ReadAllLines("agenda.txt").ToList();
            foreach (String linha in lista_temp1)
            {
                //Colocar os dados do arquivo no vetor de contatos
                lista_temp2 = linha.Split(separador).ToList();//separando as informações
                lista_contatos.Add(baixar_lista(lista_temp2));

            }

            int escolha_menu = -1;

            while (escolha_menu != 0)
            {
            menu:
                
                Console.WriteLine("|---------MENU---------|");
                Console.WriteLine(" Adicionar novo número(1)");
                Console.WriteLine(" Editar número(2)");
                Console.WriteLine(" Excluir contato(3)");
                Console.WriteLine(" Ver contatos(4)");
                Console.WriteLine(" Sair(0)");
                Console.WriteLine("-----------------------");
                Console.Write("Digite o número correspondente a função desejada:");
                string menu_dig = Console.ReadLine();


                switch (menu_dig)
                {
                    //-- Novo contato -- //
                    case "1":
                        Contato c = new Contato();
                        Console.WriteLine("Adicionando novo número");
                    adicionar:
                        
                        Console.Write("Nome: ");                       
                        string nome = Console.ReadLine();
                        //Encerra a operação e volta ao menu inicial
                        if (nome.Equals("0"))
                        {
                            Console.WriteLine("Deseja cancelar a operação (s/n):");
                            if (Console.ReadLine().Equals("s"))
                            {
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                goto adicionar;
                            }

                        }
                        //Impede o usuário de criar um nome utilizando o separador e um nome vazio
                        if (nome.Contains(separador) || nome.Equals(""))
                            Console.WriteLine("Nome inválido!");
                        //Verifica se o contato já existe
                        if (contato_existe(lista_contatos, nome) == 0)
                        {
                            c.nome = nome;
                        }
                        else
                        {
                            Console.WriteLine("Este contato já existe!");
                            goto adicionar;
                        }
                        adcEm:
                        Console.Write("E-mail:");
                        string em = Console.ReadLine();
                        //Encerra a operação e volta ao menu inicial
                        if (em.Equals("0"))
                        {
                            Console.WriteLine("Deseja cancelar a operação (s/n):");
                            if (Console.ReadLine().Equals("s"))
                            {
                                Console.Clear();
                                continue;
                            }
                            else
                                goto adcEm;
                        }
                            c.email = em;
                        adcNmt:
                        Console.Write("Número de telefone: ");
                        string num = Console.ReadLine();

                        if (num.Equals("0"))
                        {
                            Console.WriteLine("Deseja cancelar a operação (s/n):");
                            if (Console.ReadLine().Equals("s"))
                            {
                                Console.Clear();
                                continue;
                            }
                            else
                                goto adcNmt;
                        }
                        lista_numeros.Add(num);
                        
                        string add_nv = "s";
                        adc_novamente:
                        while (!add_nv.Equals("n"))
                        {
                            Console.Write("Deseja adicionar outro número ? (s/n)");
                            add_nv = Console.ReadLine();

                            if (add_nv.Equals("0"))
                            {
                                Console.WriteLine("Deseja cancelar a operação (s/n):");
                                if (Console.ReadLine().Equals("s"))
                                {
                                    Console.Clear();
                                    continue;
                                }
                                else
                                    goto adc_novamente;
                            }

                            if (add_nv.Equals("s"))
                            {

                                Console.Write("Novo número: ");
                                lista_numeros.Add(add_nv);
                            }
                            else if (add_nv.Equals("n"))
                                break;
                            

                            else
                            {
                                Console.WriteLine("Digite uma resposta valida!");

                            }

                        }
                        c.telefone = lista_numeros;
                        lista_contatos.Add(c);
                        Console.Clear();
                        Console.WriteLine("|--- CONTATO ADICIONADO! ---|");
                        escrever_arquivo(lista_contatos);

                        break;

                    //Editar contato
                    case "2":
                    editar:

                        Contato editar_c;
                        string contato_ed;
                        int posicao = 0;
                        Console.Clear();
                        menu_ed:
                        Console.Write("Nome do contato que deseja editar: ");
                        contato_ed = Console.ReadLine();

                            if (contato_ed.Equals("0"))
                            {
                                Console.WriteLine("Deseja cancelar a operação (s/n):");
                                if (Console.ReadLine().Equals("s"))
                                {
                                    Console.Clear();
                                    continue;
                                }
                                else
                                    goto menu;
                            }

                        editar_c = lista_contatos.Find(item => item.nome.ToLower() == contato_ed.ToLower());
                        posicao = lista_contatos.FindIndex(item => item.nome.ToLower() == contato_ed.ToLower());

                        if (editar_c != null)
                        {
                            //Editar nome

                            //Se o valor informado for ""(vazio) os dados não serão alterados
                            Console.WriteLine("!!! Pra excluir a imformção digite limpar !!!");
                            Console.WriteLine("Nome atual: " + editar_c.nome);
                            Console.Write("Novo nome: ");
                            string nm_ed = Console.ReadLine();

                            if (nm_ed.Equals("0"))
                            {
                                Console.WriteLine("Deseja cancelar a operação (s/n):");
                                if (Console.ReadLine().Equals("s"))
                                {
                                    Console.Clear();
                                    continue;
                                }
                                else
                                    goto menu_ed;
                            }
                            if (nm_ed.ToLower() == "limpar")
                            {
                                Console.Write("Deseja excluir o contato?(s/n)");
                                if (Console.ReadLine() == "s") {
                                    editar_c.excluir();
                                    lista_contatos.Remove(editar_c);
                                    continue;
                                }
                                else
                                    goto menu_ed;
                            }
                           else if (nm_ed == "")
                                Console.WriteLine("Valor inalterado!");

                            else
                                editar_c.nome = nm_ed;

                            //Editar email
                            Console.WriteLine("E-mail atual: " + editar_c.email);
                           
                            Console.Write("Novo email: ");
                            string em_ed = Console.ReadLine();

                            if (em_ed.Equals("0"))
                            {
                                Console.WriteLine("Deseja cancelar a operação (s/n):");
                                if (Console.ReadLine().Equals("s"))
                                {
                                    Console.Clear();
                                    continue;
                                }
                                else
                                    goto menu_ed;
                            }
                            if (em_ed.ToLower() == "limpar")
                            {
                                Console.Write("Deseja excluir a informação?(s/n)");
                                
                                    if (Console.ReadLine() == "s") { 
                                        editar_c.email = "";
                                    em_ed = "";
                                    
                                }
                                else
                                    goto menu_ed;
                            }
                               
                            if (em_ed == "")
                                Console.WriteLine("Valor inalterado!");

                            else
                                editar_c.email = em_ed;

                            //Editar telefones
                            int tem = 0;//variavel temporaria
                            foreach (string telefone in editar_c.telefone)
                            {
                                if (!telefone.Equals(""))
                                {
                                    if (!telefone.Equals(separador))
                                    {
                                        Console.WriteLine("[" + (tem + 1) + "]" + telefone);
                                        tem++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Telefone excluido!");
                                    }
                                }
                            }
                            int indice;
                            string tel_indice;
                            Console.Write("Indice do telefone que deseja editar:");
                            tel_indice = Console.ReadLine();
                            indice = 1 - int.Parse(tel_indice);

                            if (tel_indice != "0")
                            {

                                while (indice > tem)
                                {
                                    Console.WriteLine("Numero invalido, digite novamente!");
                                    indice = int.Parse(Console.ReadLine());
                                }

                                Console.WriteLine("Telefone antigo: " + editar_c.telefone[indice]);
                                Console.Write("Novo telefone:");
                                string tel_ed = Console.ReadLine();

                                if (tel_ed.Equals("0"))
                                {
                                    Console.WriteLine("Deseja cancelar a operação (s/n):");
                                    if (Console.ReadLine().Equals("s"))
                                    {
                                        Console.Clear();
                                        continue;
                                    }
                                    else
                                        goto menu_ed;
                                }
                                if (tel_ed.ToLower() == "limpar")
                                {
                                    Console.Write("Deseja excluir a informação?(s/n)");
                                    if (Console.ReadLine() == "s")
                                    {
                                        editar_c.telefone[indice] = "";
                                        tel_ed = "";
                                        
                                    }
                                    else
                                        goto menu_ed;
                                }
                               else if (tel_ed == "")
                                    Console.WriteLine("Valor inalterado!");

                                else
                                    editar_c.telefone[indice] = tel_ed;

                            }
                            lista_contatos[posicao] = editar_c;
                            Console.Clear();
                            Console.WriteLine("---EDITADO COM SUCESSO---!");
                            Console.WriteLine();
                            escrever_arquivo(lista_contatos);

                        }
                        else
                        {
                            Console.WriteLine("Contato não existe, tente novamente!");
                            goto editar;
                        }
                        break;

                    //Excluir contato
                    case "3":
                    excluir:
                        Console.Write("Contato que deseja excluir:");
                        string contato_exl = Console.ReadLine();
                        Contato excluiu = lista_contatos.Find(item => item.nome.Equals(contato_exl));
                        if (contato_exl.Equals("0"))
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

                    case "4":
                        Console.Clear();
                        Console.WriteLine("|---CONTATOS---|");
                        if(lista_contatos.Count() < 1)
                        {
                            Console.WriteLine("NENHUM CONTATO ENCONTRADO!");
                        }
                        foreach (Contato linha in lista_contatos)
                        {
                            if (linha != null)
                            {
                                Console.Write("Nome: " + linha.nome + " | E-mail: " +  linha.email + " | Telefone: ");

                                foreach (string tel in linha.telefone)
                                {
                                    if(tel != null)
                                    Console.Write(tel + " | ");
                                }
                                Console.WriteLine();
                            }
                        }
                        Console.WriteLine("|---CONTATOS---|\n");

                        break;

                    case "0":
                        Console.WriteLine("Saindo...!");
                        escolha_menu = 0;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("|--- DIGITE UMA OPÇÃO VÁLIDA ---|\n");
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
