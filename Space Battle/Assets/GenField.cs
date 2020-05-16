/**** GenField ****
Script to generate an asteroid field
using a prefab, around an object.
In this case, an empty game object named:
Field Center
*****************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenField : MonoBehaviour
{
    public Transform asteroidPref;//Asteroid object
    public int fieldRadius = 100;
    public int count = 250;//number of asteroids to generate 

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < count; i++)
        {
            /*
            Instantiate the asteroid, at a random point around the 
            center of the field, with a random rotation 
            */
            Transform tempAst =Instantiate(asteroidPref, Random.insideUnitSphere * 
            fieldRadius, Random.rotation);

            //Scale asteroid, to make asteroids different sizes
            tempAst.localScale = tempAst.localScale * Random.Range(0.5f,5);
            //Set as child of AsteroidField, makes menue cleaner
            tempAst.transform.parent = GameObject.Find("Asteroids").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
