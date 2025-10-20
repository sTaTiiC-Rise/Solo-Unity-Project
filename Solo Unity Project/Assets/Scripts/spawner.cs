using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyHolder;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyHolder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            enemyHolder.SetActive(true);
    }
}
