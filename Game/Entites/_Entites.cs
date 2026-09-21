using System.Numerics;

namespace GoapWorld.Game.Entites.Types;

/// <summary>
/// Représente tout les objets
/// </summary>
class _AnyEntities
{
    public Vector2 Position = new Vector2();

    /// <summary>
    /// Les tags permettent de catégoriser
    /// les entitées
    /// </summary>
    public List<string> Tags = [];

    /// <summary>
    /// Le besoin en nourriture
    /// </summary>
    public float NeedFood = 0;

    // constructeur
    public _AnyEntities()
    {
        
    }

    /// <summary>
    /// Est appelé à chaque tick avec le delta
    /// </summary>
    /// <param name="deltaTime"></param>
    public void Tick(float deltaTime)
    {
        NeedFood += deltaTime; // 1 par secondes
    }
    
}