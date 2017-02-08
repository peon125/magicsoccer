using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostWall : MonoBehaviour
{
    public float liveTime;
	void Start()
    {
        Destroy(gameObject, liveTime);
	}

    void OnTriggerEnter(Collider colid)
    {
        if (colid.transform.tag == "ball")
        {
            colid.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            colid.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(gameObject);
        }
    }
}
