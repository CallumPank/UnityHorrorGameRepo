using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField]
    float attackRange;
    [SerializeField]
    float attackDamage;
    [SerializeField]
    float attackCooldown;
    [SerializeField]
    LayerMask attackLayer;

    bool isAttacking;
    GameObject player;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange, attackLayer))
        {
            if (hit.collider.tag == "Player")
            {
                if (!isAttacking)
                {
                    player = hit.collider.gameObject;
                    StartCoroutine("Attack");
                }
            }
        }
        else
        {
            if (isAttacking)
                StopAttacking();
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        GameManager.instance.DamagePlayer(attackDamage);
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    void StopAttacking()
    {
        StopCoroutine("Attack");
        isAttacking = false;
    }
}
