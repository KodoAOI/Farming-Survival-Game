using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerActionController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerController m_Player;
    [SerializeField] private Tilemap m_Tilemap;
    private TileBase CurrTile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Pos = m_Player.transform.position;
        Vector3Int Location = m_Tilemap.WorldToCell(Pos);
        CurrTile = m_Tilemap.GetTile(Location);
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        TreeController NewObject = other.gameObject.GetComponent<TreeController>();
        
        if(NewObject != null)
        {
            print(other.gameObject.name);
            m_Player.Chop(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        TreeController NewObject = other.gameObject.GetComponent<TreeController>();
        
        if(NewObject != null)
        {
            print(other.gameObject.name);
            m_Player.Chop(false);
        }

    }
}
