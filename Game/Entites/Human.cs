using GoapWorld.Game.Entites.Types;

namespace GoapWorld.Game.Entites;

class Human : _AnyEntities
{

    public string Name;

    public Human(string name) : base()
    {
        Name = name;   

        Tags.Add("Human");
    }

}