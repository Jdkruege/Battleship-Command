using UnityEngine;
using System.Collections;

/**
 * Able to have a reticle attached to sprite.
 */
public class IsTargetable : MonoBehaviour
{
    public void OnMouseDown()
    {
        Player.getPlayer().targetShip(this);
        
    }
}
