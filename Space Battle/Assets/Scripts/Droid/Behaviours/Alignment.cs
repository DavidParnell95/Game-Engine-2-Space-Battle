using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class Alignment : FilteredFlockBehavior
{
     //Implement Calculate move so it can inherit from FlockBehavior
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, 
        Flock flock)
    {
        //If no neighbours, maintain current allignment
        if(context.Count == 0)
        {
            return agent.transform.forward;
        }

        //Add context members and avg out
        Vector3 alighnmentMove = Vector3.zero;
            
        //Check if filter, apply, if not, normal context
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent,context);
            
        //iterate through members and add
        foreach(Transform item in filteredContext)
        {
            alighnmentMove += item.transform.forward;
        }

        //Get avg
        alighnmentMove /= context.Count;
        return alighnmentMove;
    }

}
