using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private int m_MaxStack;
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

    public List<Slot> Slots = new List<Slot>();
    
    public InventoryController(int NumSlots)
    {
        for(int i = 0; i < NumSlots; i++)
        {
            Slot slot = new Slot(m_MaxStack);
            Slots.Add(slot);
        }
        Debug.Log("1");
    }

    public void Add(CollectableType objectType)
    {
        Debug.Log(Slots.Count);
        bool Flag = false;
        foreach(Slot slot in Slots)
        {
            if(slot.Type == objectType)
            {
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
