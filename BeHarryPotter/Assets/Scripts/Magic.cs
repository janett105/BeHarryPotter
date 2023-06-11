using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public Transform magicPos;
    public GameObject target;

    private Rigidbody magicRigid;

    public float speed;
    public float rate = 3;

    public int damage = 10;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Plane")
        {
            Destroy(gameObject, 3f);
        }

        else if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        magicRigid = GetComponent<Rigidbody>();
        
    }

    private void OnColiisionEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((target.transform.position - magicPos.position) * speed * Time.deltaTime);
    }

    
}
