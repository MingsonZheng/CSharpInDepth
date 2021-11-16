void PrintAnything(object obj)
{
    Console.WriteLine(obj);
}

string ProviderAnything()
{
    return string.Empty;
}

Printer p1 = new Printer(PrintAnything);
Printer p2 = PrintAnything;

GeneralPrinter generalPrinter = PrintAnything;
Printer p3 = new Printer(generalPrinter);// 构建一个Printer来封装GeneralPrinter
//Printer p4 = generalPrinter;

StringProvider stringProvider = new StringProvider(ProviderAnything);
ObjectProvider objectProvider = new ObjectProvider(stringProvider);

public delegate void Printer(string message);
public delegate void GeneralPrinter(object obj);
public delegate string StringProvider();
public delegate object ObjectProvider();
