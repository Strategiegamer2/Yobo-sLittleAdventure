using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUprespawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Health;
    public GameObject Speed;
    public GameObject Invin;
    public int healthInt;// How many power ups left
    public int SpeedInt;
    public int InvinInt;
    public float HealthTime;// Time before spawning back
    public float SpeedTime;// Time before spawning back
    public float InvinTime;// Time before spawning back


    float Count1;// Counter
     float Count2;
     float Count3;
    void Start()
    {
        Count1 = HealthTime;
        Count2 = SpeedTime;
        Count3 = InvinTime;
        Instantiate(Health, new Vector3(4.382f, 11.023f, 8.18f), Quaternion.identity);
        Instantiate(Speed, new Vector3(-24.9f, -7.89f, 8.22f), Quaternion.identity);
        Instantiate(Invin, new Vector3(33.01f, -7.89f, 8.22f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // This is the power up respawn. The Healthint is being changed in the playermovement script. 
        if (healthInt == 0)
        {

            Count1  -= 1 * Time.deltaTime; // Counting down
            if (Count1 <= 0)
            {
                
                Count1 = HealthTime;
                Instantiate(Health, new Vector3(4.382f, 11.023f, 8.18f), Quaternion.identity); // Respawn
                Debug.Log("Respawn");
                healthInt++;
            }

        }
        if (SpeedInt == 0)
        {

            Count2  -=1 * Time.deltaTime;
            if (Count2 <= 0)
            {
                SpeedInt++;
                Count2 = SpeedTime;
                Instantiate(Speed, new Vector3(-24.9f, -7.89f, 8.22f), Quaternion.identity);
            }

        }
        if (InvinInt == 0)
        {

            Count3  -=1 * Time.deltaTime;
            if (Count3 <= 0)
            {
                InvinInt++;
                Count3 = InvinTime;
                Instantiate(Invin, new Vector3(33.01f, -7.89f, 8.22f), Quaternion.identity);
            }

        }
    }
}
