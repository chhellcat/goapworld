using System.Diagnostics;
using GoapWorld;
using GoapWorld.GOAP;
using GoapWorld.GOAP.Actions;
using GoapAction = GoapWorld.GOAP.Action;

class Program
{
    static void Main()
    {
        Planner planner = new Planner();

        List<GoapAction> availableActions = [
            new EatAction()
        ];

        List<State> goalStates = [
            new("IsFed", true)
        ];

        Plan resultat = planner.MakePlan(goalStates, availableActions);

        Console.WriteLine("Lets go : ");
        Console.WriteLine(resultat.Steps);
        Console.WriteLine(resultat);

        while (true)
        {
            
        }
    }
}
