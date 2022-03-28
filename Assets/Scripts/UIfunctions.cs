using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIfunctions : MonoBehaviour
{
    [SerializeField] private PlayerAbilities playerAbilities;
    [SerializeField] private PlayerAnimations playerAnimations;
    public void Interact()
    {
        //Breaking tree
        /*
        playerAbilities.

        playerAnimations.ChoppingAnim(); */
    }

    public void AxeHit()
    {
        playerAbilities.AxeHit();
        playerAnimations.ChoppingAnim();
    }
}
