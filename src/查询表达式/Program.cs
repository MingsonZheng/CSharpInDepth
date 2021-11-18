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

// 使用filter、order、projection的查询表达式入门
Console.WriteLine("使用filter、order、projection的查询表达式入门");

IEnumerable<string> query2 = from word in words
                            where word.Length > 4
                            orderby word
                            select word.ToUpper();

foreach (string word in query2)
{
    Console.WriteLine(word);
}

// 使用 let 子句引入新的范围变量
Console.WriteLine("使用 let 子句引入新的范围变量");

IEnumerable<string> query3 = from word in words
                            let length = word.Length
                            where length > 4
                            orderby length
                            select string.Format("{0}: {1}", length, word.ToUpper());

foreach (string item in query3)
{
    Console.WriteLine(item);
}

// 使用隐形标识符对查询进行转译
Console.WriteLine("使用隐形标识符对查询进行转译");

IEnumerable<string> query4 = words
    .Select(word => new { word, length = word.Length })
    .Where(tmp => tmp.length > 4)
    .OrderBy(tmp => tmp.length)
    .Select(tmp => string.Format("{0}: {1}", tmp.length, tmp.word.ToUpper()));

foreach (string item in query4)
{
    Console.WriteLine(item);
}
