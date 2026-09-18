<<<<<<< HEAD
﻿using System.Diagnostics;
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
=======
﻿using GoapSimulation;

InterfaceGraphics interfaceGraphics = new InterfaceGraphics();
interfaceGraphics.Run();
>>>>>>> 23060af321e4e637b74a76263e60f47658eedf75
