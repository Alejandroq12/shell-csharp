using System.Linq.Expressions;

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
      }
      else if (inputToArray[0] == "echo")
      {
        string stringToPrint = String.Join(" ", inputToArray[1..]);
        Console.WriteLine(stringToPrint);
      }
      else if (inputToArray[0] == "type" && inputToArray.Length > 1)
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
            string environmentVariable = Environment.GetEnvironmentVariable("PATH") ?? string.Empty;

            string[] directories = environmentVariable.Split(Path.PathSeparator);

            foreach (string path in directories)
            {
              if (Directory.Exists(path))
              {
                try
                {
                  foreach (string file in Directory.GetFiles(path))
                  {
                    if (file.Contains(inputToArray[1]))
                    {
                      Console.WriteLine($"This is my command!!!! Command: {inputToArray[1]}");
                      if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
                      {
                        UnixFileMode mode = File.GetUnixFileMode(file);
                        bool isExecutable = mode.HasFlag(UnixFileMode.UserExecute) ||
                                           mode.HasFlag(UnixFileMode.GroupExecute) ||
                                           mode.HasFlag(UnixFileMode.OtherExecute);
                        if (isExecutable)
                        {
                          Console.WriteLine($"{inputToArray[1]} is {file}");
                        }
                        // Console.WriteLine($"mode is {mode}");
                        // Console.WriteLine($"isExecutable is {isExecutable}");
                      } else if (OperatingSystem.IsWindows())
                      {
                        string[] executableExtensions = Environment.GetEnvironmentVariable("PATHEX")?.Split(";") ?? new[] { ".EXE", ".BAT", ".CMD", ".COM"};
                        string ext = Path.GetExtension(file).ToUpperInvariant();                        
                        if (executableExtensions.Contains(ext))
                        {
                          Console.WriteLine($"{inputToArray[1]} is {file}");
                        }
                      }
                    }
                  }
                }
                catch (UnauthorizedAccessException)
                {
                  Console.WriteLine("Error");
                }
              }
            }

            //Console.WriteLine($"{inputToArray[1]}: HERE I SHOULD IMPLEMENT THE SEARH IN EVERY DIRECTORY");
            //Console.WriteLine($"PATH - environmentVariable: {environmentVariable}");
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
