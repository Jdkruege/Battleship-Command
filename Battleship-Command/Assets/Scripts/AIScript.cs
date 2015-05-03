using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AIScript : MonoBehaviour
{
    public abstract bool CanShoot();

    public abstract void Shoot(GameObject ammo);
}
