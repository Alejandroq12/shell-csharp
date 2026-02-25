class Program
{
    static void Main()
    {
        while (true)
        {
          Console.Write("$ ");
          string? input = Console.ReadLine();
          string[] inputToArray = input.Split(" ");

          if (input == "exit")
          {
            Environment.Exit(0);
          } else if (inputToArray[0] == "echo") 
          {
            string stringToPrint = String.Join(" ", inputToArray[1..]);
            Console.WriteLine(stringToPrint);
          } else 
          {
            Console.WriteLine($"{input}: command not found");
          }
        }
    }
}
