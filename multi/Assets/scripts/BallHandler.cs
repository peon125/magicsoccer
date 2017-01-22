using UnityEngine;
using System.Collections;

public class BallHandler : MonoBehaviour {
    //public float wartosc;
    Rigidbody rb;

    void Start() 
    {
        RandomizePosition();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "grass")
        {
            return;
        }

//        if(collision.gameObject.tag == "shots")
//        {
//            float force = collision.gameObject.GetComponent<ShotHandler>().getStrikeForce();
//            gameObject.GetComponent<Rigidbody>().AddForce (new Vector3(force, 0f, 0f));    
//        }
    }

    public void RandomizePosition()
    {
        float randomZ = Random.Range(-40f, 40f);
        transform.position = new Vector3(0f, gameObject.transform.position.y, randomZ);
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
