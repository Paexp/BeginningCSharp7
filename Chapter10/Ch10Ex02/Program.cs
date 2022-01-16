using static System.Console;

public class ClassA
{
    private int state = -1;
    public int State => state;
    public class ClassB
    {
        public void SetPrivateState(ClassA target, int newState)
        {
            target.state = newState;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ClassA myObject = new ClassA();
        WriteLine($"myObject.State = {myObject.State}");
        ClassA.ClassB myOtherObject = new ClassA.ClassB();
        myOtherObject.SetPrivateState(myObject, 999);
        WriteLine($"myObject.State = {myObject.State}");
        ReadKey();
    }
}