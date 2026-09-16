using GoapWorld;

class Test
{
    public string Name;

    public Test(string name)
    {
        Name = name;
    }

    public void Attack()
    {
        Console.WriteLine($"{Name} attaque !");
    }
}

class Program
{
    static void Main()
    {
        Test robot = new Test("Bob jhon");

        robot.Attack();
    }
}