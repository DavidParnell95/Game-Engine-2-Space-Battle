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
    public Transform[] asteroidPref;//Asteroid object
    public Transform debrisPrefA;
    public Transform debrisPrefB;

    public int fieldRadius = 100;
    public int count = 250;//number of asteroids to generate 
    public int debrisCount = 15;

    [Range(1f,100f)]
    public float minAsteroirdScale = 2;
    [Range(1f,100f)]
    public float maxAsteroirdScale =10 ;

    private int selection;
    

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < count; i++)
        {
            /*
            Instantiate the asteroid, at a random point around the 
            center of the field, with a random rotation 
            */
            selection = Random.Range(0,3);

            Transform tempAst =Instantiate(asteroidPref[selection], Random.insideUnitSphere * 
            fieldRadius, Random.rotation);

            //Scale asteroid, to make asteroids different sizes
            tempAst.localScale = tempAst.localScale * Random.Range(minAsteroirdScale,maxAsteroirdScale);
            //Set as child of AsteroidField, makes menue cleaner
            tempAst.transform.parent = GameObject.Find("Asteroids").transform;
        }

        for(int j = 0; j<(debrisCount/2); j++)
        {
            Transform tempDeb =Instantiate(debrisPrefA, Random.insideUnitSphere * 
            fieldRadius, Random.rotation);

            //Scale debris, to make debris different sizes
            tempDeb.localScale = tempDeb.localScale * Random.Range(0.5f,5);
            //Set as child of debris, makes menue cleaner
            tempDeb.transform.parent = GameObject.Find("Debris").transform;
        }

        for(int j = 0; j<(debrisCount/2); j++)
        {
            Transform tempDeb =Instantiate(debrisPrefB, Random.insideUnitSphere * 
            fieldRadius, Random.rotation);

            //Scale debris, to make debris different sizes
            tempDeb.localScale = tempDeb.localScale * Random.Range(0.5f,5);
            //Set as child of debris, makes menue cleaner
            tempDeb.transform.parent = GameObject.Find("Debris").transform;

        }
    }
}
