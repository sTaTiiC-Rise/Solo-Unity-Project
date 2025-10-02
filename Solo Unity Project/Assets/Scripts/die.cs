using UnityEngine;
using UnityEngine.SceneManagement;

public class die : MonoBehaviour
{
    public int health = 2;
    public int maxHealth = 1;

    public float lifetime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;

        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if (other.tag == "enemy")
        {
            Debug.Log("Enemy Collided");
            health -= 1;
        }
    }
}
