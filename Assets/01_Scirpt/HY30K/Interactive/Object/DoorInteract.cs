using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX.Utility;

public class DoorInteract : Interactable
{
    private Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponentInParent<Animator>();
    }

    protected override void Interact()
    {
        animator.SetBool("IsOpen", true);
    }
}
