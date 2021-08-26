using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera cam;
    public Weapon myWeapon;

    private float attackTimer;

    void Update()
    {
        attackTimer += Time.deltaTime;
        if(Input.GetAxis("Fire1") != 0 && attackTimer >= myWeapon.attackCoolDown)
        {
            DoAttack();
        }
    }
    private void DoAttack()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, myWeapon.attackRange_P))
        {
            if(hit.collider.tag == "Enemy")
            {
                EnemyGenericAI eHealth = hit.collider.GetComponent<EnemyGenericAI>();
                eHealth.TakeDamage(myWeapon.attackDamage_P);
            }
        }
    }
}
