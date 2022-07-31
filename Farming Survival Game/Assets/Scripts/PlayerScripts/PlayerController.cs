using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator m_Animator;
    [SerializeField] private InputAction m_InputAction;
    [SerializeField] private float m_movespeed;
    [SerializeField] private InventoryController m_Inventory;
    [SerializeField] private float m_Scale;
    [SerializeField] private GameObject m_ChopAnimation;
    [SerializeField] private AttributeController m_AttributeController;
    [SerializeField] private CollectableObjectsPool m_CollectableObjectsPool;
    [SerializeField] private AttributeUIController m_AttributeUIController;
    [SerializeField] private PlayerActionController m_PlayerActionController;

    private Vector2 m_MoveDirection = Vector2.zero;
    private Rigidbody2D rb;
    private PlayerActionController m_ActionCollider;
    private InventoryController.Slot CurrItemOnHand;
    private Action m_Action;

    public bool Active = true;
    public float CurrHealth, CurrFood, CurrStamina;
    public float MaxHealth, MaxFood, MaxStamina;

     Dictionary<CollectableType, Action> ItemTriggerDictionary = new Dictionary<CollectableType, Action>()
    {
        {CollectableType.Axe, Action.Cut},
        {CollectableType.Carrot, Action.None}
        
    };
    private void OnEnable() 
    {
        m_InputAction.Enable();
    }

    private void OnDisable() 
    {
        m_InputAction.Disable();
    }


    
    void Start()
    {
        CurrHealth = MaxHealth;
        CurrFood = MaxFood;
        CurrStamina = MaxStamina;

        m_AttributeController.MaxHealth = MaxHealth;
        m_AttributeController.MaxFood = MaxFood;
        m_AttributeController.MaxStamina = MaxStamina;

        m_ActionCollider = gameObject.GetComponentInChildren<PlayerActionController>();

        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Active)return;
        //trigger action
        if(Input.GetKeyDown(KeyCode.Space))
        {
            try
            {
                if(ItemTriggerDictionary[CurrItemOnHand.Type] == m_Action)
                {
                    m_AttributeUIController.MakeProgressBar(2.0f);
                    m_AttributeUIController.SetAction(m_Action);
                }
            }
            catch{}
        }
        if(m_Action == Action.None)
            m_AttributeUIController.TurnOffProgressBar();
        //Update Attribute Information
        m_AttributeController.CurrHealth = CurrHealth;
        m_AttributeController.CurrFood = CurrFood;
        m_AttributeController.CurrStamina = CurrStamina;

        //Movement
        m_MoveDirection = m_InputAction.ReadValue<Vector2>();
        if(m_MoveDirection != Vector2.zero)
            Run();
        else
            Idle();
        if(m_MoveDirection.x > 0)
            transform.localScale = Vector3.one * m_Scale;
        else if (m_MoveDirection.x < 0)
            transform.localScale= new Vector3(-1, 1, 1) * m_Scale;
    }

    private void FixedUpdate() 
    {
        rb.velocity = m_MoveDirection * m_movespeed;
    }

    [ContextMenu("Run")]
    private void Run()
    {
        m_Animator.SetBool("Run", true);
        m_Animator.SetBool("Idle", false);
    }
    [ContextMenu("Idle")]
    private void Idle()
    {
        m_Animator.SetBool("Idle", true);
        m_Animator.SetBool("Run", false);
    }
    [ContextMenu("Die")]
    private void Die()
    {
        m_Animator.SetBool("Die", true);
        m_Animator.SetBool("Idle", false);
        m_Animator.SetBool("Run", false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        CollectableObjectController m_object = other.GetComponent<CollectableObjectController>();

        if(m_object != null && m_object.tag == "CollectableObject" && m_object.GetCollideWith == gameObject.GetComponent<Collider2D>())
        {
            m_Inventory.Add(m_object);
            m_object.SelfDestroy();
        }
    }

    public int GetInventoryNumSlot()
    {
        return m_Inventory.Slots.Count;
    }

    public CollectableType GetCollectableType(int idx)
    {
        return m_Inventory.Slots[idx].Type;
    }

    public int GetCollectableCount(int idx)
    {
        return m_Inventory.Slots[idx].Count;
    }

    public InventoryController.Slot GetSlot(int idx)
    {
        return m_Inventory.Slots[idx];
    }

    public void Remove(int SlotId)
    {
        m_Inventory.Remove(SlotId);
    }

    public void Chop(bool StartChop)
    {
        m_ChopAnimation.SetActive(StartChop);
    }
    public void DropItem(CollectableObjectController item)
    {
        Vector3 spawnLocation = transform.position;

        Vector3 spawnOffset = UnityEngine.Random.insideUnitCircle * 1.25f;

        CollectableObjectController droppedItem = m_CollectableObjectsPool.m_Pool[item.Getter()].Spawn(spawnLocation + spawnOffset,null);//Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);
        droppedItem.rb2d.AddForce(spawnOffset * .2f, ForceMode2D.Impulse);
    }

    public void SetItemOnHand(InventoryController.Slot item)
    {
        CurrItemOnHand = item;
    }

    public void SetAction(Action action)
    {
        m_Action = action;
    }
    public void InventorySwap(int idx1, int idx2)
    {
        m_Inventory.Swap(idx1, idx2);
    }

}
