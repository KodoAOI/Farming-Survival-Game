using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CollectableType m_Type;
    [SerializeField] private int m_MaxStack;
    [SerializeField] private Action m_Action;
    public CollectableObjectPool m_Pool;
    public Sprite Icon;
    public bool CollectableOrNot;
    public Rigidbody2D rb2d;

    private void Awake()
    {
        CollectableOrNot = true;
        m_Pool = FindObjectOfType<CollectableObjectsPool>().m_Pool[m_Type];
        rb2d = GetComponent<Rigidbody2D>();
    }

    public CollectableType GetCollectableType()
    {
        return m_Type;
    }

    public void Setter()
    {

    }
    
    void Start()
    {
        
    }

    private void ChangeCollectableOrNot()
    {
        CollectableOrNot = true;
    }

    public void CallInvokeChangeCollectableOrNot()
    {
        CollectableOrNot = false;
        Invoke("ChangeCollectableOrNot", 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Collider2D GetCollideWith;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<PlayerController>() != null && other.tag == "Player")
        {
            GetCollideWith = other;
        }

    }

    public void SelfDestroy()
    {
        m_Pool.Release(this);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.GetComponent<PlayerController>() != null && other.tag == "Player")
            GetCollideWith = null;
    }

    public CollectableObjectPool GetPool()
    {   
        return FindObjectOfType<CollectableObjectsPool>().m_Pool[m_Type];
    }

    public int GetStack()
    {
        return m_MaxStack;
    }

    public Action GetAction()
    {
        return m_Action;
    }
}

public enum CollectableType
{
    NONE, 
    //Farming Productions
    Carrot,
    Chili,
    //Tools
    Axe,
    Pickaxe,
    Shovel,
    Hoe,
    WateringCan
}
