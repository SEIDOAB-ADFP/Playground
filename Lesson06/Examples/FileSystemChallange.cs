using System.Collections.Immutable;
using System.Net;

namespace Playground.Lesson06;

public static class FileSystemChallange
{
    public static void RunExamples()
    {
        Console.WriteLine("FindDirectoriesIterative");
        FindDirectoriesIterative("/Users/Martin/Development/projects/Advanced_Programming_Dec_2025");

        Console.WriteLine("\n\nFindDirectoriesRecursive");
        FindDirectoriesRecursive("/Users/Martin/Development/projects/Advanced_Programming_Dec_2025", 6);

        Console.WriteLine("\n\nCountDirectoriesRecursive");
        int totalDirs = CountDirectoriesRecursive("/Users/Martin/Development/projects/Advanced_Programming_Dec_2025");
        Console.WriteLine($"\nTotal directories found: {totalDirs}");
    }

    public static void FindDirectoriesIterative(string myDirectory)
    {
        //Get first level directories
        Console.WriteLine(myDirectory);
        foreach (var dir1 in Directory.EnumerateDirectories(myDirectory))
        {
            Console.WriteLine($"{dir1}");
            try
            {
                //Get second level directories, where I have access control
                foreach (var dir2 in Directory.EnumerateDirectories(dir1))
                {
                    Console.WriteLine($"{dir2}");
                    try
                    {
                        //Get third level directories, where I have access control
                        foreach (var dir3 in Directory.EnumerateDirectories(dir2))
                        {
                            Console.WriteLine($"{dir3}");
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        continue;
                    }            
                }
            }
            catch (UnauthorizedAccessException)
            {
                continue;
            }            
        }
    }

    static void FindDirectoriesRecursive(string myDirectory, int nr_levels)
    {
        //base case, nr levels exhausted
        if (nr_levels <= 0)
            return;

        //action case
        Console.WriteLine(myDirectory);

        //recursive case
        try
        {
            foreach (var dir1 in Directory.EnumerateDirectories(myDirectory))
            {
                FindDirectoriesRecursive(dir1, nr_levels - 1);
            }
        }
        catch (UnauthorizedAccessException)
        {
        }

        //base case, no more levels to process;
        return;
    }

    static int CountDirectoriesRecursive(string myDirectory, int? nr_levels = null)
    {
        //base case, nr levels exhausted
        if (nr_levels.HasValue && nr_levels.Value <= 0)
            return 0;

        //action case - found myDirectory
        int nrDirs = 1;

        //recursive case - add nr of recursively found directories
        try
        {
            foreach (var dir1 in Directory.EnumerateDirectories(myDirectory))
            {
                nrDirs += CountDirectoriesRecursive(dir1, nr_levels.HasValue ? nr_levels - 1 : null);
            }
        }
        catch (UnauthorizedAccessException)
        {
        }

        //base case, no more levels to process;
        return nrDirs;
    }
}
