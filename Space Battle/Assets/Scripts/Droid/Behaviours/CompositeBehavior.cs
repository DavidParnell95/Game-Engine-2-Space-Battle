using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehavior : FlockBehavior
{
    public FlockBehavior[] behaviors;
    public float[] weights;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //Check if same number of weights as behaviors
        if(weights.Length != behaviors.Length)
        {
            Debug.LogError("Data mismatch: " +name,this);
            return Vector3.zero;
        }

        //Set up move
        Vector3 move = Vector3.zero;

        //iterate through behaviors
        for(int i = 0; i< behaviors.Length; i++)
        {
            Vector3 partMove = behaviors[i].CalculateMove(agent,context,flock) * weights[i];

            //If some movement
            if(partMove != Vector3.zero)
            {
                if(partMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partMove.Normalize();
                    partMove *= weights[i];
                }

                move += partMove;
            }
        }

        return move;
    }
}
