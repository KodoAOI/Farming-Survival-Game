using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField] private GameObject m_InventoryPanel;
    [SerializeField] PlayerController m_Player;
    [SerializeField] private List<Slot_UI> slots= new List<Slot_UI>();
    // [SerializeField] private Button m_Button;
    // Start is called before the first frame update
    void Start()
    {
        m_InventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ShowInventory();
        }
    }

    private void ShowInventory()
    {
        if(m_InventoryPanel.activeSelf == false)    
        {
            m_InventoryPanel.SetActive(true);
            Setup();
        }
        else m_InventoryPanel.SetActive(false);
    }

    void Setup()
    {
        if(slots.Count == m_Player.GetInventoryNumSlot())
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if(m_Player.GetCollectableType(i) != CollectableType.NONE)
                {
                    slots[i].SetItem(m_Player.GetSlot(i));
                }
                else 
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

}
