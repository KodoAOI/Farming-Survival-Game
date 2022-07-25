using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator m_Animator;
    private int IdleHash, RunHash, DyingHash;
    void Start()
    {
        IdleHash = Animator.StringToHash("Idle");
        DyingHash = Animator.StringToHash("Dying");
        RunHash = Animator.StringToHash("Run");
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        m_Animator.SetBool(DyingHash, true);
        m_Animator.SetBool("Idle", false);
        m_Animator.SetBool("Run", false);
    }
}
