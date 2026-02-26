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
          } else if (inputToArray[0] == "type" && inputToArray.Length > 1) 
          {
            switch (inputToArray[1])
            {
              case "echo":
                Console.WriteLine($"{inputToArray[1]} is a shell builtin");
                break;
              case "exit":
                Console.WriteLine($"{inputToArray[1]} is a shell builtin");
                break;
              case "type":
                Console.WriteLine($"{inputToArray[1]} is a shell builtin");
                break;
              default:
                Console.WriteLine($"{inputToArray[1]}: not found");
                break;
            }
          }
          else 
          {
            Console.WriteLine($"{input}: command not found");
          }
        }
    }
}
