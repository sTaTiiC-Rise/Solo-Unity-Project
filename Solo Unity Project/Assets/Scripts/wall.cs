using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;

public class wall : MonoBehaviour
{
    private Vector3 Position;
    private Quaternion Rotation;
    public GameObject Wall;
    private bool dontPlace;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.GetLocalPositionAndRotation(out Vector3 pos, out Quaternion rot);//
        Position = transform.position;
        Rotation = transform.rotation;
        // Position = pos;//
        // Rotation = rot;//
        if (Input.GetKeyDown(KeyCode.Mouse1) && dontPlace == false)
        {
            GameObject newObject = Instantiate(Wall, Position, Rotation) as GameObject;
            dontPlace = true;
            StartCoroutine(weight());
        }
    }
    private IEnumerator weight()
    {
        yield return new WaitForSeconds(1f);
        dontPlace = false;
    }
}
