// foreach循环
Console.WriteLine("foreach循环");
static IEnumerable<int> CreateSimpleIterator()
{
    yield return 10;

    for (int i = 0; i < 3; i++)
    {
        yield return i;
    }

    yield return 20;
}

foreach (int value in CreateSimpleIterator())
{
    Console.WriteLine(value);
}

// 扩展foreach循环
Console.WriteLine("扩展foreach循环");
IEnumerable<int> enumerable = CreateSimpleIterator();

using(IEnumerator<int> enumerator = enumerable.GetEnumerator())
{
    while (enumerator.MoveNext())
    {
        int value = enumerator.Current;
        Console.WriteLine(value);
    }
}

// IEnumerable:可用于迭代的序列
// IEnumerator:序列的一个游标

// 迭代斐波那契数列
Console.WriteLine("迭代斐波那契数列");
static IEnumerable<int> Fibonacci()
{
    int current = 0;
    int next = 1;

    while (true)
    {
        yield return current;

        int oldCurrent = current;
        current = next;
        next = next + oldCurrent;
    }
}

foreach (var value in Fibonacci())
{
    Console.WriteLine(value);

    if (value > 1000)
    {
        break;
    }
}

// 一个用于记录执行进度的迭代器
Console.WriteLine("一个用于记录执行进度的迭代器");
static IEnumerable<string> Iterator()
{
    try
    {
        Console.WriteLine("Before first yield");
        yield return "first";
        Console.WriteLine("Between yields");
        yield return "second";
        Console.WriteLine("After second yield");
    }
    finally
    {
        Console.WriteLine("In finally block");
    }
}

foreach (string value in Iterator())
{
    Console.WriteLine("Received value: {0}", value);
}

Console.WriteLine("使用迭代器退出foreach循环");

foreach (string value in Iterator())
{
    Console.WriteLine("Received value: {0}", value);

    if(value != null)
    {
        break;
    }
}

Console.WriteLine("不使用foreach循环");

IEnumerable<string> enumerable2 = Iterator();

using(IEnumerator<string> enumerator = enumerable2.GetEnumerator())// using语句保证不管采用何种方式离开循环，都会调用IEnumerator<string>的Dispose方法
{
    while (enumerator.MoveNext())
    {
        string value = enumerator.Current;
        Console.WriteLine("Received value: {0}", value);

        if (value != null)
        {
            break;
        }
    }
}

// 逐行读取文件内容
Console.WriteLine("逐行读取文件内容");

static IEnumerable<string> ReadLines(string path)
{
    using(TextReader reader = File.OpenText(path))
    {
        string line;

        while((line = reader.ReadLine()) != null)// 迭代器可以保证每次迭代都会打开一次文件
        {
            yield return line;
        }
    }
}
