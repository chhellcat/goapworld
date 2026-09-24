using GoapAction = GoapWorld.GOAP.Action;
using GoapWorld.Game.Entites.Types;

namespace GoapWorld.GOAP.Actions;

/// <summary>
/// Le personnage
/// </summary>
public class FindFoodAction : GoapAction
{
    public FindFoodAction() : base(
        "Trouver à manger",
        2,
        [],
        [new("HasFood", true)]
    )
    {
    }

    public override bool Execute(_AnyEntities entity)
    {
        entity.HandSlot = new Apple();
        return true;
    }
}