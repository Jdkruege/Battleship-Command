using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipAI : AIScript
{
    private GameObject controller;
    private GameObject player;
    private Rigidbody2D rigidBody;
    private int timeOut;
    private int interval;
    private float speed;

	public override void Start()
    {
        guns = new List<GameObject>();
        controller = GameObject.Find("Controller");
        player = GameObject.Find("Player");
        rigidBody = GetComponent<Rigidbody2D>();
        interval = 60;
        timeOut = interval;
        speed = 0.1f;

        for (int i = -1; i < 2; i++)
        {
            GameObject gun = Instantiate(controller.GetComponent<Resources>().gun);
            gun.transform.parent = this.transform;
            gun.transform.position = this.transform.position + new Vector3(0f, 0.82f * i, 0f);
            gun.GetComponent<Gun>().target = player;
            gun.GetComponent<Gun>().ammo = controller.GetComponent<Resources>().enemyBullet;
            guns.Add(gun);
        }
    }
	
	public override void Update ()
    {
        Move();
	}

    public override void Move()
    {
        Vector2 direction = player.GetComponent<Rigidbody2D>().position - rigidBody.position;
        float distance = direction.magnitude;

        if (distance < 10 && distance > 3)
        {
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidBody.MoveRotation(angle);
            rigidBody.MovePosition(rigidBody.position + speed * direction.normalized);
        }
    }


}
