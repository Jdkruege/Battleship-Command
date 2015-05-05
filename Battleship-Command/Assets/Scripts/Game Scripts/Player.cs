﻿using UnityEngine;
using System.Collections.Generic;


public class Player : MonoBehaviour {
    private static Player playerinstance;

    Vector3 pastPosition;
    Transform joystick;
    float currentrot;

    public float rotspeed;
    public float speed;

    private GameObject controller;

    Rigidbody2D body;

    private int targetCount;
    LinkedList<IsTargetable> targetQueue;


    protected List<GameObject> guns;
    //This is the index of the gun that is assigned to the oldest target
    private int oldestGun=0;

    private bool joystickenabled= false;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        joystick = transform.FindChild("MobileSingleStickControl").gameObject.transform.FindChild("MobileJoystick").gameObject.transform;
        pastPosition = joystick.transform.position;
        currentrot = 0;

        targetQueue = new LinkedList<IsTargetable>();
        targetCount = 0;

        controller = GameObject.Find("Controller");

        guns = new List<GameObject>();

        if (guns.Count == 0)
        {
            for (int i = -1; i < 2; i++)
            {
                GameObject gun = Instantiate(controller.GetComponent<Resources>().gun);
                gun.transform.parent = this.transform;
                gun.transform.position = this.transform.position + new Vector3(0f, 0.82f * i, 0f);
                gun.GetComponent<Gun>().target = this.gameObject;
                gun.GetComponent<Gun>().ammo = controller.GetComponent<Resources>().allyBullet;
                gun.GetComponent<Gun>().range = 15;
                gun.GetComponent<Gun>().cooldown = 60;
                gun.GetComponent<Gun>().enabled = false;
                guns.Add(gun);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        steer();
	}


    private void steer()
    {
        if (joystickenabled)
        {
            float forwardvel = (joystick.transform.position - pastPosition).y / 1000;
            body.MovePosition(transform.position + transform.up * forwardvel);


            float rotvel = (joystick.transform.position - pastPosition).x / 200;
            currentrot -= rotvel;
            body.MoveRotation(currentrot);
        }


        body.velocity = speed * transform.up * Input.GetAxis("Vertical");
        body.angularVelocity = -1 * rotspeed * Input.GetAxis("Horizontal"); 

    }

    public static Player getPlayer()
    {
        if (playerinstance == null)
        {
            playerinstance = GameObject.FindObjectOfType<Player>();
        }
        return playerinstance;
    }


    internal void targetShip(IsTargetable target)
    {
        //Add another reticle on top of the targetted object
        GameObject reticle = Instantiate(controller.GetComponent<Resources>().reticle);
        reticle.transform.parent = target.transform;
        reticle.transform.position = target.transform.position;
        reticle.transform.name = "Reticle";
        reticle.layer = 1;
        targetQueue.AddLast(target);

        guns[oldestGun].GetComponent<Gun>().target = target.gameObject;
        guns[oldestGun].GetComponent<Gun>().enabled = true;
        oldestGun++;
        if (oldestGun >= guns.Count)
            oldestGun = 0;

        // if we have more than three targets, forget the oldest, destroying one of it's reticles
        if (targetCount >= guns.Count)
        {

            IsTargetable detarget = targetQueue.First.Value;
            
            //If the targetted ship still exists
            if (detarget)
            {
                Destroy(detarget.transform.FindChild("Reticle").gameObject);
            }

            targetQueue.RemoveFirst();
        }
        else
        {
            targetCount++;
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
       

       if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
