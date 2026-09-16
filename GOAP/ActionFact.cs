namespace GoapWorld.GOAP

/// <summary>
/// Une vérité qui est utilisée dans les Action (cf class Action)
/// pour décrire un pré-requis ou une conséquence.
/// </summary>
public struct ActionFact
{
    public string Name;
    public bool Value;

    public ActionFact(string name, bool value)
    {
        Name = name;
        Value = value;
    }
}