using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Vector3 pastPosition;
    Transform joystick;
	// Use this for initialization
	void Start () {
        joystick = transform.FindChild("MobileSingleStickControl").gameObject.transform.FindChild("MobileJoystick").gameObject.transform;
        pastPosition = joystick.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        steer();
	}

    private void steer()
    {


        transform.position += ( joystick.transform.position-pastPosition ) / 500;
    }
}
