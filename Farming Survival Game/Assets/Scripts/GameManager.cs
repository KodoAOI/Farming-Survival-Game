using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Menu,
        Play,
        Pause,
        Death
    }
    [SerializeField] GameObject DeadScreen, PausePanel, MenuPanel, PlayScreen, ObjectPools;
    [SerializeField] PlayerController m_Player;
    [SerializeField] Inventory_UI m_InventoryUI;
    [SerializeField] AttributeUIController m_AtrributeUI;
    [SerializeField] GameObject m_DayNightSystem;
    private GameState CurrState;
    void Start()
    {
        SetState(GameState.Menu);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1, 1, 1);
        if(Input.GetKeyDown(KeyCode.Escape))
            if(!PausePanel.GetComponent<PausePanel>().OnTrigger() && CurrState != GameState.Menu)
            {
                SetState(GameState.Pause);
            }
            else 
            {
                SetState(CurrState);
            }
        
        if(Input.GetKeyDown(KeyCode.Tab) && CurrState == GameState.Play && !PausePanel.gameObject.activeSelf)
        {
            bool check = !m_InventoryUI.gameObject.activeSelf;
            if(check)
                m_InventoryUI.Setup(false);
            m_InventoryUI.gameObject.SetActive(check);
        }

    }

    public void SetState(GameState State)
    {
        if(State == GameState.Pause)
        {
            m_Player.Active = false;
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            CurrState = State;
            PausePanel.SetActive(false);
            DeadScreen.SetActive(State == GameState.Death);
            MenuPanel.SetActive(State == GameState.Menu);
            PlayScreen.SetActive(State == GameState.Play);
            m_Player.gameObject.SetActive(State != GameState.Menu);
            ObjectPools.SetActive(State == GameState.Play || State == GameState.Pause);
            m_AtrributeUI.gameObject.SetActive(State == GameState.Play);
            m_InventoryUI.gameObject.SetActive(false);
            if(State == GameState.Play || State == GameState.Pause) m_DayNightSystem.SetActive(true);
            else m_DayNightSystem.SetActive(false);
            m_Player.Active = true;
        }
    }
}

// Hi, my name is Dung