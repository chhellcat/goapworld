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

    // constructeur
    public _AnyEntities()
    {
        
    }
    
}