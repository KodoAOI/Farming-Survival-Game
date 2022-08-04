using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatusPanel : MonoBehaviour
{
    [SerializeField] private PlayerController m_Player;
    [SerializeField] private TextMeshProUGUI m_HealthText;
    [SerializeField] private TextMeshProUGUI m_FoodText;
    [SerializeField] private TextMeshProUGUI m_StaminaText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(CurrTime < 0)    Test();
        // if(CurrTime < 0)    CurrTime = 3.5f;
        // CurrTime -= Time.deltaTime;
        m_HealthText.text = m_Player.CurrHealth.ToString() + "/" + m_Player.MaxHealth.ToString();
        m_FoodText.text = m_Player.CurrFood.ToString() + "/" + m_Player.MaxFood.ToString();
        m_StaminaText.text = m_Player.CurrStamina.ToString() + "/" + m_Player.MaxStamina.ToString();
    }

    private void Test()
    {
        m_Player.CurrHealth -= 1;
        m_Player.CurrFood -= 2;
        m_Player.CurrStamina -= 3;
    }
}
