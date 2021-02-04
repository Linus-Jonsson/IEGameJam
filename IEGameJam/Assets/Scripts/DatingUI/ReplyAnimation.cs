using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplyAnimation : MonoBehaviour
{
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void SetAnimationTrigger(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }

    public void InactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
