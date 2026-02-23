class Program
{
    static void Main()
    {
        while (true)
        {
          Console.Write("$ ");
          string? input = Console.ReadLine();
          Console.WriteLine($"{input}: command not found");
          Console.WriteLine("$ ");
          Environment.Exit(0);
        }
    }
}
