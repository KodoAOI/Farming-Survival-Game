using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CollectableType m_Type;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
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
