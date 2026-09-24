namespace GoapWorld.GOAP;

/// <summary>
/// Permet de gérer les besoins d'une entité.
/// Chaque besoin doit être à true.
/// Si un besoin est à false, il devient un objectif.
/// </summary>
public class Needs
{
    /// <summary>
    /// Liste des besoins de l'entité.
    /// </summary>
    public List<State> RequiredStates { get; private set; } = [];

    /// <summary>
    /// Constructeur de Needs.
    /// </summary>
    public Needs()
    {

    }

    public override string ToString()
    {
        return $"[{string.Join(", ", RequiredStates)}]";
    }

    /// <summary>
    /// Ajoute un besoin à la liste.
    /// </summary>
    public void Add(State need)
    {
        RequiredStates.Add(need);
    }

    /// <summary>
    /// Modifie un besoin existant ou l'ajoute s'il n'existe pas.
    /// </summary>
    public void Set(State need)
    {
        for (int i = 0; i < RequiredStates.Count; i++)
        {
            if (RequiredStates[i].Name == need.Name)
            {
                RequiredStates[i] = need;
                return;
            }
        }

        RequiredStates.Add(need);
    }

    /// <summary>
    /// Récupère les besoins qui ne sont pas satisfaits.
    /// </summary>
    /// <returns>
    /// Une liste de besoins à true qui constituent les objectifs.
    /// </returns>
    public List<State> GetGoals()
    {
        List<State> goals = new List<State>();

        foreach (State need in RequiredStates)
        {
            if (!need.Value)
            {
                goals.Add(new State(need.Name, true));
            }
        }

        return goals;
    }

    /// <summary>
    /// Récupère le premier besoin qui n'est pas satisfait.
    /// </summary>
    /// <returns>
    /// Le premier objectif insatisfait, ou null si tous les besoins sont satisfaits.
    /// </returns>
    public State? GetFirstUnsatisfiedGoal()
    {
        foreach (State need in RequiredStates)
        {
            if (!need.Value)
            {
                return new State(need.Name, true);
            }
        }

        return null;
    }

    /// <summary>
    /// Vérifie si tous les besoins sont satisfaits.
    /// </summary>
    public bool IsSatisfied()
    {
        foreach (State need in RequiredStates)
        {
            if (!need.Value)
                return false;
        }

        return true;
    }
}