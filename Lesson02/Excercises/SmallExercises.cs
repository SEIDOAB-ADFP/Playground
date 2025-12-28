using System.Collections.Immutable;
using System.Globalization;

namespace Playground.Lesson02;

#region Records
public record ShoppingCartItem(Guid ProductId, string ProductName, int Quantity, decimal UnitPrice);

public record ShoppingCart(ImmutableList<ShoppingCartItem> Items)
{
    public ShoppingCart AddItem(ShoppingCartItem item) => this with { Items = Items.Add(item) };
    public ShoppingCart RemoveItem(Guid productId) => this with { Items = Items.RemoveAll(i => i.ProductId == productId) };
    public ShoppingCart UpdateQuantity(Guid productId, int newQuantity) 
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId);
        if (item == null) return this;
        return this with { Items = Items.Replace(item, item with { Quantity = newQuantity }) };
    }

    public decimal TotalPrice => Items.Sum(i => i.Quantity * i.UnitPrice);
}

public class SmallExercises
{
    public static void Entry()
    {
        Console.WriteLine("=== Records Exercise: Immutable Shopping Cart ===");
        var cart = new ShoppingCart(ImmutableList<ShoppingCartItem>.Empty);
        
        var item1 = new ShoppingCartItem(Guid.NewGuid(), "Laptop", 1, 1200m);
        var item2 = new ShoppingCartItem(Guid.NewGuid(), "Mouse", 2, 25m);

        var cart1 = cart.AddItem(item1);
        var cart2 = cart1.AddItem(item2);
        var cart3 = cart2.UpdateQuantity(item1.ProductId, 2);
        var cart4 = cart3.RemoveItem(item2.ProductId);

        Console.WriteLine($"Original cart price: {cart.TotalPrice:C}");
        Console.WriteLine($"Cart 1 price: {cart1.TotalPrice:C}");
        Console.WriteLine($"Cart 2 price: {cart2.TotalPrice:C}");
        Console.WriteLine($"Cart 3 price: {cart3.TotalPrice:C}");
        Console.WriteLine($"Cart 4 price: {cart4.TotalPrice:C}");

        Console.WriteLine("\n=== Tuples Exercise: Multiple Return Values ===");
        var (min, max, avg, evens) = AnalyzeNumbers(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        Console.WriteLine($"Numbers analysis: Min={min}, Max={max}, Avg={avg:F1}, Evens Count={evens}");

        var (first, last) = SplitName("John Doe");
        Console.WriteLine($"Split name: First={first}, Last={last}");

        Console.WriteLine("\n=== Pattern Matching Exercise: Shape Calculator ===");
        object circle = new Circle(5);
        object rect = new Rectangle(10, 20);
        object triangle = new Triangle(10, 5);

        Console.WriteLine(DescribeShape(circle));
        Console.WriteLine(DescribeShape(rect));
        Console.WriteLine(DescribeShape(triangle));

        Console.WriteLine("\n=== Generics Exercise: Box and Pair ===");
        var intBox = new Box<int>(42);
        var stringBox = new Box<string>("Hello");
        Console.WriteLine($"Int Box: {intBox.GetValue()}");
        Console.WriteLine($"String Box: {stringBox.GetValue()}");

        var pair = Pair.Create(1, "One");
        var swapped = pair.Swap();
        var mapped = pair.Map(id => $"ID-{id}", val => val.ToUpper());
        Console.WriteLine($"Original pair: {pair.First}, {pair.Second}");
        Console.WriteLine($"Swapped pair: {swapped.First}, {swapped.Second}");
        Console.WriteLine($"Mapped pair: {mapped.First}, {mapped.Second}");

        Console.WriteLine("\n=== Extensions Exercise: String & Enumerable ===");
        string messy = "hello world! this is a test.";
        string clean = messy.ToTitleCase().Truncate(15);
        Console.WriteLine($"Messy: {messy}");
        Console.WriteLine($"Clean: {clean}");

        var nums = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        var chunks = nums.ChunkCustom(3);
        Console.WriteLine("Chunks of 3: " + string.Join(" | ", chunks.Select(c => string.Join(",", c))));

        Console.WriteLine("\n=== Enumerables Exercise: Yield & Fibonacci ===");
        Console.WriteLine("Fibonacci (10): " + string.Join(", ", GenerateFibonacci(10)));
        
        var source = new[] { 1, 2, 3, 4 };
        var intermediateSums = Scan(source, (acc, next) => acc + next);
        Console.WriteLine("Scan sums: " + string.Join(", ", intermediateSums));

        Console.WriteLine("\n=== Custom Enumerable Class: RangeEnumerable ===");
        var range = new RangeEnumerable(1, 10, 2);
        Console.WriteLine("Range (1 to 10 step 2): " + string.Join(", ", range));
        Console.WriteLine("Range Reversed: " + string.Join(", ", range.Reverse()));
    }
#endregion

#region Tuples
    public static (int min, int max, double avg, int evens) AnalyzeNumbers(int[] numbers)
        => (numbers.Min(), numbers.Max(), numbers.Average(), numbers.Count(n => n % 2 == 0));

    public static (string first, string last) SplitName(string fullName)
    {
        var parts = fullName.Split(' ');
        return (parts[0], parts.Length > 1 ? parts[1] : "");
    }
#endregion

#region Pattern Matching
    public record Circle(double Radius);
    public record Rectangle(double Width, double Height);
    public record Triangle(double Base, double Height);

    public static double CalculateArea(object shape) => shape switch
    {
        Circle c => Math.PI * c.Radius * c.Radius,
        Rectangle r => r.Width * r.Height,
        Triangle t => 0.5 * t.Base * t.Height,
        _ => 0
    };

    public static string DescribeShape(object shape) => shape switch
    {
        Circle { Radius: > 10 } => "Large circle",
        Circle => "Small circle",
        Rectangle r when r.Width == r.Height => "Square",
        Rectangle => "Rectangle",
        Triangle => "Triangle",
        _ => "Unknown shape"
    };
#endregion

#region Enumerables
    public static IEnumerable<int> GenerateFibonacci(int count)
    {
        int a = 0, b = 1;
        for (int i = 0; i < count; i++)
        {
            yield return a;
            int temp = a;
            a = b;
            b = temp + b;
        }
    }

    public static IEnumerable<T> Scan<T>(IEnumerable<T> source, Func<T, T, T> accumulator)
    {
        using var enumerator = source.GetEnumerator();
        if (!enumerator.MoveNext()) yield break;

        T current = enumerator.Current;
        yield return current;

        while (enumerator.MoveNext())
        {
            current = accumulator(current, enumerator.Current);
            yield return current;
        }
    }
}
#endregion

#region Generics
public class Box<T>(T value)
{
    private readonly T _value = value;
    public T GetValue() => _value;
    public bool IsEmpty() => _value == null;
}

public class Pair<TFirst, TSecond>(TFirst first, TSecond second)
{
    public TFirst First { get; } = first;
    public TSecond Second { get; } = second;

    public Pair<TSecond, TFirst> Swap() => new(Second, First);
    public Pair<TRet1, TRet2> Map<TRet1, TRet2>(Func<TFirst, TRet1> f1, Func<TSecond, TRet2> f2)
        => new(f1(First), f2(Second));
}

public static class Pair
{
    public static Pair<T1, T2> Create<T1, T2>(T1 first, T2 second) => new(first, second);
}
#endregion

#region Extensions
public static class SmallExtensions
{
    public static string Truncate(this string s, int max, string suffix = "...")
        => s.Length <= max ? s : s[..max] + suffix;

    public static string ToTitleCase(this string s)
        => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());

    public static IEnumerable<IEnumerable<T>> ChunkCustom<T>(this IEnumerable<T> source, int size)
    {
        var list = source.ToList();
        for (int i = 0; i < list.Count; i += size)
        {
            yield return list.Skip(i).Take(size);
        }
    }
}
#endregion

#region Custom Enumerable Class
public class RangeEnumerable(int start, int end, int step = 1) : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator() => new RangeEnumerator(start, end, step);
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

    public RangeEnumerable Reverse() => new(end, start, -step);

    private class RangeEnumerator(int start, int end, int step) : IEnumerator<int>
    {
        private int _current = start - step;
        private readonly int _start = start;
        private readonly int _end = end;
        private readonly int _step = step;

        public int Current => _current;
        object System.Collections.IEnumerator.Current => Current;

        public bool MoveNext()
        {
            _current += _step;
            if (_step > 0) return _current <= _end;
            return _current >= _end;
        }

        public void Reset() => _current = _start - _step;
        public void Dispose() { }
    }
}
#endregion
