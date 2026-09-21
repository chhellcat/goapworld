using GoapWorld.Game.Entites.Types;

namespace GoapWorld.Game.Objects.Types;

/// <summary>
/// Représente les objets nourriture
/// </summary>
class _Food : _AnyObject
{
    
    // Constructeur
    public _Food(string name) : base(name)
    {
        // Ajout des tags
        Tags.Add("Food");
    }

    public virtual void ConsumedBy(_AnyEntities entity)
    {
        // Overwirte
    }

}