using Newtonsoft.Json.Linq;
using System.Dynamic;

// 使用动态类型获取子串
Console.WriteLine("使用动态类型获取子串");

dynamic text = "hello world";
string world = text.Substring(6);
Console.WriteLine(world);

//string broken = text.SUBSTR(6);// 编译成功，调用报错
//Console.WriteLine(broken);

// 动态类型的加法操作
Console.WriteLine("动态类型的加法操作");

static void Add(dynamic d)
{
    Console.WriteLine(d + d);
}

Add("text");
Add(10);
Add(TimeSpan.FromMinutes(45));

// 动态方法重载决议
Console.WriteLine("动态方法重载决议");

DyanamicOverloadResolution.CallMethod(10);
DyanamicOverloadResolution.CallMethod(10.5m);
DyanamicOverloadResolution.CallMethod(10L);
DyanamicOverloadResolution.CallMethod("text");

// 涉及动态值的编译错误示例
Console.WriteLine("涉及动态值的编译错误示例");

//dynamic d = new object();
//int invalid1 = "text".Substring(0, 1, 2, d);
//bool invalid2 = string.Equals<int>("foo", d);
//string invalid3 = new string(d, "broken");
//char invalid4 = "text"[d, d];

// 在 ExpandoObject 中存取 items
Console.WriteLine("在 ExpandoObject 中存取 items");

dynamic expando = new ExpandoObject();
expando.SomeData = "Some data";
Action<string> action = input => Console.WriteLine("The input was '{0}'", input);
expando.FakeMethod = action;

Console.WriteLine(expando.SomeData);
expando.FakeMethod("hello");

IDictionary<string, object> dictionary = expando;
Console.WriteLine("Keys: {0}", string.Join(", ", dictionary.Keys));

dictionary["OtherData"] = "other";
Console.WriteLine(expando.OtherData);

// 动态地使用 JSON 数据
Console.WriteLine("动态地使用 JSON 数据");

string json = @"
                {
                  'name': 'Jon Skeet',
                  'address': { 
                    'town': 'Reading',
                    'country': 'UK'
                  }
                }".Replace('\'', '"');

JObject obj1 = JObject.Parse(json);
Console.WriteLine(obj1["address"]["town"]);

dynamic obj2 = obj1;
Console.WriteLine(obj2.address.town);

// 动态行为的针对性使用
Console.WriteLine("动态行为的针对性使用");

dynamic example = new SimpleDynamicExample();
example.CallSomeMethod("x", 10);
Console.WriteLine(example.SomeProperty);

// 在动态值列表执行LINQ
Console.WriteLine("在动态值列表执行LINQ");

List<dynamic> source = new List<dynamic>
{
    5,
    2.75,
    TimeSpan.FromSeconds(45)
};
IEnumerable<dynamic> query = source.Select(x => x * 2);
foreach (dynamic value in query)
{
    Console.WriteLine(value);
}

/// <summary>
/// 动态方法重载决议
/// </summary>
class DyanamicOverloadResolution
{
    static void SampleMethod(int value)
    {
        Console.WriteLine("Method with int parameter");
    }

    static void SampleMethod(decimal value)
    {
        Console.WriteLine("Method with decimal parameter");
    }

    static void SampleMethod(object value)
    {
        Console.WriteLine("Method with object parameter");
    }

    public static void CallMethod(dynamic d)
    {
        SampleMethod(d);
    }
}

/// <summary>
/// 动态行为的针对性使用
/// </summary>
class SimpleDynamicExample : DynamicObject
{
    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
    {
        Console.WriteLine("Invoked: {0}({1})", binder.Name, string.Join(", ", args));
        result = null;
        return true;
    }

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        result = "Fetched: " + binder.Name;
        return true;
    }
}
