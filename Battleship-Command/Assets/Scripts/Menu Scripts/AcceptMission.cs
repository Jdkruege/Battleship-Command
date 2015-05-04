using UnityEngine;
using System.Collections;

public class AcceptMission : MonoBehaviour {

    public string scene;

    void OnMouseDown()
    {
        Application.LoadLevel(scene);
    }
}
