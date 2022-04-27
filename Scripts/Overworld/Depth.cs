using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Depth : MonoBehaviour
{
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
