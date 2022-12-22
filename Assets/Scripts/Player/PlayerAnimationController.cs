using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    // TODO: Not working

    private static Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    public void PlayAnimation(string animation)
    {
        anim.SetTrigger(animation);
    }
}
