using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile resourcePileForward;
    public float ProductivityMultiplier = 2;
    protected override void BuildingInRange()
    {
        if(resourcePileForward == null)
        {
            ResourcePile pile = m_Target as ResourcePile;
            if(pile != null)
            {
                resourcePileForward = pile;
                resourcePileForward.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }
    void ResetProductivity()
    {
        if (resourcePileForward != null)
        {
            resourcePileForward.ProductionSpeed /= ProductivityMultiplier;
            resourcePileForward = null;
        }
    }
    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }
    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }
}
