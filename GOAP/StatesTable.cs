using System.Collections;
using GoapWorld.GOAP;
using System.Linq;

namespace GoapWorld.GOAP;

/// <summary>
/// Permet de faire des opérations,
/// des vérifications et de stocker
/// plusieurs états d'une traite.
/// </summary>
public class StatesTable
{
    private Dictionary<string, State> States = [];

    public override string ToString()
    {
        return $"[{string.Join(", ", States.Values)}]";
    }

    public void Set(State state)
    {
        States[state.Name] = state;
    }

    public State Get(string stateName)
    {
        if (States.TryGetValue(stateName, out State state))
            return state;

        return new State(stateName, false);
    }

    /// <summary>
    /// Transforme le dictionnaire interne en liste d'état pour être 
    /// utiliser par exemple par le planner
    /// </summary>
    /// <returns></returns>
    public List<State> GetList()
    {
        return States.Values.ToList();
    }
}