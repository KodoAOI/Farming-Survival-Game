using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot_UI : MonoBehaviour, IDropHandler
{
    [SerializeField] ToolBarController m_ToolBar;
    [SerializeField] private int Num;
    public bool IsActive;
    [SerializeField] private Image m_ItemIcon;
    [SerializeField] private TextMeshProUGUI m_QuantityText;
    [SerializeField] private Inventory_UI m_InventoryUI;
    [SerializeField] private Color m_Color;
    [SerializeField] private Image m_CloneSlot;
    [SerializeField] private ObjectInformationPanel m_ObjectInformationPanel;
    [SerializeField] private Transform m_FirstSlotPosition;
    [SerializeField] private PlayerController m_Player;
    [SerializeField] private Slider m_Durability;
    [SerializeField] private Slider m_CloneDurability;
    private InventoryController.Slot m_Slot;

    public int SlotIdx;
    private int m_CurrDurability = -1;
    public void SetDurability(int Durability)
    {
        m_CurrDurability = Durability;
    }
    public void Setup(InventoryController.Slot slot)
    {
        m_Slot = slot;
        SetDurability(slot.m_Durability);
        if(slot.m_CollectableObject != null)slot.m_CollectableObject.SetDurability(slot.m_Durability);
        if(m_CurrDurability <= 0)m_Durability.gameObject.SetActive(false);
        else
        {
            m_Durability.gameObject.SetActive(true);
            m_Durability.value = (float)slot.m_Durability / (float)slot.m_MaxDurability * 100f;
        }
    }
    private void Update()
    {
        if(m_CloneSlot != null && m_CloneSlot.gameObject.activeSelf == true && m_ObjectInformationPanel.m_SlotIdx != -1 && m_Player.GetCollectableCount(m_ObjectInformationPanel.m_SlotIdx) == 0)
        {
            m_CloneSlot.GetComponent<DragDrop>().SetActiveFalse();
        }
        if(m_CurrDurability <= 0)m_Durability.gameObject.SetActive(false);
        else
        {
            m_Durability.gameObject.SetActive(true);
            m_Durability.value = (float)m_Slot.m_Durability / (float)m_Slot.m_MaxDurability * 100f;
        }
    }
    public void SetItem(InventoryController.Slot slot)
    {
        if(slot != null)
        {
            m_ItemIcon.sprite = slot.m_Icon;
            m_ItemIcon.color = new Color(1, 1, 1, 1);
            m_QuantityText.text = slot.Count.ToString();
            m_Slot = slot;
            // if(slot.m_Durability != -1)print(slot.m_Durability);
        }
        // else SetEmpty();
    }

    public void SetEmpty()
    {
        m_ItemIcon.sprite = null;
        m_ItemIcon.color = new Color(1, 1, 1, 0);
        m_QuantityText.text = "";
        m_Slot = null;
    }

    public void OnClick()
    {
        // print("SOS!");
        // SetNumSlot(10);
        if(m_InventoryUI == null)
        {
            ShowTarget();
            // print(m_CurrDurability);
            // print(SlotIdx);
            // print(m_Player.GetInventoryController().Slots[SlotIdx].Type);
            return;
        }
        foreach(Slot_UI slot in m_InventoryUI.slots)
        {
            Image img = slot.gameObject.GetComponent<Image>();
            img.color = m_Color;
        }
        Image image = gameObject.GetComponent<Image>();
        image.color = new Color(1, 1, 1, 0.5f);

    }

    public Image GetImage()
    {
        return m_ItemIcon;
    }

    public TextMeshProUGUI GetText()
    {
        return m_QuantityText;
    }

    public void ShowTarget()
    {
        m_ToolBar.TriggerOff();
        transform.GetChild(3).gameObject.SetActive(true);
        IsActive = true;
    }

    public void OnClick1()
    {
        if(m_ItemIcon.sprite != null)
        {
            m_CloneSlot.gameObject.SetActive(true);
            DragDrop obj = m_CloneSlot.GetComponent<DragDrop>();
            obj.SetPosition(m_ObjectInformationPanel.m_SlotIdx);
            m_CloneSlot.sprite = m_ItemIcon.sprite;
            m_CloneSlot.color = m_ItemIcon.color;
            m_CloneDurability.gameObject.SetActive(true);
            m_CloneDurability.value = m_Durability.value;
            if(m_CurrDurability <= 0)   m_CloneDurability.gameObject.SetActive(false);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Debug.Log("OnDrop");
        if(eventData.pointerDrag != null)
        {
            // Debug.Log(eventData.pointerDrag);
            // int idx = m_ObjectInformationPanel.m_SlotIdx;
            // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = m_FirstSlotPosition.position + new Vector3(135 * (idx % 9), -(135 * (idx / 9)), 0);
            // m_ItemIcon.color = new Color(0.4f, 0.65f, 0.23f, 1);
            // Debug.Log(SlotIdx);
            m_Player.InventorySwap(SlotIdx, m_ObjectInformationPanel.m_SlotIdx);
            m_CloneSlot.GetComponent<DragDrop>().CheckDrop = true;
            m_InventoryUI.Setup(false); 
        }
        // DragDrop obj = m_CloneSlot.GetComponent<DragDrop>();
        // obj.SetPosition(SlotIdx);
        // obj.CheckDrop = true;
        // m_CloneSlot.gameObject.SetActive(false);
    }
}
