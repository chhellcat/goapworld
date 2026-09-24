using System.Diagnostics;

namespace GoapWorld.GOAP;

/// <summary>
/// Une vérité qui est utilisée dans les Action (cf class Action)
/// pour décrire un pré-requis ou une conséquence.
/// </summary>
public struct State
{
    public string Name;
    public bool Value;

    public State(string name, bool value)
    {
        Name = name;
        Value = value;
    }

    public override string ToString()
    {
        return $"{{{Name}: {Value}}}";
    }

    public bool Matches(State other)
    {
        return Name == other.Name && Value == other.Value;
    }

    public bool IsInList(List<State> list)
    {
        foreach (State otherState in list)
        {
            if (this.Matches(otherState))
                return true;
        }

        return false;
    }
}