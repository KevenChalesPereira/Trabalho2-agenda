namespace Trabalho2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contatos c = new Contatos();

            string? nom, numer;

            nom = Console.ReadLine();
            numer = Console.ReadLine();

            c.adicionar(nom, numer);
            
            Console.Write("Antigo: " + c.nome);
            Console.ReadLine();
            Console.Write("Novo : ");
            
        }
        
     
       
    }

}
