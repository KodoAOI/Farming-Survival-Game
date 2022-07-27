using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInformationPanel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject m_InformationPanel;
    [SerializeField] private TextMeshProUGUI m_text;
    [SerializeField] private Image m_Icon;

    public int m_SlotIdx;

    public void RefreshInformationPanel(Image Icon)
    {
        if(Icon.sprite == null)
        {
            m_Icon.color = new Color(1, 1, 1, 0);
            return;
        }
        m_Icon.sprite = Icon.sprite;
        m_Icon.color = new Color(1, 1, 1, 1);
        // Debug.Log(Icon.sprite);
    }

    public void GetSlotIdx(int SlotIdx)
    {
        m_SlotIdx = SlotIdx;
    }

    public void ResetInformationPanel()
    {
        m_Icon.sprite = null;
        m_Icon.color = new Color(1, 1, 1, 0);
    }
}
