using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitIntro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForIntro());
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    IEnumerator WaitForIntro()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Intro2");
    }
}
