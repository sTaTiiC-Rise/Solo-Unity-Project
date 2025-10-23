using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour
{
    //public GameObject enemyHolder;

    public GameObject enemygrp;

    public Transform pos;

    public bool isDelaying = false;
    public float delayTime;
    public float delayIncrement = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // enemyHolder.SetActive(false);'
        StartCoroutine(Retard());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDelaying)
            StartCoroutine(Retard());
    }
    private void OnTriggerEnter(Collider other)
    {
       /*if (other.gameObject.tag == "Player")
            enemyHolder.SetActive(true);*/
    }
    IEnumerator Retard()
    {
        Debug.Log("Started");

        Instantiate(enemygrp, pos);
        isDelaying = true;
        Debug.Log("Spawned");
        yield return new WaitForSeconds(delayTime);
        if (delayTime >= 0.5)
        {
            delayTime -= delayIncrement;
            delayIncrement += 0.1f;
        }
        else
        {
            delayTime = 1f;
        }

            isDelaying = false;
    }
}
