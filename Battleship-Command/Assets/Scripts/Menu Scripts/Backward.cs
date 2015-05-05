using UnityEngine;
using System.Collections;

public class Backward : MonoBehaviour {

    public GameObject paperHolder;

    // Update is called once per frame
    public void Update()
    {
        if (paperHolder.GetComponent<PaperHolder>().index == 0)
        {
            Color color = GetComponent<SpriteRenderer>().color;
            color.a = 0.5f;
            GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            Color color = GetComponent<SpriteRenderer>().color;
            color.a = 255;
            GetComponent<SpriteRenderer>().color = color;
        }
    }

    public void OnMouseDown()
    {
        paperHolder.GetComponent<PaperHolder>().BackwardAPage();
    }
}
