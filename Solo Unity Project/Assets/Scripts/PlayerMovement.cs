using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Vector2 cameraRotation;
    Vector3 cameraOffSet;
    InputAction lookVector;
    Transform playerCam;
    Rigidbody rb;
    Transform camHolder;
    Ray jumpRay;
    Ray interactRay;
    RaycastHit interactHit;
    GameObject pickupObj;
    public PlayerInput input;
    public Transform weaponSlot;
    public Weapon currentWeapon;

    float verticalMove;
    float horizontalMove;

    public float speed = 5f;
    public float jumpHeight = 50f;
    public float interactDistance = 1f;
    public float Xsensitivity = 1.0f;
    public float Ysensitivity = 1.0f;
    public float camRotationLimit = 90.0f;
    public bool locked = true;
    public bool attacking = false;
    public int health = 5;
    public int maxHealth = 5;

    public void Start()
    {
        input = GetComponent<PlayerInput>();
        jumpRay = new Ray(transform.position, -transform.up);
        cameraOffSet = new Vector3(0, .7f, .4f);
        rb = GetComponent<Rigidbody>();
        playerCam = Camera.main.transform;
        interactRay = new Ray(playerCam.transform.position, playerCam.transform.forward);
        lookVector = GetComponent<PlayerInput>().currentActionMap.FindAction("Look");
        cameraRotation = Vector2.zero;
        camHolder = transform.GetChild(0);
        weaponSlot = playerCam.transform.GetChild(0);

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        Quaternion playerRotation = playerCam.transform.rotation;

        playerRotation.x = 0;
        playerRotation.z = 0;

        transform.localRotation = playerRotation;

        //movement system
        Vector3 temp = rb.linearVelocity;

        temp.x = verticalMove * speed;
        temp.z = horizontalMove * speed;

        rb.linearVelocity = (temp.x * transform.forward) +
                            (temp.y * transform.up) +
                            (temp.z * transform.right);

        interactRay.origin = playerCam.transform.position;
        interactRay.direction = playerCam.transform.forward;

        if (Physics.Raycast(interactRay, out interactHit, interactDistance))
        {
            if (interactHit.collider.gameObject.tag == "weapon")
            {
                pickupObj = interactHit.collider.gameObject;

                Debug.Log("SEEN");
            }
        }
        else
            pickupObj = null;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (locked)
            {
                Cursor.lockState = CursorLockMode.None;
                locked = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                locked = true;
            }


        }

        //Jump
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(jumpHeight * transform.up * 10);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 inputAxis = context.ReadValue<Vector2>();

        verticalMove = inputAxis.y;
        horizontalMove = inputAxis.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "deathBox")
            health = 0;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy")
            health = health - 1;
    }
    public void Attack()
    {
        if(currentWeapon)
        {
            currentWeapon.fire();

            attacking = true;
        }
    }
    public void Interact()
    {
        if (pickupObj)
        {
            if (pickupObj.tag == "weapon")
                pickupObj.GetComponent<Weapon>().equip(this);
        }
    }
    public void DropWeapon()
    {
        if (currentWeapon)
        {
            currentWeapon.GetComponent<Weapon>().unequip();
        }
    }
}