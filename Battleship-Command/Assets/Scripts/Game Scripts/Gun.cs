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
    private int timeOut=0;

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
        float distance = (target.GetComponent<Rigidbody2D>().position - this.GetComponent<Rigidbody2D>().position).magnitude;
        if (enabled)
        {
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
        else
            return false;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(ammo);
        bullet.transform.position = transform.position;
        bullet.GetComponent<Bullet>().direction = (target.GetComponent<Rigidbody2D>().position - this.GetComponent<Rigidbody2D>().position).normalized;
        bullet.GetComponent<Bullet>().origin = this.GetComponent<Rigidbody2D>().position;
    }


}
