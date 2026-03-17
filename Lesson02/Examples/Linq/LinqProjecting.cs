using System.Linq;
using Models.Employees;

namespace Playground.Lesson02;

public static class LinqProjecting
{
    public static void RunExamples(IEnumerable<Employee> employees)
    {
        System.Console.WriteLine("\nLinq Projecting Examples:");
        System.Console.WriteLine("--------------------------------");
       
        // Select: project to anonymous type with full name and role
        var projected = employees.Select(e => new { FullName = $"{e.FirstName} {e.LastName}", e.Role });
        System.Console.WriteLine("Projected employees (FullName, Role):");
        projected.Take(10).ToList().ForEach(p => System.Console.WriteLine($"{p.FullName} - {p.Role}"));

        System.Console.WriteLine();

        // SelectMany: flatten all credit cards across employees
        var allCards = employees.SelectMany(e => e.CreditCards, (e, card) => new { Employee = $"{e.FirstName} {e.LastName}", card.Number, card.Issuer });
        System.Console.WriteLine("All credit cards (Employee - Number - Issuer) (showing 10):");
        allCards.Take(10).ToList().ForEach(c => System.Console.WriteLine($"{c.Employee} - {c.Number} - {c.Issuer}"));


        // Cross join: all combinations of first names, last names and roles
        var fnames = employees.Select(e => e.FirstName).Distinct().ToList();
        var lnames = employees.Select(e => e.LastName).Distinct().ToList();
        var roles = employees.Select(e => e.Role).Distinct().ToList();

        var crossJoin = fnames
            .SelectMany(fn => lnames, (fn, ln) => (fn, ln))
            .SelectMany(x => roles, (x, role) => (FirstName: x.fn, LastName: x.ln, Role: role));

        Console.WriteLine($"Cross-join count: {crossJoin.Count()} ({fnames.Count} fnames × {lnames.Count} lnames × {roles.Count} roles)");
        Console.WriteLine("First 10 combinations:");
        crossJoin.Take(10).ToList().ForEach(x =>
            Console.WriteLine($"  {x.FirstName} {x.LastName} - {x.Role}"));

    }
}
