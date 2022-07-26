using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CollectableType m_Type;

    public CollectableType Getter()
    {
        return m_Type;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        gameObject.SetActive(false);
    }

    
}

public enum CollectableType
{
    NONE, 
    Carrot,
    Chili
}
