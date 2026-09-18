using System.Numerics;

namespace GoapWorld.Game.Objects.Types;

/// <summary>
/// Représente tout les objets
/// </summary>
class _AnyObject
{
    public string Name;

    public Vector2 Position = new Vector2();

    /// <summary>
    /// Les tags permettent de catégoriser
    /// les objets
    /// </summary>
    public List<string> Tags = [];

    // constructeur
    public _AnyObject(string name)
    {
        Name = name;
    }
}