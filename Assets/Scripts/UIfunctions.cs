using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIfunctions : MonoBehaviour
{
    [SerializeField] private PlayerAbilities playerAbilities;

    public void Interact()
    {
        

        playerAbilities.BreakOtherObject();
    }
}
