using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AIScript : MonoBehaviour
{
    protected List<Gun> guns;

    public abstract void Awake();

    public abstract void Update();

    public abstract void Move();

    public abstract bool CanShoot(Gun gun);

    public abstract void Shoot(Gun gun);
}
