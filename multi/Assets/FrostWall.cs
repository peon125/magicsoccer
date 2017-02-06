using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostWall : MonoBehaviour
{
	void Start()
    {
		
	}

    void OnTriggerEnter(Collision colid)
    {
        if (colid.transform.tag == "ball")
        {
            colid.rigidbody.angularVelocity = Vector3.zero;
            colid.rigidbody.velocity = Vector3.zero;
        }
    }
}
