using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Audio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("audio"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
