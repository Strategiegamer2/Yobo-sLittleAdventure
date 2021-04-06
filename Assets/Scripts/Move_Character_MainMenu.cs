using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;

public class Move_Character_MainMenu : MonoBehaviour
{
    public Vector3 speed;


    public Animator ani;
    public bool CanMove;
    void Update()
    {
        if (CanMove == true)
        {

            transform.Translate(speed * Time.deltaTime);
            ani.Play("WalkLeft");
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CanMove = false;
        SceneManager.LoadScene("Hell");
    }
}
