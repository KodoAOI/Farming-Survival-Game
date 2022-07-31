using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerActionController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerController m_Player;
    [SerializeField] private Tilemap m_Tilemap;
    private List<OnMapObjectController> ObjectOnQueue = new List<OnMapObjectController>();
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

    private bool MapObjectFind(OnMapObjectController Object)
    {
        foreach(var obj in ObjectOnQueue)
        {
            if(obj.transform.parent.gameObject.name == Object.transform.parent.gameObject.name)
            {
                return false;
            }
        }
        return true;
    }
    private void OnTriggerStay2D(Collider2D other) {
        OnMapObjectController NewObject = other.gameObject.GetComponent<OnMapObjectController>();
        
        if(NewObject != null)
        {
            if(MapObjectFind(NewObject))ObjectOnQueue.Add(NewObject);
            m_Player.SetAction(Action.Cut);
            m_Player.Chop(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        OnMapObjectController NewObject = other.gameObject.GetComponent<OnMapObjectController>();
        
        if(NewObject != null)
        {
            ObjectOnQueue.Remove(NewObject);
            if(ObjectOnQueue.Count == 0)
            {
                m_Player.SetAction(Action.None);
                m_Player.Chop(false);
            } 
           
        }
    }

    public void TriggerAction(Action m_Action)
    {
        if(ObjectOnQueue.Count == 0)return;
        switch(m_Action)
        {
            case Action.Cut : ObjectOnQueue[0].GetComponent<OnMapObjectController>().SelfDestroy(); break;
            
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
