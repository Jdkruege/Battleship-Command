using UnityEngine;
using System.Collections;

/**
 * Able to have a reticle attached to sprite.
 */
public class IsTargetable : MonoBehaviour
{
    private GameObject controller;


    public void Start()
    {
        controller = GameObject.Find("Controller");
    }

    public void OnMouseDown()
    {
        Player.getPlayer().targetShip(this);
        
    }
}
