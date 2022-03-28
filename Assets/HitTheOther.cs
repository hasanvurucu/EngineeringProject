using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTheOther : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CollectibleInfo>() != null)
        {
            other.GetComponent<CollectibleInfo>().BreakPiece(); //break piece of other
            this.gameObject.GetComponent<Collider>().enabled = false; //if made a hit, deactivate the collider
        }
    }
}
