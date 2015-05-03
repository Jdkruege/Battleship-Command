using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
   
    public GameObject camera;
    public int x, y;

    void OnMouseDown()
    {
        camera.transform.position = new Vector3(x, y, camera.transform.position.z);
    }
}
