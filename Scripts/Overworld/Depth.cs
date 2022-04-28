using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Depth : MonoBehaviour
{
    //Sets the sorting order of sprites based on their Y position
    //This gives an illusion of depth as objects that further down on the map render in front of objects that would logically be behind it.
    public int defaultSortingOrder { get; private set; } 
    private SpriteRenderer sprite;
    private TilemapRenderer tilemap;

    void Start()
    {
        if (TryGetComponent(out SpriteRenderer sprite))
        {
            defaultSortingOrder = sprite.sortingOrder;
            sprite.sortingOrder = Mathf.RoundToInt(transform.position.y * -100 + defaultSortingOrder);
        }

        if (TryGetComponent(out TilemapRenderer tilemap))
        {
            defaultSortingOrder = tilemap.sortingOrder;
            tilemap.sortingOrder = Mathf.RoundToInt(transform.position.y * -100 + defaultSortingOrder);
        }
    }
}
