using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthMoving : Depth
{
    void FixedUpdate()
    {
        if (TryGetComponent(out SpriteRenderer sprite))
        {
            sprite.sortingOrder = Mathf.RoundToInt(transform.position.y * -100 + defaultSortingOrder);
        }
    }
}
