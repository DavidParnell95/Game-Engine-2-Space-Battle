using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class Cohesion : FlockBehavior
{
    //Implement Calculate move so it can inherit from FlockBehavior
    public override Vector3 CalculateMove(
        FlockAgent agent, List<Transform> context, 
        Flock flock)
    {
        //If no neighbours, no adjustment
        if(context.Count == 0)
        {
            return Vector3.zero;
        }

        //Add context members and avg out
        Vector3 cohesionMove = Vector3.zero;
            
        //iterate through members and add
        foreach(Transform item in context)
        {
            cohesionMove += item.position;
        }

        //Get avg
        cohesionMove /= context.Count;

        //Create offset from agent pos
        cohesionMove -= agent.transform.position;
        return cohesionMove;

    }

}
