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

    public void RefreshInformationPanel(Image Icon)
    {
        m_Icon.sprite = Icon.sprite;
        m_Icon.color = new Color(124, 124, 124, 255);
        // Debug.Log("Success!!!");
    }
}
