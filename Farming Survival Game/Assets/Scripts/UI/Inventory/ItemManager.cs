using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public CollectableObjectController[] CollectableItems;

    private Dictionary<CollectableType, CollectableObjectController> collectableItemsDict = new Dictionary<CollectableType, CollectableObjectController>();

    private void Awake()
    {
        foreach(CollectableObjectController item in CollectableItems)
        {
            AddItem(item);
        }
    }

    private void AddItem(CollectableObjectController item)
    {
        if(!collectableItemsDict.ContainsKey(item.GetCollectableType()))
        {
            collectableItemsDict.Add(item.GetCollectableType(), item);
        }
    }

    public CollectableObjectController GetItemByType(CollectableType type)
    {
        if(collectableItemsDict.ContainsKey(type))
        {
            return collectableItemsDict[type];
        }

        return null;
    }
}
