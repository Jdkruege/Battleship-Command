using UnityEngine;
using System.Collections;

public class TextToFront : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().sortingLayerName = "Paper";
	}
}
