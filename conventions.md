# Langues : 

Code en anglais
Commentaires en français

# Documentations : 

Bien documenter les fonctions
Utiliser des sépérateurs pour les différentes catégories 
dans le code : 

ex : 
// ============================================================
// Composants
// ============================================================

# Cases :

**PascalCase** pour les classes, méthodes, propriétés et namespaces (`Robot`, `Attack()`, `MaxHealth`, `MyGame.Entities`)
**camelCase** pour les variables locales et paramètres (`robotName`, `maxHealth`)**SCREAMING_SNAKE_CASE** pour les constantes
**_camelCase** avec un underscore pour les petit champs privés / provisoires

 les fichiers portent généralement le même nom que leur classe
Exemple :

```csharp
namespace MyGame.Entities;

public class Robot
{
    private int _health;
    public int MaxHealth { get; }

    public Robot(int maxHealth)
    {
        MaxHealth = maxHealth;
        _health = maxHealth;
    }

    public void AttackRobot(Robot target)
    {
        string attackName = "Laser";
    }
}
```