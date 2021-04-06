using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame updat
    float h;
    float v;
    public int speed = 10;
    public int hp;
    public int Score;
    public float powerUpTimeSpeed; // Time left speer power up
    float speedPowerUpTime; // Time left speer power up
    float invincibleTime; // Time left speer power up
    public float invincibleTimeSet;
    public int speedPowerUPIntesitie;


    public bool invincible;
    public bool speedPower;
    bool CanX;
    public Animator Ani;
    
    Rigidbody2D rb;

    public AudioSource Hell;
    public AudioSource Invis;



    void Start()
    {
        Score = 0;
        rb = GetComponent<Rigidbody2D>();
        speedPowerUpTime = powerUpTimeSpeed;
        hp = 3;
        invincibleTime = invincibleTimeSet;
    }

    // Update is called once per frame
    void Update()
    {
        // This is the player control. With animation.
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if (h <= -0.1f)
        {
            Ani.SetBool("Idle", false);
            Ani.SetBool("MoveRight", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }
        if (h >= 0.1f)
        {
            Ani.SetBool("Idle", false);
            Ani.SetBool("MoveRight", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (v <= -0.1f)
        {
            Ani.SetBool("Idle", false);
            Ani.SetBool("MoveRight", true);


        }
        if (v >= 0.1f)
        {
            Ani.SetBool("Idle", false);
            Ani.SetBool("MoveRight", true);

        }
        if (h == 0 && v == 0)
        {
            Ani.SetBool("Idle", true);
            Ani.SetBool("MoveRight", false);

        }
        //
        // This is the power up system. when the player enters a trigger with the tag Invinceble this will activate same for speedpowerup
        if (invincible == true) // invincible power up with timer
        {
            invincibleTime -= Time.deltaTime;
            if (invincibleTime <= 0)
            {
                invincibleTime = invincibleTimeSet;
                invincible = false;
            }
        
        }
        if (speedPower == true)
        {
            speedPowerUpTime -= Time.deltaTime;
            if (CanX == true)
            {
                speed = speed + speedPowerUPIntesitie; // speedPowerUpIntesitied is how much speed is added to the standard speed
                CanX = false;
            }
        }
        if (speedPowerUpTime <= 0) // timer for the speed power up
        {
            speedPower = false;
            CanX = true;
            if (CanX == true)
            {
                speed = speed - speedPowerUPIntesitie;
                CanX = false;
            }
            speedPowerUpTime = powerUpTimeSpeed;
           
        }
        if (hp <= 0)
        {

            Debug.Log("Dead");
        
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(v * speed, rb.velocity.y);
        rb.velocity = new Vector2(h * speed, rb.velocity.x);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject Hearts = GameObject.Find("Healthmanager"); // find healthmanager
        Health HealthScript = Hearts.GetComponent<Health>(); //get script Health
        if (coll.gameObject.tag == "speedPower")
        {
            speedPower = true;
            CanX = true;
            Destroy(coll.gameObject);
            GameObject.FindWithTag("PowerUpRespawn").GetComponent<PowerUprespawn>().SpeedInt = 0;


        }
        if (invincible == false) // if the power up invincible is not active you take damage.
        {
            if (coll.gameObject.tag == "Enemy")
            {
                HealthScript.health -= 1; // health -1, so -1 heart
            }
        }
        if (coll.gameObject.tag == "Health" && HealthScript.health < 4) // makes it so that you can't pick up the health item if you have the max hearts(4)
        {
            Destroy(coll.gameObject);
            HealthScript.health += 1; // plus 1 heart 

            GameObject.FindWithTag("PowerUpRespawn").GetComponent<PowerUprespawn>().healthInt = 0;

        }
        if (coll.gameObject.tag == "invincible")
        {
            Hell.Pause(); // pause the song Hell
            invincible = true;
            Destroy(coll.gameObject);

            GameObject.FindWithTag("PowerUpRespawn").GetComponent<PowerUprespawn>().InvinInt = 0;
            StartCoroutine(Invincible_song());
           
        }
    }

    IEnumerator Invincible_song()
    {
        Invis.Play(); // play song for the invis
        yield return new WaitForSeconds(19.7f); // wait 
        Invis.Stop(); // stop
        Hell.UnPause(); // unpause
    }

}
