using GoapAction = GoapWorld.GOAP.Action;
using GoapWorld.GOAP;
using GoapWorld.Game.Entites.Types;
using GoapWorld.Game.Objects.Types;

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

    public override bool Execute(_AnyEntities entity)
    {
        // Si il n'y a aucun objet en main -> FAIL
        if (entity.HandSlot is null)
            return false;

        // Si ce qu'il y a en main n'est pas de la nourriture -> FAIL
        if (entity.HandSlot is not _Food food)
            return false;

        food.ConsumedBy(entity);
        entity.HandSlot = null;

        return true;
    }
}