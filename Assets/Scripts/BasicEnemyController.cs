using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    private GameObject target;

    [SerializeField] private float speed = 3;
    private float attackCooldown;

    [SerializeField] private float HP = 5;
    void Start()
    {
        attackCooldown = 2;
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();

        CheckHpStatus();

        BasicSelfHealing();
    }

    private void CheckHpStatus()
    {
        if(HP <= 0)
        {
            Debug.Log("Basic enemy died");

            Destroy(gameObject);
        }
    }

    private void BasicSelfHealing()
    {
        if (HP < 5)
            HP += Time.deltaTime * (0.2f);
        else
            HP = 5;
    }

    private void StateMachine()
    {
        if (target != null)
        {
            transform.LookAt(target.transform);

            if ((transform.position - target.transform.position).magnitude >= 1.7)
            {
                Vector3 pos = transform.position;
                pos += transform.forward * speed * Time.deltaTime;
                transform.position = pos;

                attackCooldown = 2;
            }
            else //Close enough to the player
            {
                //prepare to hit
                attackCooldown -= Time.deltaTime;

                if(attackCooldown <= 0f)
                {
                    Debug.Log("Attack!");
                    attackCooldown = 2f;
                }
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

    public void GetHit(int damageAmount)
    {
        attackCooldown = 2f;

        HP -= damageAmount;
    }
}
