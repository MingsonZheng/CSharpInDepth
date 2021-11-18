// 字符串简单查询
Console.WriteLine("字符串简单查询");

string[] words = { "keys", "coat", "laptop", "bottle" };
IEnumerable<string> query = words
    .Where(word => word.Length > 4)
    .OrderBy(word => word)
    .Select(word => word.ToUpper());

foreach (string word in query)
{
    Console.WriteLine(word);
}

// 没有使用扩展方法的简单查询
Console.WriteLine("没有使用扩展方法的简单查询");

IEnumerable<string> query2 =
    Enumerable.Select(
        Enumerable.OrderBy(
            Enumerable.Where(words, word => word.Length > 4),
            word => word),
        word => word.ToUpper());

foreach (string word in query2)
{
    Console.WriteLine(word);
}

// 使用多条语句实现的简单查询
Console.WriteLine("使用多条语句实现的简单查询");

var tmp1 = Enumerable.Where(words, word => word.Length > 4);
var tmp2 = Enumerable.OrderBy(tmp1, word => word);
IEnumerable<string> query3 = Enumerable.Select(tmp2, word => word.ToUpper());

foreach (string word in query3)
{
    Console.WriteLine(word);
}
