namespace GoapWorld.GOAP;

/// <summary>
/// Permet de construire et éditer un plan à partir d'un objectif et d'un set d'action donné
/// </summary>
public class Planner
{

    private Action? GetAntecedent(List<State> goalStates, List<Action> availableActions)
    {
        return availableActions.FirstOrDefault(action =>
            goalStates.All(goal =>
                goal.IsInList(action.Consequences)
            )
        );
    }

    private Blob IsAllStatesInList(List<State> requiredStates, List<State> statesList)
    {
        return requiredStates.All(requirement =>
                requirement.IsInList(statesList)
            )
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
        // Prépration d'un plan vide 
        Plan plan = new Plan(goalStates);

        // Recher pour ces objectifs
        List<State> currentGoalStates = goalStates;

        // Ajout d'action succésives jusqu'a que le plan soi réalisable
        while (IsAllStatesInList(currentGoalStates, currentStates))
        {
            Action? antecedent = GetAntecedent(currentGoalStates, availableActions);

            if (antecedent == null)
            {
                // Si il n'y a pas d'antecedent, impossible de faire un plan
                Console.WriteLine("Aucun plan possible");
                return plan;
            }

            // Ajout de l'étape au plan
            plan.AddStep(antecedent);
            currentGoalStates = antecedent.Requirements;
        }

        return plan;
    }
}