using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipAI : AIScript
{
    private GameObject controller;
    private Rigidbody2D rigidBody;
    private int timeOut;
    private int interval;
    public float speed;
    public float rotspeed;

	public override void Start()
    {
        guns = new List<GameObject>();
        controller = GameObject.Find("Controller");
        rigidBody = GetComponent<Rigidbody2D>();
        interval = 60;
        timeOut = interval;

        for (int i = -1; i < 2; i++)
        {
            GameObject gun = Instantiate(controller.GetComponent<Resources>().gun);
            gun.transform.parent = this.transform;
            gun.transform.position = this.transform.position + new Vector3(0f, 0.82f * i, 0f);
            gun.GetComponent<Gun>().target = Player.getPlayer().gameObject;
            gun.GetComponent<Gun>().ammo = controller.GetComponent<Resources>().enemyBullet;
            gun.GetComponent<Gun>().range = 10;
            gun.GetComponent<Gun>().cooldown = 60;
            gun.GetComponent<Gun>().enabled = true;
            guns.Add(gun);
        }
    }
	
	public override void Update ()
    {
        Move();
	}

    public override void Move()
    {
        Vector2 direction = Player.getPlayer().GetComponent<Rigidbody2D>().position - rigidBody.position;
        float distance = direction.magnitude;

        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        float facing = Mathf.Atan2(transform.up.x, transform.up.y) * Mathf.Rad2Deg;
        rigidBody.MoveRotation(rigidBody.rotation + ((facing - angle) * rotspeed));
        print((angle - rigidBody.rotation) * rotspeed);

        if (distance < 10 && distance > 6)
        {
            rigidBody.velocity = speed * transform.up;
        }
    }


}
