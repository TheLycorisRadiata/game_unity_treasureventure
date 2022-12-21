using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private static Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    public void PlayAnimation(string animation)
    {
        anim.SetTrigger(animation);
        Debug.Log("Damaged animation");
    }
}
