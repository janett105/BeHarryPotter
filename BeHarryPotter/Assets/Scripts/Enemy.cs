using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : LivingEntity
{
    private Animator animator;
    public GameObject target;

    public GameObject magicPrefab;
    public Transform magicPos;
    private Transform enemyPos;
    public float speed;

    public float spawnRate;
    private float timeAfterSpawn;

    private float coolTime = 2f;
    private float updateTime = 0f;

    //private bool isDead = false;

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

        yield return new WaitForSeconds(2f);

        animator.SetBool("CanAttack", false);
        
    }

}
