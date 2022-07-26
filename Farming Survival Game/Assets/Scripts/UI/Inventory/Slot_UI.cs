using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{
    [SerializeField] Image m_ItemIcon;
    [SerializeField] TextMeshProUGUI m_QuantityText;

    public void SetItem(InventoryController.Slot slot)
    {
        if(slot != null)
        {
            m_ItemIcon.sprite = slot.m_Icon;
            m_ItemIcon.color = new Color(1, 1, 1, 1);
            m_QuantityText.text = slot.Count.ToString();
        }
        else 
        {
            Debug.Log("Panik!!!");
        }
    }

    public void SetEmpty()
    {
        m_ItemIcon.sprite = null;
        m_ItemIcon.color = new Color(1, 1, 1, 0);
        m_QuantityText.text = "";
    }
}
