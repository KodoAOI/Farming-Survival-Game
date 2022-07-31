using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerActionController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerController m_Player;
    [SerializeField] private Tilemap m_Tilemap;
    private GameObject Object;
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

    private void OnTriggerStay2D(Collider2D other) {
        OnMapObjectController NewObject = other.gameObject.GetComponent<OnMapObjectController>();
        
        if(NewObject != null)
        {
            Object = NewObject.gameObject;
            m_Player.SetAction(Action.Cut);
            m_Player.Chop(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        OnMapObjectController NewObject = other.gameObject.GetComponent<OnMapObjectController>();
        
        if(NewObject != null)
        {
            Object = null;
            m_Player.SetAction(Action.None);
            m_Player.Chop(false);
        }
    }

    public void TriggerAction(Action m_Action)
    {
        if(Object == null)return;
        switch(m_Action)
        {
            case Action.Cut : Object.GetComponent<OnMapObjectController>().SelfDestroy(); break;
            
        }
    }
}

public enum Action
{
    None,
    Cut,
    Hoe,
    Dig,
    Pick,
}
