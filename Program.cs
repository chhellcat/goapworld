using GoapWorld.GOAP;
using GoapWorld.GOAP.Actions;
using GoapAction = GoapWorld.GOAP.Action;
using EasyDebug;

using GoapWorld.Game.Entites;

class Test
{
    static void TestMain()
    {
        Planner planner = new Planner();
        Human BobAtler = new Human("Bob Adtler");

        List<GoapAction> availableActions = [
            new EatAction(),
            new FindFoodAction()
        ];

        List<State> currentStates = [
            new("IsFed", false),
            new("HasFood", false)
        ];

        List<State> goalStates = [
            new("IsFed", true)
        ];

        Plan resultat = planner.MakePlan(currentStates, goalStates, availableActions);
        
        Console.WriteLine(resultat);

        while (true)
        {
            
        }
    }
}


class Programm
{
    static void Main()
    {
        int Delta = 1;
        Planner planner = new Planner();
        Human BobAtler = new Human("Bob Adtler");
        BobAtler.Stats.Food -= 45;

        BobAtler.LearnGoapAction(new EatAction());
        BobAtler.LearnGoapAction(new FindFoodAction());

        while (true)
        {
            Thread.Sleep(Delta*1000);

            BobAtler.Tick(Delta);

            Debug.ConsoleClear();
            Debug.Log(BobAtler);
        }
    }
}