using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    private static Player playerinstance;

    Vector3 pastPosition;
    Transform joystick;
    float currentrot;
    Rigidbody2D body;

    private int targetCount;
    LinkedList<IsTargetable> targetQueue;
    private GameObject controller;

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
	}
	
	// Update is called once per frame
	void Update () {
        steer();
	}


    private void steer()
    {
        float forwardvel = (joystick.transform.position - pastPosition).y / 1000;
        body.MovePosition(transform.position + transform.up * forwardvel);


        float rotvel = (joystick.transform.position - pastPosition).x/200 ;
        currentrot -= rotvel;
        body.MoveRotation(currentrot);

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
        targetQueue.AddLast(target);

        // if we have more than three targets, forget the oldest, destroying one of it's reticles
        if (targetCount >= 3)
        {
            IsTargetable detarget = targetQueue.First.Value;
            Destroy(detarget.transform.FindChild("Reticle").gameObject);
            targetQueue.RemoveFirst();
        }
        else
        {
            targetCount++;
        }
    }
}
