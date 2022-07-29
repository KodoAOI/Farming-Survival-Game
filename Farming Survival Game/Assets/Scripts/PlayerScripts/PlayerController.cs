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
    private Vector2 m_MoveDirection = Vector2.zero;
    private Rigidbody2D rb;
    private PlayerActionController m_ActionCollider;

    public bool Active = true;
    public float CurrHealth, CurrFood, CurrStamina;
    public float MaxHealth, MaxFood, MaxStamina;

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

        m_AttributeController.CurrHealth = CurrHealth;
        m_AttributeController.CurrFood = CurrFood;
        m_AttributeController.CurrStamina = CurrStamina;

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
        GameObject m_obGame = other.GetComponent<GameObject>();
        try
        {
            print(m_obGame.name);
        }
        catch{}
        CollectableObjectController m_object = other.GetComponent<CollectableObjectController>();
        if(m_object != null && m_object.tag == "CollectableObject") m_Inventory.Add(m_object);
    }

    public int GetInventoryNumSlot()
    {
        return m_Inventory.Slots.Count;
    }

    public CollectableType GetCollectableType(int idx)
    {
        return m_Inventory.Slots[idx].Type;
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
        print("Chop");
        m_ChopAnimation.SetActive(StartChop);
    }
}
