using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Flock/Behavior/Stay In Radius")]
public class StayInRadius : FlockBehavior
{
    GameObject fieldCenter;
    Vector3 center;
    public float radius = 50f;
    
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        fieldCenter  = GameObject.Find("FieldCenter");
        Debug.Log(fieldCenter.ToString());
        Transform fieldTransform = fieldCenter.transform;
        center = fieldTransform.position;

        Vector3 centerOffset = center - agent.transform.position;
        float t = centerOffset.magnitude / radius;

        //If not too far, no adjustment needed
        if(t < .9f)
        {
            return Vector3.zero;
        }

        return centerOffset * t * t; 
    }

}
