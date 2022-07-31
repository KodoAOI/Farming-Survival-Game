using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    // [SerializeField] private int m_MaxStack;
    [SerializeField] private int m_MaxStack;
    [SerializeField] private ObjectInformationPanel m_ObjectInformationPanel;
    [SerializeField] private Inventory_UI m_InventoryUI;
    [SerializeField] private TransparentObject m_TransparentObject;
    public List<Slot> Slots = new List<Slot>();
    public int NumSlots;

    private void Update()
    {
        if(m_InventoryUI.gameObject.activeSelf == true)
        {
            if(m_TransparentObject.gameObject.activeSelf == false)
            {
                m_TransparentObject.gameObject.SetActive(true);
            }
        }

        if(m_InventoryUI.gameObject.activeSelf == false)
        {
            if(m_TransparentObject.gameObject.activeSelf == true)
            {
                m_TransparentObject.gameObject.SetActive(false);
            }
        }
    }

    public class Slot
    {
        public int Count;
        public int MaxCount;
        public CollectableType Type;
        public Sprite m_Icon;

        public Slot()
        {
            Count = 0;
            MaxCount = 0;
            Type = CollectableType.NONE;
        }

        public void Add(CollectableObjectController Object)
        {
            Type = Object.Getter();
            m_Icon = Object.Icon;
            MaxCount = Object.GetStack();
            Count++;
        }
        
        public void RemoveItem()
        {
            if(Count > 0)
            {
                Count--;

                if(Count == 0)
                {
                    m_Icon = null;
                    Type = CollectableType.NONE;
                }
            }
        }
    }

  
    
    void Awake()
    {
        for(int i = 0; i < NumSlots; i++)
        {
            Slot slot = new Slot();
            Slots.Add(slot);
        }
    }

    public void Add(CollectableObjectController Object)
    {
        bool Flag = false;
        foreach(Slot slot in Slots)
        {
            if(slot.Type == Object.Getter())
            {
                if(slot.Count < slot.MaxCount)
                {
                    slot.Count ++;
                    Flag = true;
                    break;
                }
            }
        }
        if(!Flag)   
        {
            foreach(Slot slot in Slots)
            {
                if(slot.Type == CollectableType.NONE)
                {
                    slot.Add(Object);
                    break;
                }
            }
        }
        m_InventoryUI.Setup(false);
    }

    public void Remove(int idx)
    {
        Slots[idx].RemoveItem();
        if(Slots[idx].Count == 0)
        {
            m_ObjectInformationPanel.ResetInformationPanel();
        }
    }

    public void Swap(int idx1, int idx2)
    {
        if(idx1 == -1 || idx2 == -1)    return;
        Slot tmp = Slots[idx1];
        Slots[idx1] = Slots[idx2];
        Slots[idx2] = tmp;
    }
}
