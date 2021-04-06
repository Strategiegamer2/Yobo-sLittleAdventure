using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMove_Yobo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move()
    {
        GameObject Player = GameObject.Find("Player");
        Move_Character_MainMenu CanMoveScript = Player.GetComponent<Move_Character_MainMenu>();
        CanMoveScript.CanMove = true;
    }

}
