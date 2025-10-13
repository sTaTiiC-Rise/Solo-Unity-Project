using UnityEngine;

public class sword : Weapon
{
    public float knockback = 3f;

    /*private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if(this.player)
        {
            if(this.player.attacking && other.gameObject.tag == "enemy")
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * knockback);
            }
        }
    }*/
}
