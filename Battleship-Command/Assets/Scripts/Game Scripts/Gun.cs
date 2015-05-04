using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    private GameObject parent;

    public GameObject target;
    public GameObject ammo;
    public float range;
    public bool enabled;
    public int cooldown;
    private int timeOut;

	public void Start ()
    {
        parent = transform.parent.gameObject;
	}
	
	public void Update ()
    {
        if (CanShoot())
        {
           Shoot();
        }
	}

    private bool CanShoot()
    {
        float distance = (player.GetComponent<Rigidbody2D>().position - rigidBody.position).magnitude;

        if (timeOut > 0)
        {
            timeOut--;
            return false;
        }
        else
        {
            timeOut = cooldown;
            return (distance < range);
        }
    }

    private override void Shoot()
    {
        GameObject bullet = Instantiate(ammo);
        bullet.transform.position = transform.position;
        bullet.GetComponent<Bullet>().direction = (target.GetComponent<Rigidbody2D>().position - gun.GetComponent<Rigidbody2D>().position).normalized;
        bullet.GetComponent<Bullet>().origin = gun.GetComponent<Rigidbody2D>().position;
    }


}
