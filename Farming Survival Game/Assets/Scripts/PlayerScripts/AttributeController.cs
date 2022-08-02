using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttributeController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI m_Health;
    [SerializeField] private TextMeshProUGUI m_Food;
    [SerializeField] private TextMeshProUGUI m_Stamina;
    public float CurrHealth, CurrFood, CurrStamina;
    public float MaxHealth, MaxFood, MaxStamina;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // m_Health.text = CurrHealth.ToString() + " / " + MaxHealth.ToString();
        // m_Food.text = CurrFood.ToString() + " / " + MaxFood.ToString();
        // m_Stamina.text = CurrStamina.ToString() + " / " + MaxStamina.ToString();
    }
}
