class Program
{
    static void Main()
    {
        Console.Write("$ ");
        string? input = Console.ReadLine();
        Console.WriteLine($"Invalid command! {input} is not valid");
    }
}
