namespace GoapWorld.GOAP;

/// <summary>
/// Permet de construire et éditer un plan à partir d'un objectif et d'un set d'action donné
/// </summary>
public class Planner
{

    private Action FindRandomAntecedent(List<State> goalStates, List<Action> availableActions)
    {
        List<Action> validActions = [];

        // Parcourt les actions disponibles
        foreach (Action action in availableActions)
        {
            bool valid = true;

            // Vérifie chaque état demandé
            foreach (State desiredState in goalStates)
            {
                bool found = false;

                // Cherche l'état dans les conséquences de l'action
                foreach (State consequence in action.Consequences)
                {
                    if (consequence.Matches(desiredState))
                    {
                        found = true;
                        break;
                    }
                }

                // Un état demandé n'est pas satisfait
                if (!found)
                {
                    valid = false;
                    break;
                }
            }

            if (valid)
                validActions.Add(action);
        }

        // TODO : choisir une action au hasard
        return validActions[0];
    }

    /// <param name="goalStates">Liste d'état qui consititues l'objectif</param>
    /// <param name="avaliableActions">Liste d'actions disponibles</param>
    /// <returns>Un plan pour accomplire l'objectif si cela est possible</returns>
    public Plan MakePlan(List<State> goalStates, List<Action> avaliableActions)
    {
        // 1. Chercher une action qui accomplit cette liste d'état

    }
}