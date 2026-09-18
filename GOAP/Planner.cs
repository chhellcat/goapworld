namespace GoapWorld.GOAP;

/// <summary>
/// Permet de construire et éditer un plan à partir d'un objectif et d'un set d'action donné
/// </summary>
public class Planner
{

    public bool IsStateInList(State state, List<State> list)
    {
        foreach (State otherState in list)
        {
            if (otherState.Matches(state))
            {
                return true;
            }
        }
        return false;
    }

    private Action? GetAntecedent(
        List<State> goalStates,
        List<Action> availableActions
    )
    {
        return availableActions.FirstOrDefault(action =>
            goalStates.All(goal =>
                IsStateInList(goal, action.Consequences)
            )
        );
    }

    /// <param name="goalStates">Liste d'état qui consititues l'objectif</param>
    /// <param name="avaliableActions">Liste d'actions disponibles</param>
    /// <returns>Un plan pour accomplire l'objectif si cela est possible</returns>
    public Plan MakePlan(
        List<State> currentStates,
        List<State> goalStates,
        List<Action> availableActions
    )
    {
        // Prépration d'un plan vide : 
        Plan plan = new Plan(goalStates);

        // Ajout d'action succésives jusqu'a que le plan soi réalisable
        while (true)
        {
            Action? antecedent = GetAntecedent(goalStates, availableActions);

            if (antecedent == null)
                Console.WriteLine("Aucun plan possible");
                return plan;

            plan.AddStep(antecedent);

            ...

            return plan;
        }
    }
}