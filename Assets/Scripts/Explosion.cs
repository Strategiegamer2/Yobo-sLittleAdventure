using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public float explodeTime;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        explodeTime -= Time.deltaTime;
        if (explodeTime <= 0)
        {
            Destroy(gameObject);
         
        }
   
    }

}

