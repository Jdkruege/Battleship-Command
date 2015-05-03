using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    private Transform parent;

    public GameObject ammo;

    public void Start()
    {
        parent = this.transform.parent;
    }

    public void Update()
    {
        if (parent.GetComponent<AIScript>().CanShoot())
        {
            parent.GetComponent<AIScript>().Shoot(ammo);
        }
    }
}
