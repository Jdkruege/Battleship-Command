using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().sortingLayerName = "Paper";
	}
	
}
