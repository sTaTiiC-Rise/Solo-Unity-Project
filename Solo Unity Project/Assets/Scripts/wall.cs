using UnityEngine;

public class wall : MonoBehaviour
{
    private Vector3 Position;
    private Quaternion Rotation;
    public GameObject Wall;
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
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject newObject = Instantiate(Wall, Position, Rotation) as GameObject;
        }
    }
}
