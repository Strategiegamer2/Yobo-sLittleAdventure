using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Audio1 : MonoBehaviour
{
    private GameObject Audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Audio = GameObject.Find("audio");
        Destroy(Audio);
    }
}
