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
        if(other.collider.gameObject.CompareTag("Plane"))   //plane에 닿았을 때
        {
            Debug.Log("Plane이야");
            Destroy(gameObject, 1f);       
        }
        else if (other.collider.gameObject.CompareTag("Player"))   
        {
            if (gameObject.tag == "FireBall" || gameObject.tag == "IceBall") //적 공격이 나한테 맞았을 때 -> 으악 소리 삽입
            {
                Destroy(gameObject);
            }
            else if(gameObject.tag == "PlayerMagic") 
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
        else if(other.collider.gameObject.CompareTag("Enemy")) 
        {
            if (gameObject.tag == "FireBall" || gameObject.tag == "IceBall") 
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else if (gameObject.tag == "PlayerMagic")//내 공격이 적한테 맞았을 때 
            {
                Destroy(gameObject);
            }
        }
        else if (other.collider.gameObject.CompareTag("Shield")) 
        {
            if (gameObject.tag == "FireBall" || gameObject.tag == "IceBall")    //적 공격을 방어했을 때
            {
                Debug.Log("방어!!!!!!!!!!!!!");
                Destroy(gameObject);
            }
            else if (gameObject.tag == "PlayerMagic") 
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }

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
