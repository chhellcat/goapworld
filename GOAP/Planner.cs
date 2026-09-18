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

    private Action GetRandomAntecedent(List<State> goalStates, List<Action> availableActions)
    {
        List<Action> validActions = [];

        // Parcourt les actions disponibles
        foreach (Action action in availableActions)
        {
            bool valid = true;

            // Vérifie chaque état demandé
            foreach (State desiredState in goalStates)
            {
                bool isDesiredStateInConsequences = IsStateInList(desiredState, action.Consequences);

                // Si on trouve pas un des state demandé dans la liste des conséquence, 
                // c'est donc invalide
                if (isDesiredStateInConsequences == false)
                    valid = false;
                    break;
            }

            if (valid)
                validActions.Add(action);
        }

        return validActions[0];
    }

    /// <param name="goalStates">Liste d'état qui consititues l'objectif</param>
    /// <param name="avaliableActions">Liste d'actions disponibles</param>
    /// <returns>Un plan pour accomplire l'objectif si cela est possible</returns>
    public Plan MakePlan(List<State> goalStates, List<Action> avaliableActions)
    {
        // 1. Chercher une action qui accomplit cette liste d'état
        Action antecedent = GetRandomAntecedent(goalStates, avaliableActions);
        return new Plan();
    }
}