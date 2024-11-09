using System;
using System.CommandLine;
using System.Threading.Tasks;
using System.IO;
using System.Linq;


namespace scl;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "The file to read and display on the console.");

        var rootCommand = new RootCommand("Sample app for System.CommandLine");
        rootCommand.AddOption(fileOption);

        rootCommand.SetHandler((file) => 
            { 
                ReadFile(file!); 
            },
            fileOption);
            
        if (args.Length == 0) 
        {
            NoArgs();
            return 0;
        }
        return await rootCommand.InvokeAsync(args);
    }

    static void ReadFile(FileInfo file)
    {
        File.ReadLines(file.FullName).ToList()
            .ForEach(line => Console.WriteLine(line));
    }

    static void NoArgs()
    {
        Console.WriteLine("Program Created by Burhan");
        Console.WriteLine("If no idea type ProgramO -h | ProgramO --help");
    }
}