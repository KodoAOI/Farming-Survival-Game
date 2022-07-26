using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private int m_MaxStack;
    public List<Slot> Slots = new List<Slot>();
    public int NumSlots;
    public class Slot
    {
        public int Count;
        public int MaxCount;
        public CollectableType Type;

        public Slot(int m_MaxStack)
        {
            Count = 0;
            MaxCount = m_MaxStack;
            Type = CollectableType.NONE;
        }

        public void Add(CollectableType objectType)
        {
            Debug.Log("Success!!!");
            Type = objectType;
            Count++;
        }
    }

  
    
    void Start()
    {
        for(int i = 0; i < NumSlots; i++)
        {
            Slot slot = new Slot(m_MaxStack);
            Slots.Add(slot);
        }
    }

    public void Add(CollectableType objectType)
    {
        Debug.Log(Slots.Count);
        bool Flag = false;
        foreach(Slot slot in Slots)
        {
            if(slot.Type == objectType)
            {
                print(objectType);
                if(slot.Count < slot.MaxCount)
                {
                    slot.Count ++;
                    Flag = true;
                }
            }
        }
        if(!Flag)   
        {
            foreach(Slot slot in Slots)
            {
                if(slot.Type == CollectableType.NONE)
                {
                    slot.Add(objectType);
                    break;
                }
            }
        }
    }
}
