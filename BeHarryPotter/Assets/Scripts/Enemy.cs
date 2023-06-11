using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : LivingEntity
{
    private Animator animator;
    public GameObject target;

    public GameObject magicPrefab;
    public Transform magicPos;
    public float speed = 2;

    public float spawnRate;
    private float timeAfterSpawn;

    private bool isDead = false;

    public enum CurrentState { idle, attack, dead };
    public CurrentState curState;

    public void Setup(float newHealth)
    {
        startingHealth = newHealth;
        health = newHealth;
    }

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        
    }

    void Update()
    {
        
    }

    public IEnumerator CheckState()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(2f);

            if (startingHealth == 0)
            {
                animator.SetTrigger("Dead");
                isDead = true;
            }

        }
    }

    IEnumerator magicAttack()
    {
        animator.SetBool("CanAttack", true);
        yield return new WaitForSeconds(3f);
        GameObject magic = Instantiate(magicPrefab, magicPos.position, magicPos.rotation);

        
        Destroy(magic, 2f);

        StartCoroutine(magicAttack());
        animator.SetBool("CanAttack", false);
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
