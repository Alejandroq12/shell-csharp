class Program
{
    static void Main()
    {
        while (true)
        {
          Console.Write("$ ");
          string? input = Console.ReadLine();
          Console.WriteLine($"{input}: command not found");
          Console.Write("$ ");
          Console.WriteLine();
          Console.Write("$ exit");
          Environment.Exit(0);
        }
    }
}
