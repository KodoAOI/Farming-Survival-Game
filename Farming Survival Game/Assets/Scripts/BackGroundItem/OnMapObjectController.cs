using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMapObjectController : MonoBehaviour
{
    public CollectableObjectController[] ItemsDropper;
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
        Vector3 SpawnPoint = m_Player.RandomPointInAnnulus(m_Player.transform.position, 1f, 1.25f);
        foreach(CollectableObjectController item in ItemsDropper)
        {
            Vector3 SpawnOffset = UnityEngine.Random.insideUnitCircle * 0.1f; 
            m_Player.DropAllItem(item, SpawnPoint + SpawnOffset);
            
            // Vector3 spawnLocation = transform.position;
            // Vector3 spawnOffset = UnityEngine.Random.insideUnitCircle * 1.25f;
            // CollectableObjectController droppedItem = item.GetPool().Spawn(spawnLocation + spawnOffset, FindObjectOfType<CollectableObjectsPool>().transform);//Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);
            // droppedItem.rb2d.AddForce(spawnOffset * .2f, ForceMode2D.Impulse);
        }
    }
}
