using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyRange : MonoBehaviour
{
    private BasicEnemyController basicEnemyController;
    private void Awake()
    {
        if(transform.parent.GetComponent<BasicEnemyController>() != null)
            basicEnemyController = transform.parent.GetComponent<BasicEnemyController>();
        else
        {
            Debug.Log("Basic enemy parent component is missing, destroying this");
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.PlayerTag)
            basicEnemyController.SetTarget(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.PlayerTag)
            basicEnemyController.ReleaseTarget();
    }
}
