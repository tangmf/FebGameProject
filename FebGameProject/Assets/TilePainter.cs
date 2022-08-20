using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePainter : MonoBehaviour
{
    public Item item;
    public Vector3Int position;
    public Tilemap tilemap;
    public Tilemap preview;

    private Vector3Int currentPosition;
    private Vector3Int previousPosition;

    public GameObject buildManager;

    public GameObject player;
    public Vector3Int playerPos;

    public int range = 4;

    public LayerMask layersToCheck;
    Collider2D _targetCollider;
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
        if (item.tileObject != null)
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
                Tile tile = ScriptableObject.CreateInstance<Tile>();
                tile.sprite = item.tileObject.GetComponent<SpriteRenderer>().sprite;
                if (!TileOccupied(position))
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
        if(!TileOccupied(position))
        {
            if(item.tileObject != null)
            {
                Instantiate(item.tileObject, tilemap.GetCellCenterWorld(position), transform.rotation);
            }
            return true;
        }
        else
        {
            return false;
        }

    }

    public void AssignItem(Item i)
    {
        if (i != null)
        {
            item = i;
        }
        else
        {
            item = null;
        }

    }

    public void ResetPreview()
    {
        Tile tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = item.tileObject.GetComponent<SpriteRenderer>().sprite;
        //preview.ClearAllTiles();
        preview.ClearAllTiles();
        if (preview.GetTile(position) != null)
        {
            if (!TileOccupied(position))
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
            if (!TileOccupied(position))
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

    public bool TileOccupied(Vector3Int gridPos)
    {
        _targetCollider = Physics2D.OverlapPoint(tilemap.GetCellCenterWorld(gridPos), layersToCheck);
        if(_targetCollider == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


}
