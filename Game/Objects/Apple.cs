using GoapWorld.Game.Entites.Types;
using GoapWorld.Game.Objects.Types;

class Apple : _Food
{
    // Constructeur
    public Apple() : base("Apple")
    {
        Tags.Add("Fruit");
    }

    public override void ConsumedBy(_AnyEntities entity)
    {
        base.ConsumedBy(entity);
        entity.NeedFood -= 25;
    }
}