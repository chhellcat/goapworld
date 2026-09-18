namespace GoapWorld.GOAP;

/// <summary>
/// Décrit un plan d'un point de départ jusqu'a l'objectif donné
/// </summary>
public struct Plan
{
    /// <summary>
    /// La liste des conditions objectifs
    /// </summary>
    public List<State> Goal;

    /// <summary>
    /// Le coût total du plan
    /// </summary>
    public float Cost = 0;

    /// <summary>
    /// La liste des actions a éxécuter dans l'ordre pour atteindre l'objectif
    /// </summary>
    public List<Action> Steps = new List<Action>();

    // Constructeur
    public Plan(List<State> goal)
    {
        Goal = goal;
        Steps = new List<Action>();
        Cost = 0;
    }

    // Représentation écrite
    public override string ToString()
    {
        return $"[{string.Join(" > ", Steps.Select(action => action.Title))}]";
    }

    /// <summary>
    /// Ajoute une action à faire avant les autres
    /// Aka : Ajoute une étape au début de la liste d'étapes
    /// </summary>
    public void AddStep(Action action)
    {
        Steps.Insert(0, action);

        // Recalcule du côut
        Cost += action.Cost;
    }
}