using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour
{
    Flock agentFlock;
    public Flock AgentFlock {get {return agentFlock;} }

    Collider agentCollider;
    public Collider AgentCollider {get {return agentCollider;}}

    // Start is called before the first frame update
    void Start()
    {
        //Get object Collider
        agentCollider = GetComponent<Collider>();
    }

    public void Initialize(Flock flock)
    {
        agentFlock = flock;
    }

    public void Move(Vector3 target)
    {
        transform.forward = target;//rotate to look at target
        transform.position += target * Time.deltaTime;
    }
}
