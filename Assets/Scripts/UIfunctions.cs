using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIfunctions : MonoBehaviour
{
    [SerializeField] private PlayerAbilities playerAbilities;
    [SerializeField] private PlayerAnimations playerAnimations;

    //Special parameters
    private float axeHitCooldown = 1.2f;
    private bool axeHitReady = true;

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            AxeHit();
        }
    }

    public void Interact()
    {
        //Breaking tree
        /*
        playerAbilities.

        playerAnimations.ChoppingAnim(); */
    }

    public void AxeHit()
    {
        Debug.Log("axe hit button attempt");
        if (axeHitReady)
        {
            Debug.Log("axe hit command worked");
            playerAbilities.AxeHit();
            playerAnimations.ChoppingAnim();
            StartCoroutine(AxeHitCooldown());
        }
    }

    IEnumerator AxeHitCooldown()
    {
        axeHitReady = false;

        yield return new WaitForSeconds(axeHitCooldown);

        axeHitReady = true;
    }
}
