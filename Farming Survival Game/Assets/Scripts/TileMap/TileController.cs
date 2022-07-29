using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileController : MonoBehaviour
{
   public Tile TileSelect;
   public Tilemap m_TileMap;
   Vector3Int Location = Vector3Int.zero;

   private void Update() 
   {
        m_TileMap.SetTile(Location,null);
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Location = m_TileMap.WorldToCell(MousePosition);
        m_TileMap.SetTile(Location,TileSelect);
   }
}
