using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDefault: LivingEntity
{
    private Animator animator;
    private LayerMask whatIsTarget; //추적대상 레이어
    private Transform _transform;
    private Transform playerTransform;

    private LivingEntity target;//추적대상

    //component
    NavMeshAgent nav; //경로 계산 AI 에이전트
    Rigidbody rigid;
    CapsuleCollider capsuleCollider;

    private bool isDead = false;

    public enum CurrentState { idle, walk, attack, dead, block};
    public CurrentState curState = CurrentState.idle;

    public float chaseDistance;
    public float attackDistance;
    public float shieldDistance;

    /*public ParticleSystem hitEffect; //피격 이펙트
    public AudioClip deathSound;//사망 사운드
    public AudioClip hitSound; //피격 사운드
    */

    //스태프
    public GameObject firePoint; //매직미사일이 발사될 위치
    public GameObject magicMissilePrefab; //사용할 매직미사일 할당
    public GameObject magicMissile; //Instantiate()메서드로 생성하는 매직미사일을 담는 게임오브젝트

    //private AudioSource enemyAudioPlayer; //오디오 소스 컴포넌트

    public float damage = 30f; //공격력
    public float attackDelay = 2.5f; //공격 딜레이
    private float lastAttackTime; //마지막 공격 시점

    private bool canMove;
    private bool canAttack;

    private void Awake()
    {
        //게임 오브젝트에서 사용할 컴포넌트 가져오기
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void Setup(float newHealth)
    {
        //체력 설정
        startingHealth = newHealth;
        health = newHealth;
    }

    private void Start()
    {
        _transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nav = this.gameObject.GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();
        
        StartCoroutine(this.CheckState());
        
    }


    //추적할 대상의 위치를 주기적으로 찾아 경로 갱신, 대상이 있으면 공격한다.
    void FreezeVelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        FreezeVelocity();
    }

    public void Chase(Vector3 targetPosition)
    {
        animator.SetBool("CanMove", true);
        nav.SetDestination(targetPosition);

        animator.SetBool("CanAttack", false);
    }

    public IEnumerator CheckState()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(0.2f);
            float distance = Vector3.Distance(playerTransform.position, _transform.position);

            if (distance <= attackDistance)
            {
                curState = CurrentState.attack;
                StartCoroutine(Attack());
            }
            else if (distance <= chaseDistance)
            {
                curState = CurrentState.walk;
                Chase(playerTransform.position);
            }
            else if (startingHealth == 0)
            {
                animator.SetTrigger("Die");
                nav.isStopped = true;
                isDead = true;
            }
            /*
            else
            {
                curState = CurrentState.idle;
                animator.SetBool("IsWalk", true);
                animator.SetBool("IsAttack", false);
            }
            */
        }
    }

    IEnumerator Attack()
    {
        float distance = Vector3.Distance(playerTransform.position, _transform.position);

        nav.ResetPath();
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("CanMove", false);

        if (distance <= shieldDistance)
        {
            //animator.SetBool("IsWalk", false);
            animator.SetBool("CanAttack", false);
        }
        else if (distance > shieldDistance)
        {
            //animator.SetBool("IsWalk", false);
            animator.SetBool("CanAttack", true);
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            health = health - 10f;
            StartCoroutine(OnDamaged());
        }

        else if (other.tag == "Bullet")
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
            animator.SetTrigger("Die");
        }
    }

    //유니티 애니메이션 이벤트로 지팡이를 앞으로 휘두를 떄 메서드 실행
    public void ShamanFire()
    {
        magicMissile = Instantiate(magicMissilePrefab, firePoint.transform.position, firePoint.transform.rotation); //Instatiate()로 매직 미사일 프리팹을 복제 생성한다.
    }

    /*미사일에서 데미지 처리하기
    
    //유니티 애니메이션 이벤트로 휘두를 때 데미지 적용시키기
    public void OnDamageEvent()
    {
        //상대방의 LivingEntity 타입 가져오기
        LivingEntity attackTarget = targetEntity.GetComponent<LivingEntity>();

        //공격 처리
        attackTarget.OnDamage(damage);
    }
    */


    //데미지를 입었을 때 실행할 처리
    

    //사망 처리
    public override void Die()
    {
        //LivingEntity의 DIe()를 실행하여 기본 사망 처리 실행
        base.Die();

        //다른 AI를 방해하지 않도록 자신의 모든 콜라이더를 비활성화
        Collider[] enemyColliders = GetComponents<Collider>();
        for (int i = 0; i < enemyColliders.Length; i++)
        {
            enemyColliders[i].enabled = false;
        }

        //AI추적을 중지하고 네비메쉬 컴포넌트를 비활성화
        nav.isStopped = true;
        nav.enabled = false;

        //사망 애니메이션 재생
        animator.SetTrigger("Die");
        /*//사망 효과음 재생
        enemyAudioPlayer.PlayOnShot(deathSound);
        */

    }
}