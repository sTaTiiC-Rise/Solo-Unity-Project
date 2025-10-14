using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator myAnim;

    public int health = 2;
    public int maxHealth = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        myAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = GameObject.Find("Player").transform.position;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        /*else
        {
            if (isFollowing)
            {
                myAnim.SetBool("isAttacking", true);
            }
            else
            {
                agent.isStopped = true;
                myAnim.SetBool("isAttacking", false);
            }
        }*/

    }
    private void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.tag == "attack")
        {
            health--;
            Debug.Log("hit");
        }
    }
}