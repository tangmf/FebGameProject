using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePainter : MonoBehaviour
{
    public Tile tile;
    public Vector3Int position;
    public Tilemap tilemap;

    void Update()
    {
        /*
        position = Vector3Int.FloorToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetKeyDown("g"))
        {
            position.z = 0;
            //PaintTile(Vector3Int.FloorToInt(worldPosition), tile);
            tilemap.SetTile(Vector3Int.FloorToInt(tilemap.GetCellCenterLocal(tilemap.WorldToCell(position))), tile);
        }
        */
        if(tile != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position = tilemap.WorldToCell(mousePos);

            if (Input.GetKeyDown("g"))
            {
                position.z = 0;
                //PaintTile(Vector3Int.FloorToInt(worldPosition), tile);
                tilemap.SetTile(position, tile);
            }
        }
    }
    public void PaintTile(Vector3Int pos, Tile tile)
    {
        tilemap.SetTile(pos, tile);
    }

    public void AssignItem(Item item)
    {
        if(item != null)
        {
            tile = item.tile;
        }
        
    }
}
