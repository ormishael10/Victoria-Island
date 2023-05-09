 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public Animator anim;
    public LayerMask enemyLayers;//  ����� ������� ���� ���� �� ������� 
    public float attackDamage;
    float attackRate = 2f;// 2 attacks per sec
    float nextAttack = 0f;
    void Start()
    {
        attackDamage = 25;
        attackRange = 0.5f;
    }

    void Update()
    {
        // current time
        if(Time.time >= nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttack = Time.time + 1f / attackRate;
            }
        }  
    }

    void Attack()
    { 
        anim.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);//���� ����� ���� ���� ����� ������ ������ ����� �� �� �� ���� ����
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<FroggyMovement>().TakeDamage(attackDamage);
            
        }
    }

    void OnDrawGizmosSelected()//���� ������ ��� ����� �� �������� ������
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
