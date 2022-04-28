using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthMoving : Depth
{
    //Does the same thing as "depth" except that it updates the sorting order every couple of frames.
    //This script is for moving objects such as the player and NPCs.
    void FixedUpdate()
    {
        if (TryGetComponent(out SpriteRenderer sprite))
        {
            sprite.sortingOrder = Mathf.RoundToInt(transform.position.y * -100 + defaultSortingOrder);
        }
    }
}
