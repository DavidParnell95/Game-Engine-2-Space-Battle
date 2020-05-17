using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class Avoidance : FlockBehavior
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
        Vector3 avoidanceMove = Vector3.zero;

        int nAvoid = 0; // number of objects to avoid 
            
        //iterate through members and add
        foreach(Transform item in context)
        {
            if(Vector3.SqrMagnitude(item.position - agent.transform.position) < flock.SquareAvoidanceRadius)
            {
                nAvoid++;
                avoidanceMove += (agent.transform.position - item.position);
            }
            
        }

        if(nAvoid > 0)
        {
            avoidanceMove /= nAvoid;
        }

        return avoidanceMove;
    }

}
