using GoapWorld.Game.Entites.Types;
using GoapWorld.Game.Objects.Types;

public class Apple : _Food
{
    // Constructeur
    public Apple() : base("Apple")
    {
        Tags.Add("Fruit");
    }

    public override void ConsumedBy(_AnyEntities entity)
    {
        base.ConsumedBy(entity);
        entity.Stats.Food += 25;
    }
}