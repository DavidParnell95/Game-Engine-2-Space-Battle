using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseShip : MonoBehaviour
{
    [SerializeField]Transform target;
    [SerializeField]float speed = 10.0f;
    [SerializeField]float rotationalDamp = .5f;

    [SerializeField]float detectDistance = 20f;
    [SerializeField]float rayCastOffset = 2.5f;

    void Update()
    {
        PathFinding();

        //Turn();
        Move();
    }

    

    void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, 
        rotation,
        rotationalDamp * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void PathFinding()
    {
        RaycastHit hit;
        Vector3 raycastOff = Vector3.zero;

        //RayCast initialization 
        Vector3 left = transform.position - transform.right * rayCastOffset;
        Vector3 right = transform.position + transform.right * rayCastOffset;
        Vector3 up = transform.position + transform.up * rayCastOffset;
        Vector3 down = transform.position - transform.up * rayCastOffset;

        //Draw Raycasts
        Debug.DrawRay(left,transform.forward * detectDistance, Color.cyan);
        Debug.DrawRay(right,transform.forward * detectDistance, Color.cyan);
        Debug.DrawRay(up,transform.forward * detectDistance, Color.cyan);
        Debug.DrawRay(down,transform.forward * detectDistance, Color.cyan);

        if(Physics.Raycast(left, transform.forward, out hit, detectDistance))
        {
            raycastOff += Vector3.right;

        }

        else if(Physics.Raycast(right, transform.forward, out hit, detectDistance))
        {
            raycastOff -= Vector3.right;
            
        }

        if(Physics.Raycast(up, transform.forward, out hit, detectDistance))
        {
            raycastOff -= Vector3.up;

        }

        else if(Physics.Raycast(down, transform.forward, out hit, detectDistance))
        {
            raycastOff += Vector3.up;
            
        }

        if(raycastOff != Vector3.zero)
        {
            transform.Rotate(raycastOff * 5f * Time.deltaTime);
        }

        else
        {
            Turn();
        }
    }

}