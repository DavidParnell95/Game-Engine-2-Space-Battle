using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]Transform target;
    [SerializeField]Laser laser;

    Vector3 hitPos;

    // Update is called once per frame
    void Update()
    {
        InFront();
        HaveLineOfSight();

        if(InFront() && HaveLineOfSight())
        {
            FireLazer();
        }
    }

    bool InFront()
    {
        Vector3 targetDirection = transform.position - target.position;//find direction to target
        float angle = Vector3.Angle(transform.forward, targetDirection);

        //If in FOV
        if(Mathf.Abs(angle) >90 && Mathf.Abs(angle) <270)
        {
            Debug.DrawLine(transform.position, target.position, Color.red);
            return true;
        }

        Debug.DrawLine(transform.position,target.position, Color.green);
        return false;
    }

    bool HaveLineOfSight()
    {
        RaycastHit hit;

        Vector3 direction = target.position - transform.position;

        if(Physics.Raycast(laser.transform.position, direction, out hit, laser.Distance))
        {
            if(hit.transform.CompareTag("ship"))
            {
                Debug.DrawRay(laser.transform.position, direction,Color.blue);
                hitPos = hit.transform.position;
                return true;
            }
        }

        return false;
    }

    void FireLazer()
    {
        Debug.Log("Fire the Laser (☞ﾟ∀ﾟ)☞");
        laser.FireLaser(hitPos);
    }
}
