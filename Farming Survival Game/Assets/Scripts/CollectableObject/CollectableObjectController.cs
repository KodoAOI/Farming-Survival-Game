using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CollectableType m_Type;
    [SerializeField] private ObjectPool m_Pool;
    public Sprite Icon;

    public CollectableType Getter()
    {
        return m_Type;
    }

    public void Setter()
    {

    }
    
    void Start()
    {
        m_Pool.m_CollectableObjectPool.m_PoolType = m_Type;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerController>() != null)
            m_Pool.m_CollectableObjectPool.Release(this);
    }

    
}

public enum CollectableType
{
    NONE, 
    Carrot,
    Chili
}
