using UnityEngine;
using System.Collections;

public class LoadPapers : MonoBehaviour {

    public GameObject paperHolder;
    public TextAsset xmlText;

    void OnMouseDown()
    {
        paperHolder.GetComponent<PaperHolder>().GatherPaper(xmlText);
    }
}
