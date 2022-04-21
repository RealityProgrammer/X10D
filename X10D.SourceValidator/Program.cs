﻿using System.Text;

var directories = new Stack<string>(Directory.GetDirectories(args[0]));
var problems = 0;
var files = 0;

while (directories.Count > 0)
{
    string path = Path.GetFullPath(directories.Pop());

    foreach (string directory in Directory.EnumerateDirectories(path))
    {
        directories.Push(directory);
    }

    foreach (string file in Directory.EnumerateFiles(path, "*.cs"))
    {
        files++;
        await using var stream = File.OpenRead(file);
        using var reader = new StreamReader(stream, Encoding.UTF8);

        var lineNumber = 1;
        while (await reader.ReadLineAsync() is { } line)
        {
            if (line.Length > 130)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Out.WriteLine($"{file}({lineNumber}): Line is too long ({line.Length})");
                Console.ResetColor();
                problems++;
            }
            else if (line.Length > 0 && char.IsWhiteSpace(line[^1]))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Out.WriteLine($"{file}({lineNumber}): Line contains trailing whitespace");
                Console.ResetColor();
                problems++;
            }

            lineNumber++;
        }
    }
}

Console.Out.WriteLine($"Finished scanning {files} files, {problems} problems encountered.");
return problems;
