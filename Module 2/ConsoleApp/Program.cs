namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // # Partie 1 : Console 

            Console.Write("Quel est votre nom : ");
            Console.ReadLine();

            Console.Write("Quel est votre âge : ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("\nAppuyez sur une touche pour terminer le programme...");
            Console.ReadKey();
        }
    }
}