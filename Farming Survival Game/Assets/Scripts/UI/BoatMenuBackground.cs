using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMenuBackground : MonoBehaviour
{
    [SerializeField] private Vector2 m_direction;
    [SerializeField] private float m_MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(m_direction * Time.deltaTime * m_MoveSpeed);
    }
}
