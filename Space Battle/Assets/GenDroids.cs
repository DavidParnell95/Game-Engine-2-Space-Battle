using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenDroids : MonoBehaviour
{
    public Transform droidPref;//Asteroid object
    public int fieldRadius = 100;
    public int count = 20;//number of asteroids to generate 

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < count; i++)
        {
            /*
            Instantiate the asteroid, at a random point around the 
            center of the field, with a random rotation 
            */
            Transform tempDroid =Instantiate(droidPref, Random.insideUnitSphere * 
            fieldRadius, Random.rotation);

            //Set as child of AsteroidField, makes menue cleaner
            tempDroid.transform.parent = GameObject.Find("Droids").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
