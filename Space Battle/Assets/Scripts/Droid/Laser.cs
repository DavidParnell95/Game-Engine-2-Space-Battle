using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    [SerializeField]float laserOffTime =.5f;
    [SerializeField]float range = 300f;

    LineRenderer lr;
    Light laserLight;

    bool canFire;

    void Awake(){
        lr = GetComponent<LineRenderer>();
        laserLight = GetComponent<Light>();

    }

    // Update is called once per frame
    void Start()
    {
        lr.enabled = false;
        laserLight.enabled = false;
    }

    public void FireLaser(Vector3 targetPosition)
    {
        if(canFire)
        {
            lr.SetPosition(0,transform.position);
            lr.SetPosition(1,targetPosition);
            laserLight.enabled = true;
            canFire = false;
        }

        Invoke("TurnOffLaser", laserOffTime);
        Invoke("CanFire", fireDelay);
    }

    void TurnOffLaser()
    {
        lr.enabled = false;
        laserLight.enabled = true;
        canFire = true;
    }

    public float Distance
    {
        get {return maxDistance}
    }
}
