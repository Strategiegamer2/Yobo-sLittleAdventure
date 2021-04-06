using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColliderTrigger : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player inside Trigger");
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
        }
    }
}
