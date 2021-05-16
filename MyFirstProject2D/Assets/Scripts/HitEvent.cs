using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEvent : MonoBehaviour
{
    Animator animator;

    void Start()
    {     
        animator = GetComponent<Animator>();      
    }
    public void OutOfHit()
    {
        animator.SetBool("hit", false);
    }
}
