using System.Linq.Expressions;

class Program
{
  static void Main()
  {
    while (true)
    {
      Console.Write("$ ");
      string? input = Console.ReadLine();

      string[] inputToArray = !string.IsNullOrEmpty(input) ? input.Split(" ") : [" "];

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

        if (inputToArray[1] == "echo" || inputToArray[1] == "exit" || inputToArray[1] == "type")
        {
          Console.WriteLine($"{inputToArray[1]} is a shell builtin");
        }
        else if (inputToArray[0] == "type")
        {
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
                  string[] folders = file.Split("/");

                  if (folders[^1] == inputToArray[1])
                  {
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
                    }

                    if (OperatingSystem.IsWindows())
                    {
                      string[] executableExtensions = Environment.GetEnvironmentVariable("PATHEX")?.Split(";") ?? new[] { ".EXE", ".BAT", ".CMD", ".COM" };
                      string ext = Path.GetExtension(file).ToUpperInvariant();
                      if (executableExtensions.Contains(ext))
                      {
                        Console.WriteLine($"{inputToArray[1]} is {file}");
                      }
                    }
                  }
                }
              }
              catch (InvalidOperationException ex)
              {
                Console.WriteLine(ex.Message);
              }
            }

          }
          Console.WriteLine($"{inputToArray[1]}: not found");
        }
      }
      else
      {
        Console.WriteLine($"{input}: command not found");
      }
    }
  }
}
