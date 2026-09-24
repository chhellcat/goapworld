using System.Numerics;
using GoapWorld.GOAP;
using GoapAction = GoapWorld.GOAP.Action;
using GoapWorld.Game.Objects.Types;

using EasyDebug;
using System.Linq.Expressions;

namespace GoapWorld.Game.Entites.Types;

/// <summary>
/// Représente tout les objets
/// </summary>
public class _AnyEntities
{
    // ===============================
    // Datas
    // ===============================

    /// <summary>   
    /// Les tags permettent de catégoriser
    /// les entitées
    /// </summary>
    public List<string> Tags = [];
    public Vector2 Position = new Vector2();

    /// <summary>
    /// Inventaire
    /// </summary>
    public _AnyObject? HandSlot = null;

    // ===============================
    // Besoins du vivants
    // ===============================

    public EntityStats Stats = new EntityStats();

    // ===============================
    // Goap
    // ===============================

    private Planner GoapPlanner = new Planner();
    public List<GoapAction> KnownActions = new List<GoapAction>();
    private StatesTable GoapStates = new StatesTable();
    private Needs GoapNeeds = new Needs();
    public List<State> CurrentGoal = [];
    public Plan? CurrentPlan = null;

    // ===============================
    // Fonctions
    // ===============================

    // constructeur
    public _AnyEntities()
    {
        
    }

    public override string ToString()
    {
        string msg = "(Entity)\n";

        msg += "|Stats: \n";
        msg += $"|- nourriture : {Stats.Food}\n";
        msg += $"|- eau : {Stats.Water}\n";
        msg += "|GOAP: \n";
        msg += $"|- objectif : {Debug.ToLogString(CurrentGoal)} \n";
        if (CurrentPlan == null)
        {
            msg += $"|- plan : Aucun...\n";    
        }
        else
        {
            msg += $"|- plan : {Debug.ToLogString(CurrentPlan)}\n";
        }        

        msg += $"|- states 'besoins' : {GoapNeeds}\n";
        msg += $"|- states commun : {GoapStates}\n";

        return msg;
    }

    // -----------------------------------
    // Goap
    // -----------------------------------
    /// <summary>
    /// Apprend une action de goap à l'entitée
    /// </summary>
    /// <param name="action">L'action a apprendre</param>
    public void LearnGoapAction(GoapAction action)
    {
        KnownActions.Add(action);
    }

    /// <summary>
    /// Peux être override
    /// On choisit un objectif dans l'ordre des prioritées
    /// ex : manger, ensuite dormir etc ...
    /// </summary>
    /// <returns>Un objectif sous forme de liste d'états</returns>
    public virtual List<State> FindGoapGoal()
    {
        State? unsatisfiedNeed = GoapNeeds.GetFirstUnsatisfiedGoal();
        if (unsatisfiedNeed.HasValue)
            return [unsatisfiedNeed.Value];

        // Attendre
        return [];
    }

    /// <summary>
    /// Met a jour le plan actuelle
    /// selon l'objectif GOAP
    /// </summary>
    public virtual void UpdateGoapPlan()
    {
        if (CurrentGoal.Count > 0)
        {
            CurrentPlan = GoapPlanner.MakePlan(GoapStates.GetList(), CurrentGoal, KnownActions);
        }
        else
        {
            CurrentPlan = null;
        }
    }

    /// <summary>
    /// Peut être override
    /// Met à jour des états goap
    /// lié au besoins
    //// </summary>
    public virtual void UpdateGoapNeeds()
    {
        GoapNeeds.Set(new State(
            "IsHydrated",
            Stats.Water > 50
        ));

        GoapNeeds.Set(new State(
            "IsFed",
            Stats.Food > 40
        ));
    }

    /// <summary>
    /// Peux être override
    /// Met à jour tout les états goap 
    /// (a appelé avant les calcules du goap)
    /// </summary>
    public virtual void UpdateGoapStates()
    {
        
    }
    
    // -----------------------------------
    // Tick
    // -----------------------------------

    /// <summary>
    /// Est appelé à chaque tick avec le delta
    /// </summary>
    /// <param name="deltaTime">La durée à simuler</param>
    public virtual void Tick(float deltaTime)
    {
        // Modifications de stats
        Stats.Food -= deltaTime; // 1 par secondes
        Stats.Water -= deltaTime * 1.2f;

        // > Goap : réflexion
        // Mise à jour des états
        UpdateGoapNeeds(); 
        UpdateGoapStates();
        // Choix d'un objectif
        CurrentGoal = FindGoapGoal();
        
        // > Goap : Création de plan
        UpdateGoapPlan();

        // > Goap : execution
        // Acomplissement de la première étape du plan

    }
    
}