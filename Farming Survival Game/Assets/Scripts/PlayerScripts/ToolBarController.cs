using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ToolBarController : MonoBehaviour
{
    [SerializeField] private InventoryController m_Inventory;
    [SerializeField] private Inventory_UI m_InventoryUI;
    [SerializeField] private PlayerController m_Player;
    private List<InventoryController.Slot> m_Slots = new List<InventoryController.Slot>();
    public List<Slot_UI> m_SlotUI;
    public int m_MaxToolSlot;
    public int ActiveSlot;
    private KeyCode[] NumberArr = {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9};
    void Start()
    {
        for(int i = 0; i < m_MaxToolSlot; i++)
        {
            m_Slots.Add(m_Inventory.Slots[i]);
        }
        m_SlotUI[0].IsActive = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < m_MaxToolSlot; i++)
        {
            m_Slots[i] = m_Inventory.Slots[i];
            m_SlotUI[i].SetItem(m_Slots[i]);
            if(m_Slots[i].Type == CollectableType.NONE) m_SlotUI[i].GetImage().color = new Color(1, 1, 1, 0);
            if(m_Slots[i].Count == 0)m_SlotUI[i].GetText().text = "";
        }

        if(Input.anyKeyDown)
        {
            for(int i = 0; i < NumberArr.Length; i++)
                if(Input.GetKeyDown(NumberArr[i]))
                {
                    ActiveSlot = i;
                    m_SlotUI[ActiveSlot].ShowTarget();
                    break;
                }
        }
        Vector2 Scroll = Input.mouseScrollDelta;
        if(Scroll != Vector2.zero)
        {
            for(int i = 0; i < m_MaxToolSlot; i++)
            {
                if(m_SlotUI[i].IsActive)
                {
                    ActiveSlot = Math.Min(-(int)Scroll.y + i, m_MaxToolSlot - 1);
                    ActiveSlot = Math.Max(ActiveSlot, 0);
                    m_SlotUI[ActiveSlot].ShowTarget();
                    break;
                }
            }
        }

        for(int i = 0; i < m_MaxToolSlot; i++)
        {
            if(m_SlotUI[i].IsActive)
            {
                m_Player.SetItemOnHand(m_Slots[i]);
                break;
            }
        }
    }
    public void TriggerOff()
    {
        foreach(Slot_UI slot in m_SlotUI)
        {
            slot.IsActive = false;
            slot.transform.GetChild(3).gameObject.SetActive(false);
        }
    }
}
