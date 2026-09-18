using GoapAction = GoapWorld.GOAP.Action;
using GoapWorld.GOAP;

namespace GoapWorld.GOAP.Actions;

/// <summary>
/// Le personnage mange ce qu'il a en main
/// </summary>
public class EatAction : GoapAction
{
    public EatAction() : base(
        "Manger",
        1,
        [new("HasFood", true)],
        [new("HasFood", false), new("IsFed", true)]
    )
    {
    }
}