using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : LivingEntity
{
    private Animator animator;
    public GameObject target;

    public GameObject magicPrefab;
    public Transform magicPos;
    public float speed;

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
        animator.SetBool("CanAttack", true);
        StartCoroutine(magicAttack());
    }

    void Update()
    {
        
    }

    IEnumerator magicAttack()
    {
        animator.SetBool("CanAttack", true);
        GameObject magic = Instantiate(magicPrefab, magicPos.position, magicPos.rotation);
        yield return new WaitForSeconds(3f);
        StartCoroutine(magicAttack());
    }

}
