using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CollectableType m_Type;
    [SerializeField] private ObjectPool m_Pool;
    public Sprite Icon;

    public Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

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
        // print(other);
        PlayerController obj = other.GetComponent<PlayerController>();
        if(obj != null && obj.tag == "Player") gameObject.SetActive(false);
    }

    
}

public enum CollectableType
{
    NONE, 
    Carrot,
    Chili
}
