// 从多个作用域捕获变量
static List<Action> CreateCountingActions()
{
    List<Action> actions = new List<Action>();
    int outerCounter = 0;
    for (int i = 0; i < 2; i++)
    {
        int innerCounter = 0;
        Action action = () =>
        {
            Console.WriteLine(
                "Outer: {0}; Inner: {1}",
                outerCounter, innerCounter);
            outerCounter++;
            innerCounter++;
        };
        actions.Add(action);
    }
    return actions;
}

List<Action> actions = CreateCountingActions();
actions[0]();
actions[0]();
actions[1]();
actions[1]();

// 从多个作用域捕获变量而创建多个类（以下代码是上述代码经处理器处理后的结果）
List<Action> actions2 = CreateCountingActions2();
actions2[0]();
actions2[0]();
actions2[1]();
actions2[1]();

static List<Action> CreateCountingActions2()
{
    List<Action> actions = new List<Action>();
    OuterContext outerContext = new OuterContext();
    outerContext.outerCounter = 0;
    for (int i = 0; i < 2; i++)
    {
        InnerContext innerContext = new InnerContext();
        innerContext.outerContext = outerContext;
        innerContext.innerCounter = 0;
        Action action = innerContext.Method;
        actions.Add(action);
    }
    return actions;
}

class OuterContext
{
    public int outerCounter;
}

class InnerContext
{
    public OuterContext outerContext;
    public int innerCounter;

    public void Method()
    {
        Console.WriteLine(
            "Outer: {0}; Inner: {1}",
            outerContext.outerCounter, innerCounter);
        outerContext.outerCounter++;
        innerCounter++;
    }
}
