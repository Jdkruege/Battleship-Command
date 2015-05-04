using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AIScript : MonoBehaviour
{
    protected List<GameObject> guns;

    public abstract void Start();

    public abstract void Update();

    public abstract void Move();

    public abstract bool CanShoot(GameObject gun);

    public abstract void Shoot(GameObject gun);
}
