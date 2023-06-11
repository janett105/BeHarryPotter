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
        if(other.collider.gameObject.CompareTag("Plane"))
        {
            Debug.Log("Plane¿Ãæﬂ");
            Destroy(gameObject);
        }

        else if (other.collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Playeræﬂ");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        magicRigid = GetComponent<Rigidbody>();
        if (target == null)
        {
            GameObject tmp = GameObject.FindGameObjectWithTag("Player");
            tmp.GetComponent<Transform>();
            target = tmp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((transform.position - target.transform.position) * speed * Time.deltaTime);
    }

}
