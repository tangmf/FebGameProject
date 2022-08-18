using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePainter : MonoBehaviour
{
    public Tile tile;
    public Vector3Int position;
    public Tilemap tilemap;
    public Tilemap preview;

    private Vector3Int currentPosition;
    private Vector3Int previousPosition;

    public GameObject buildManager;

    public GameObject player;
    public Vector3Int playerPos;

    public int range = 4;
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
        if (tile != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position = tilemap.WorldToCell(mousePos);
            playerPos = tilemap.WorldToCell(player.transform.position);
            if(Mathf.Abs(playerPos.x - position.x) >= range)
            {
                if(playerPos.x < position.x)
                {
                    position.x = playerPos.x + range;
                }
                else
                {
                    position.x = playerPos.x - range;
                }
                
            }
            if (Mathf.Abs(playerPos.y - position.y) >= range)
            {
                if(playerPos.y < position.y)
                {
                    position.y = playerPos.y + range;
                }
                else
                {
                    position.y = playerPos.y - range;
                }
            }

            if (position != previousPosition)
            {
                if (tilemap.GetTile(position) == null)
                {
                    currentPosition = position;
                    preview.color = Color.green;
                    PaintTile(preview, currentPosition, tile);
                    PaintTile(preview, previousPosition, null);

                }
                else
                {
                    Vector3Int temp = currentPosition;
                    currentPosition = position;
                    preview.color = Color.red;
                    PaintTile(preview, currentPosition, tile);
                    PaintTile(preview, previousPosition, null);
                    currentPosition = temp;
                }



                previousPosition = position;
            }



            /*
            if (Input.GetKeyDown("g"))
            {
                position.z = 0;
                //PaintTile(Vector3Int.FloorToInt(worldPosition), tile);
                if(int.Parse(buildManager.GetComponent<BuildManager>().playerInventory.GetCurrentItemSlot().quantity.ToString()) > 0)
                {
                    PaintTile(position, tile);
                }
                
            }
            */
        }
    }
    public void PaintTile(Tilemap tilemap, Vector3Int pos, Tile tile)
    {
        pos.z = 0;
        tilemap.SetTile(pos, tile);
    }

    public bool PaintTileInstant()
    {
        if (tilemap.GetTile(position) == null)
        {
            PaintTile(preview, previousPosition, null);
            position.z = 0;
            tilemap.SetTile(position, tile);
            return true;
        }
        else
        {
            return false;
        }

    }

    public void AssignItem(Item item)
    {
        if (item != null)
        {
            tile = item.tile;
        }
        else
        {
            tile = null;
        }

    }

    public void ResetPreview()
    {
        //preview.ClearAllTiles();
        preview.ClearAllTiles();
        if (preview.GetTile(position) != null)
        {
            if (tilemap.GetTile(position) == null)
            {
                preview.color = Color.green;
                PaintTile(preview, position, tile);
            }
            else
            {
                preview.color = Color.red;
                PaintTile(preview, position, tile);
            }
                
        }
        else
        {
            if (tilemap.GetTile(position) == null)
            {
                preview.color = Color.green;
                currentPosition = position;
                PaintTile(preview, currentPosition, tile);
                previousPosition = position;
            }
            else
            {
                preview.color = Color.red;
                PaintTile(preview, position, tile);
            }

        }
    }


}
