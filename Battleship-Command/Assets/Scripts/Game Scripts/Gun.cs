using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    private GameObject parent;

    public GameObject target;
    public GameObject ammo;

	public void Start ()
    {
        parent = transform.parent.gameObject;
	}
	
	public void Update ()
    {
        if (parent.GetComponent<AIScript>().CanShoot(this.gameObject))
        {
            parent.GetComponent<AIScript>().Shoot(this.gameObject);
        }
	}
}
