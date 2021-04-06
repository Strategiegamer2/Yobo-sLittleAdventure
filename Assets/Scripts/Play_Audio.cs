using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Audio : MonoBehaviour
{
    public AudioSource Hell;
    public AudioSource Invis;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "invincible")
        {

        }
    }
}
