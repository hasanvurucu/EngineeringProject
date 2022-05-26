using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    private GameObject target;

    private Transform oppositeWay;

    [SerializeField] private float speed = 3;
    private float attackCooldown;

    [SerializeField] private float HP = 5;

    private Animator animator;
    void Start()
    {
        attackCooldown = 2;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();

        CheckHpStatus();

        BasicSelfHealing();

        Vector3 pos = transform.position;
        pos.y = 0f;
        transform.position = pos;
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
            if(HP >= 2) //Fight the target
            {
                //transform.LookAt(target.transform);
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime *5);

                if ((transform.position - target.transform.position).magnitude >= 1.75)
                {
                    Vector3 pos = transform.position;
                    pos += transform.forward * speed * Time.deltaTime;
                    transform.position = pos;

                    attackCooldown = 2;

                    animator.SetBool("isRunning", true);
                }
                else //Close enough to the player
                {
                    animator.SetBool("isRunning", false);
                    //prepare to hit
                    attackCooldown -= Time.deltaTime;

                    if(attackCooldown <= 0f)
                    {
                        Debug.Log("Attack!");
                        attackCooldown = 2f;

                        animator.SetBool("isAttacking", true);
                    }
                    else
                    {
                        animator.SetBool("isAttacking", false);
                    }
                }
            }else //Runaway from the target
            {
                transform.LookAt(2 * transform.position - target.transform.position);

                Vector3 pos = transform.position;
                pos += transform.forward * speed * Time.deltaTime;
                transform.position = pos;

                attackCooldown = 2;

                animator.SetBool("isAttacking", false);
                animator.SetBool("isRunning", true);
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

        animator.SetBool("isRunning", false);
    }

    public void GetHit(int damageAmount)
    {
        attackCooldown = 2f;

        HP -= damageAmount;
    }
}
