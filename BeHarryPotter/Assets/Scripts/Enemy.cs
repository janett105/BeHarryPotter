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

    public GameObject magicPrefab;
    public Transform magicPos;

    public float coolTime;
    public float updateTime;

    public enum CurrentState { idle, attack, dead };
    public CurrentState curState;

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (updateTime > coolTime)
        {
            updateTime = 0.0f;
            StartCoroutine(magicAttack());
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerMagic")
        {
            health = health - 10f;
            StartCoroutine(OnDamaged());
        }
    }

    IEnumerator OnDamaged()
    {
        if (health > 0)
        {
            yield return null;
        }
        else
        {
            animator.SetTrigger("Dead");
        }
    }
}