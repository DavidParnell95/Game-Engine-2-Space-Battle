using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/SteeredCohesion")]
public class SteeredCohesion : FilteredFlockBehavior
{
    Vector3 currentVel;
    public float smoothTime = .5f;//time taken to smooth velocity

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

        //Check if filter, apply, if not, normal context
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent,context);
            
        //iterate through members and add
        foreach(Transform item in filteredContext)
        {
            cohesionMove += item.position;
        }

        //Get avg
        cohesionMove /= context.Count;

        //Create offset from agent pos
        cohesionMove -= agent.transform.position;
        cohesionMove = Vector3.SmoothDamp(agent.transform.forward, cohesionMove, 
        ref currentVel, smoothTime);

        return cohesionMove;

    }

}
