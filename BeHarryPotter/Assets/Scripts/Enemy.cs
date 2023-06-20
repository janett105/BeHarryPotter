using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : LivingEntity
{
    private Animator animator;
    public GameObject target;
    private Material necroMtr;

    public GameObject magicPrefab;
    public Transform magicPos;


    public float coolTime;
    public float updateTime;

    public enum CurrentState { idle, attack, dead };
    public CurrentState curState;

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        necroMtr = transform.Find("necromancer").gameObject.GetComponent<SkinnedMeshRenderer>().materials[0];

    }

    void Update()
    {
        if (updateTime > coolTime)
        {
            updateTime = 0.0f;
            if(health > 0)
            {
                StartCoroutine(magicAttack());
            }
            
        }
        else
        {
            updateTime += Time.deltaTime;
        }
    }
    IEnumerator magicAttack()
    {
        animator.SetBool("CanAttack", true);
        GameObject magic = Instantiate(magicPrefab, magicPos.transform.position, magicPos.transform.rotation);
        magic.name = this.transform.parent.name;

        yield return new WaitForSeconds(0.5f);

        animator.SetBool("CanAttack", false);

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("PlayerMagic"))
        {
            health = health - 25f;

            StartCoroutine(OnDamage());
        }
    }

    IEnumerator OnDamage()
    {
        if (health > 0) 
        {
            animator.SetTrigger("Hit");
            necroMtr.color = new Color(203 / 255f, 87 / 255f, 87 / 255f, 255 / 255f);

            yield return new WaitForSeconds(1f);

            necroMtr.color = Color.white;
        }

        else
        {
            animator.SetTrigger("Dead");
            animator.SetBool("CanAttack", false);
        }
    }

}