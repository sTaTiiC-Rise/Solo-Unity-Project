using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Weapon : MonoBehaviour
{
    public PlayerMovement player;

    public GameObject projectile;
    public AudioSource weaponSpeaker;
    public Transform firePoint;
    public Camera firingDirection;

    [Header("Meta Attributes")]
    public bool canFire = true;
    public int weaponID;
    public string weaponName;

    [Header("Weapon Stats")]
    public float damage;
    public float projLifespan;
    public float projVelocity;
    public float reloadCooldown;
    public float rof;
    public int fireModes;
    public int currentFireMode;
    public int clip;
    public int clipSize;

    [Header("Ammo Stats")]
    public int ammo;
    public int maxAmmo;
    public int ammoRefill;


    void Start()
    {
        weaponSpeaker = GetComponent<AudioSource>();
        firePoint = transform.GetChild(0);
    }

    public void fire()
    {
        if(canFire && clip > 0 && weaponID > -1)
        {
            weaponSpeaker.Play();
            GameObject p = Instantiate(projectile, firePoint.position, firePoint.rotation);
            p.GetComponent<Rigidbody>().AddForce(firingDirection.transform.forward * projVelocity);
            Destroy(p, projLifespan);
            clip--;
            canFire = false;
            StartCoroutine("cooldownFire", rof);
        }

        else if (canFire && weaponID <= -1)
        {
            weaponSpeaker.Play();
            GameObject p = Instantiate(projectile, firePoint);
            Destroy(p, projLifespan);
            canFire = false;
            StartCoroutine("cooldownFire", rof);
        }
    }

    public void reload()
    {
        if (clip >= clipSize)
            return;

        else
        {
            int reloadCount = clipSize - clip;

            if (ammo < reloadCount)
            {
                clip += ammo;
                ammo = 0;
            }

            else
            {
                clip += reloadCount;
                ammo -= reloadCount;
            }

            StartCoroutine("cooldownFire", reloadCooldown);
            return;
        }
    }

    public void equip(PlayerMovement player)
    {
        player.currentWeapon = this;

        transform.SetPositionAndRotation(player.weaponSlot.position, player.weaponSlot.rotation);
        transform.SetParent(player.weaponSlot);

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;

        firingDirection = Camera.main;
        this.player = player;
    }

    public void unequip() //im rubbing peanut butter on my cock
    {
        player.currentWeapon = null;

        transform.SetParent(null);

        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;

        firingDirection = null;
                this.player = null;
    }

    IEnumerator cooldownFire(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        
        if(clip > 0 || weaponID <= -1)
            canFire = true;
    }
}
