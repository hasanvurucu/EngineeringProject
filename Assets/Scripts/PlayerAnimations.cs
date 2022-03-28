using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator playerAnimator;
    private void Awake()
    {
        playerAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    public void ChoppingAnim()
    {
        playerAnimator.SetTrigger("isChopping");
    }
}
