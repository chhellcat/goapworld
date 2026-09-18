namespace GoapWorld.GOAP;

/// <summary>
/// Une action "maillon" de la chaine que forme un plan avec
/// des prérequis et des conséquence.
/// </summary>
public class Action
{

    public string Title;
    public float Cost;
    public List<State> Requirements;
    public List<State> Consequences;

    /// <summary>
    /// Crée une action pour le système GOAP.
    /// </summary>
    /// <param name="title">Titre de l'action.</param>
    /// <param name="cose">Le côut de l'action</param>
    /// <param name="requirements">La liste des pré-requis.</param>
    /// <param name="consequences">La liste des conséquences.</param>
    public Action(string title, float cost, List<State> requirements, List<State> consequences)
    {
        Title = title;
        Cost = cost;
        Requirements = requirements;
        Consequences = consequences;
    }
    
}