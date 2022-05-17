using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    private GameObject target;

    [SerializeField] private float speed = 3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            transform.LookAt(target.transform);

            if((transform.position - target.transform.position).magnitude >= 1.7)
            {
                Vector3 pos = transform.position;
                pos += transform.forward * speed * Time.deltaTime;
                transform.position = pos;
            }
            else
            {
                //prepare to hit
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    public void ReleaseTarget()
    {
        target = null;
    }
}
