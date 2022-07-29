using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField] private GameObject m_InventoryPanel;
    [SerializeField] PlayerController m_Player;
    [SerializeField] ObjectInformationPanel m_ObjectInformationPanel;
    [SerializeField] Color m_Color;
    public List<Slot_UI> slots= new List<Slot_UI>();
    // [SerializeField] private Button m_Button;
    // Start is called before the first frame update
    void Start()
    {
        m_InventoryPanel.SetActive(false);
    }

    public void Setup(bool DiscardOrNot)
    {
        if(DiscardOrNot == false)
        {
            foreach(Slot_UI slot in slots)
            {
                Image img = slot.gameObject.GetComponent<Image>();
                img.color = m_Color;
            }

            m_ObjectInformationPanel.ResetInformationPanel();
        }

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

    public void Remove()
    {
        CollectableObjectController itemToDrop = ItemGameManager.instance.itemManager.GetItemByType(m_Player.GetCollectableType(m_ObjectInformationPanel.m_SlotIdx));

        if(itemToDrop != null)
        {
            m_Player.DropItem(itemToDrop);
            m_Player.Remove(m_ObjectInformationPanel.m_SlotIdx);
            Setup(true);
        }
    }

    public void RemoveAll()
    {
        int num = m_Player.GetCollectableCount(m_ObjectInformationPanel.m_SlotIdx);
        for(int i = 0; i < num; i++)
        {
            
            CollectableObjectController itemToDrop = ItemGameManager.instance.itemManager.GetItemByType(m_Player.GetCollectableType(m_ObjectInformationPanel.m_SlotIdx));

            if(itemToDrop != null)
            {
                m_Player.DropItem(itemToDrop);
                m_Player.Remove(m_ObjectInformationPanel.m_SlotIdx);
                Setup(true);
            }
        }
    }
}
