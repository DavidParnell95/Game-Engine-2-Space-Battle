//Script to handle enemy health
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;//Starting health

    //When recieve damage, take off from health
    public void TakeDamage(float amount)
    {
        health -= amount; 

        //Check if health is 0 or less
        if(health <= 0f)
        {
            //if so die
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);//Destroy the object
    }
}
