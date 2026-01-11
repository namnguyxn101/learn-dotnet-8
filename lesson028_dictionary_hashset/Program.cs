Dictionary<string, int> sodem = new Dictionary<string, int>()
{
    ["one"] = 1,
    ["two"] = 2,
};

sodem["three"] = 3;
sodem.Add("four", 4);

// var keys = sodem.Keys;
// var vals = sodem.Values;

// foreach (var k in keys)
// {
//     Console.WriteLine(k);
// }

// Console.WriteLine("---------------------");

// foreach (var v in vals)
// {
//     Console.WriteLine(v);
// }

// Xóa phần tử bằng key
// sodem.Remove("one");

// Xóa tất cả phần tử
// sodem.Clear();

// Console.WriteLine(sodem.ContainsKey("one"));
// Console.WriteLine(sodem.ContainsValue(0));

// foreach (var n in sodem)
// {
//     Console.WriteLine(n);
// }

//==========================================

HashSet<int> set1 = new HashSet<int>() { 1, 2, 3, 5, 6, 7};
HashSet<int> set2 = new HashSet<int>() { 8, 9, 1, 2, 7, 10 };

// set1.Add(11);
// set1.Remove(7);

// Phép hợp
// set1.UnionWith(set2);

// Phép giao
// set1.IntersectWith(set2);

// Loại bỏ các phần tử chung với set2
// set1.ExceptWith(set2);

foreach (var s in set1)
{
    Console.Write(s + " ");
}
Console.WriteLine("\n------------------------");

set1 = new HashSet<int>() { 1, 4, 2, 8 };
set2 = new HashSet<int>() { 1, 2, 3, 4, 8, 9 };
// Kiểm tra có là tập hợp con của set2 không
Console.WriteLine(set1.IsSubsetOf(set2));

// Kiểm tra tập hợp set2 có chứa tập set1 không
Console.WriteLine(set2.IsSupersetOf(set1));