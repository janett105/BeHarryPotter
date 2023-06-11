using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public GameObject target;
    private Rigidbody magicRigid;

    public float speed;
    public float rate = 3;

    public int damage = 10;

    void OnCollisionEnter(Collision other)
    {
        if(other.collider.gameObject.CompareTag("Plane"))   //Plane과 충돌 시
        {
            Debug.Log("Plane이야");
            Destroy(gameObject, 1f);
        }
        else if (other.collider.gameObject.CompareTag("Player"))   //Player과 충돌 시
        {
            if (gameObject.tag == "FireBall") 
            {
                Destroy(gameObject);
            }
            else if(gameObject.tag == "PlayerMagic")
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
        else if(other.collider.gameObject.CompareTag("Enemy"))   //Enemy과 충돌 시
        {
            if (gameObject.tag == "FireBall") 
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else if (gameObject.tag == "PlayerMagic")
            {
                Destroy(gameObject);
            }
        }
        else if (other.collider.gameObject.CompareTag("Shield"))   //Shield과 충돌 시
        {
            if (gameObject.tag == "FireBall")
            {
                Destroy(gameObject);
            }
            else if (gameObject.tag == "PlayerMagic") 
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }

    //magic이 "PlayerAttack"이면 player와 충돌해도 사라지면 안 됨, enemy와 충돌하면 사라져야함. 
    //magic이 fireball이면 지금 충돌처리 그대로 

    // Start is called before the first frame update
    void Start()
    {
        magicRigid = GetComponent<Rigidbody>();
        if (target == null)
        {

            GameObject tmp = GameObject.FindGameObjectWithTag("Player");
            target = tmp;
        }
    }
 

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            GameObject tmp = GameObject.FindGameObjectWithTag("Player");
            target = tmp;
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    
}
