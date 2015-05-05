using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

    public Spawn[] spawnpoints;

    public int spawntime; //How long between spawns
    private int spawndelay; //How long till next spawn

	// Use this for initialization
	void Start () {
        spawndelay = spawntime;
	}
	
	// Update is called once per frame
	void Update () {
        if (spawndelay > 0){
            spawndelay--;
        }else{
            int whichSpawn = Random.Range(0, spawnpoints.Length - 1);
            spawnpoints[whichSpawn].spawn();
            spawndelay = spawntime;
        }
	
	}
}
