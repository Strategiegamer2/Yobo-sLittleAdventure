using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{
    [Header("Text")]
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    public TextMeshProUGUI youDied;


    public void Start()
    {
        youDied.enabled = false;
    }

    void Update()
    {
        if (health > numOfHearts) // health can't be more than the number of hearts, if it is:
        {
            health = numOfHearts; // make it the same
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHearts;//the full hearts you have, if you have 5 health, you have 5 hearts(you can't have more healt than hearts)
            }
            else
            {
                hearts[i].sprite = emptyHearts;//take damage, heart changes to empty heart 
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (health <= 0)
        {
            Time.timeScale = 0; //stops game
            StartCoroutine(YouDied());
        }
    }

    IEnumerator YouDied()
    {
        youDied.enabled = true;
        yield return new WaitForSecondsRealtime(5);
        youDied.enabled = false;
        Time.timeScale = 1; // resume game
        SceneManager.LoadScene("Death"); 
    }
}
