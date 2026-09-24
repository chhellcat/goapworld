using GoapWorld.Game.Entites.Types;

namespace GoapWorld.Game.Objects.Types;

// Interface nourriture
public interface IFood
{
    void ConsumedBy(_AnyEntities entity);
}

/// <summary>
/// Représente les objets nourriture
/// </summary>
public class _Food : _AnyObject, IFood
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