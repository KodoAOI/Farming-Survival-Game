using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{
    [SerializeField] Image m_ItemIcon;
    [SerializeField] TextMeshProUGUI m_QuantityText;
    [SerializeField] Inventory_UI m_InventoryUI;
    [SerializeField] Color m_Color;

    public void SetItem(InventoryController.Slot slot)
    {
        if(slot != null)
        {
            m_ItemIcon.sprite = slot.m_Icon;
            m_ItemIcon.color = new Color(1, 1, 1, 1);
            m_QuantityText.text = slot.Count.ToString();
        }
    }

    public void SetEmpty()
    {
        m_ItemIcon.sprite = null;
        m_ItemIcon.color = new Color(1, 1, 1, 0);
        m_QuantityText.text = "";
    }

    public void OnClick()
    {
        foreach(Slot_UI slot in m_InventoryUI.slots)
        {
            Image img = slot.gameObject.GetComponent<Image>();
            img.color = m_Color;
        }
        Image image = gameObject.GetComponent<Image>();
        image.color = new Color(1, 1, 1, 0.5f);
    }
}
