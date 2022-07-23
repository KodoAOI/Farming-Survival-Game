using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PausePanel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Color ColorSelect;
    [SerializeField] private GameObject[] Buttons;
    private int NumberSelect;
    private bool Changed = true; // Check if need to update
    void Start()
    {
        NumberSelect = 0;
        ColorSelect.a = 1;
    }

    // Update is called once per frame
    [ContextMenu("update")]
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            NumberSelect += 1;
            Changed = true;
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            NumberSelect -= 1;
            Changed = true;
        }
        if(Changed)
        {
            NumberSelect = Math.Max(NumberSelect, 0);
            NumberSelect = Math.Min(NumberSelect, Buttons.Length - 1);
            for(int i = 0; i < Buttons.Length; i++)
            {
                GameObject ButtonSelected = Buttons[i];
                Color color = Color.white;
                if(i == NumberSelect)color = ColorSelect;
                ButtonSelected.GetComponentInChildren<TextMeshProUGUI>().color = color;
            }
            Changed = false;
        }
       
      

    }
}
