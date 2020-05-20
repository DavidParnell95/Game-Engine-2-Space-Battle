using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent droidPref;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behavior;

    [Range(10,100)]
    public int count = 20;
    const float AgentDensity = 0.08f;

    [Range(1f,100f)]
    public float speedFactor = 10f;

    [Range(1f,100f)]
    public float maxSpeed = 10f;

    //Neighbour radius
    [Range(1f,10f)]
    public float neighbourRadius = 1.5f;

    //Avoidance radius
    [Range(0f,1f)]
    public float avoidanceRadiusMult = .5f;

    //Utility variables
    float squareMaxSpeed;
    float squareNeighbourRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius {get {return squareAvoidanceRadius;}}

    public int fieldRadius = 100;

    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed*maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMult * avoidanceRadiusMult;

        for(int i =0; i < count; i++)
        {
            FlockAgent tempDroid =Instantiate(droidPref,
            UnityEngine.Random.insideUnitSphere * fieldRadius,
            UnityEngine.Random.rotation);

            //Set as child of AsteroidField, makes menue cleaner
            tempDroid.transform.parent = GameObject.Find("Droids").transform;
            tempDroid.Initialize(this);
            tempDroid.name = "Droid " +i;
            

            agents.Add(tempDroid);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //find neighbour
        foreach(FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObject(agent);
            Vector3 move = behavior.CalculateMove(agent, context, this);
            move *= speedFactor;//Speed up appropriately

            //Check if exceeds max speed
            if(move.sqrMagnitude > squareMaxSpeed)
            {
                //Adjust to max speed
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }

        //apply behaviour in response to neighbour (hey that rhymes! :D )
    }

    //Detect nearby object
    List<Transform> GetNearbyObject(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(
            agent.transform.position, 
            neighbourRadius);
        
        //Iterate through colliders and put transform into list
        foreach(Collider c in contextColliders)
        {
            //Check its not its own colliders
            if(c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }

        return context;//Return list of nearby objects
    }
}
