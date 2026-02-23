class Program
{
    static void Main()
    {
        while (true)
        {
          Console.Write("$ ");
          string? input = Console.ReadLine();
          if (input == "exit")
          {
            Environment.Exit(0);
          }

          if (input == "echo")
          {
            Console.WriteLine(input);
          }
          Console.WriteLine($"{input}: command not found");
        }
    }
}
