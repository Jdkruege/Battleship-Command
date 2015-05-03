using UnityEngine;
using System.Collections;

/**
 * Able to have a reticle attached to sprite.
 */
public class IsTargetable : MonoBehaviour
{
    private GameObject controller;

    public int targetCount;

    public void Start()
    {
        targetCount = 0;
        controller = GameObject.Find("Controller");
    }

    public void OnMouseDown()
    {
        if (targetCount < 3)
        {
            targetCount++;
            if (transform.FindChild("Reticle") == null)
            {
                GameObject reticle = Instantiate(controller.GetComponent<Resources>().reticle);
                reticle.transform.parent = this.transform;
                reticle.transform.position = this.transform.position;
                reticle.transform.name = "Reticle";
            }
        }
        else
        {
            targetCount = 0;
            Destroy(transform.FindChild("Reticle").gameObject);
        }
    }
}
