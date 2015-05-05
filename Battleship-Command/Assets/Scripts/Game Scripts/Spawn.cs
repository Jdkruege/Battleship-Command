using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject toSpawn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void spawn()
    {
        GameObject newship = Instantiate(toSpawn);
    }

}
