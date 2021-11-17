void PrintAnything(object obj)
{
    Console.WriteLine(obj);
}

string ProviderAnything()
{
    return string.Empty;
}

void PrintLong(long l)
{
    Console.WriteLine(l);
}

Printer p1 = new Printer(PrintAnything);// string类型的引用可以通过一致性转换变为object类型的引用
Printer p2 = PrintAnything;

GeneralPrinter g1 = PrintAnything;  
Printer p3 = new Printer(g1);// 使用委托来创建另一个委托

StringProvider stringProvider = new StringProvider(ProviderAnything);
ObjectProvider objectProvider = new ObjectProvider(stringProvider);// 返回类型同理

Int64Printer int64Printer = new Int64Printer(PrintLong);
//Int32Printer int32Printer = new Int32Printer(int64Printer);// 参数或返回值之间兼容性必须满足一致性转换规则

public delegate void Printer(string message);
public delegate void GeneralPrinter(object obj);

public delegate string StringProvider();
public delegate object ObjectProvider();

public delegate void Int32Printer(int x);
public delegate void Int64Printer(long x);
