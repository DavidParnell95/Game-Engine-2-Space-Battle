using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysAsteroid : MonoBehaviour
{
    public float minSpinSpeed = 1f;
    public float maxSpinspeed = 5f;
    public float minMovSpeed = .1f; 
    public float maxMovSpeed = .5f; 
    private float spinSpeed;
    // Update is called once per frame

    void Start()
    {
        spinSpeed = Random.Range(minSpinSpeed,maxSpinspeed);
        float thrust = Random.Range(minMovSpeed,maxMovSpeed);

        Rigidbody rg = GetComponent<Rigidbody>();
        rg.AddForce(transform.forward * thrust, ForceMode.Impulse);
    }
    void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}