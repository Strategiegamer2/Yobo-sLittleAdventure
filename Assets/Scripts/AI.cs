using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    NavMeshAgent agent;
    public GameObject boom;
    public int EnemyHp;
    public GameObject DeathEnemy;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //With this line of code the enemy follows the player on a walkeble mesh
      
        agent.SetDestination(target.position);
        //
        // This code flips the enemy of it goes left or right.
        if (agent.velocity.x <= -0.1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }
        if (agent.velocity.x >= 0.1f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }
        if (EnemyHp <= 0)
        {

            Death();
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Instantiate(boom, transform.position, transform.rotation);
            Debug.Log("Boom");
            Destroy(gameObject);
           
        }
        if (coll.gameObject.tag == "Bullet")
        {
            EnemyHp--;
            Destroy(coll.gameObject);


        }

    }
   // This will spawn a enemy body if its dead and destroys the enemy. and it adds score
    void Death()
    {
        Instantiate(DeathEnemy, transform.position, transform.rotation);
        FindObjectOfType<ScoreHandler>().RaiseScore(1); //raiseScore by one
        Destroy(gameObject);
    }
}
