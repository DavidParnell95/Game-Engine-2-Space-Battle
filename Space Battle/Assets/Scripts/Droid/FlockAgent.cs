using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour
{
    Collider agentCollider;
    public Collider AgentCollider {get {return agentCollider;}}

    // Start is called before the first frame update
    void Start()
    {
        //Get object Collider
        agentCollider = GetComponent<Collider>();
    }

    public void Move(Vector3 target)
    {
        transform.forward = target;//rotate to look at target
        transform.position += target * Time.deltaTime;
    }
}
