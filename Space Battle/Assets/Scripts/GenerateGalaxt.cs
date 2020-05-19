using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGalaxt : MonoBehaviour
{
    public Transform[] planets;
    public Transform galaxy;
    public Transform nebula;

    public int planetCount = 10;
    public int galaxyCount = 5;
    public int nebulaCount = 10; 

    public int fieldRadius = 100;
    private int selection;

    [Range(1f,100f)]
    public float minScale = 2;
    [Range(1f,100f)]
    public float maxScale =10 ;

    //GalaxtScale
    [Range(1f,100f)]
    public float minGalScale = 2;
    [Range(1f,100f)]
    public float maxGalScale =10 ;

    void Start()
    {
        //Generate Planets
        for(int i =0; i < planetCount; i++)
        {
            selection = Random.Range(0,3);
            Transform tempPlan =Instantiate(planets[selection], Random.insideUnitSphere * 
            fieldRadius, Random.rotation);

            //Scale asteroid, to make different sizes
            tempPlan.localScale = tempPlan.localScale * Random.Range(minScale,maxScale);
            tempPlan.transform.parent = GameObject.Find("Planets").transform;
        }

        //Generate Galaxies
        for(int i =0; i < galaxyCount; i++)
        {
            selection = Random.Range(0,3);
            Transform tempGal =Instantiate(galaxy, Random.insideUnitSphere *
            fieldRadius, Random.rotation);

            //Scale asteroid, to make different sizes
            tempGal.localScale = tempGal.localScale * Random.Range(minGalScale,maxGalScale);
            tempGal.transform.parent = GameObject.Find("Galaxies").transform;
        }

        //Generate Nebula
        for(int i =0; i < nebulaCount; i++)
        {
            selection = Random.Range(0,3);
            Transform tempNeb =Instantiate(nebula, Random.insideUnitSphere * 
            fieldRadius, Random.rotation);

            //Scale asteroid, to make different sizes
            tempNeb.localScale = tempNeb.localScale * Random.Range(minGalScale,maxGalScale);
            tempNeb.transform.parent = GameObject.Find("Nebulas").transform;
        }

    }
}
