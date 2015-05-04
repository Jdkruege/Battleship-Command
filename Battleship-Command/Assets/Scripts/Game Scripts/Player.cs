using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Vector3 pastPosition;
    Transform joystick;
    float currentrot;
    Rigidbody2D body;
	// Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        joystick = transform.FindChild("MobileSingleStickControl").gameObject.transform.FindChild("MobileJoystick").gameObject.transform;
        pastPosition = joystick.transform.position;
        currentrot = 0;
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
        currentrot += rotvel;
        body.MoveRotation(currentrot);

    }

}
