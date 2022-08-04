using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMapObjectController : MonoBehaviour
{
    public CollectableObjectController[] ItemsDropper;
    [SerializeField]private Action m_Action;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelfDestroy()
    {
        DropItem();
        transform.parent.gameObject.SetActive(false);
    }
    private void DropItem()
    {
        PlayerController m_Player = FindObjectOfType<PlayerController>();
        Vector3 SpawnPoint = m_Player.RandomPointInAnnulus(transform.position, 0.35f, 0.5f);
        foreach(CollectableObjectController item in ItemsDropper)
        {
            item.ResetAttribute();
            Vector3 SpawnOffset = UnityEngine.Random.insideUnitCircle * 0.1f;
            m_Player.DropAllFromObject(item, SpawnPoint + SpawnOffset, gameObject);
            
            // Vector3 spawnLocation = transform.position;
            // Vector3 spawnOffset = UnityEngine.Random.insideUnitCircle * 1.25f;
            // CollectableObjectController droppedItem = item.GetPool().Spawn(spawnLocation + spawnOffset, FindObjectOfType<CollectableObjectsPool>().transform);//Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);
            // droppedItem.rb2d.AddForce(spawnOffset * .2f, ForceMode2D.Impulse);
        }
    }
    public Action GetAction()
    {
        return m_Action;
    }
}
