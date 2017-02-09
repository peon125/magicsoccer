using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostWall : MonoBehaviour
{
    public float lifeTime;
    GameObject whoCreated;

	void Start()
    {
        Destroy(gameObject, lifeTime);
	}

    void OnTriggerEnter(Collider colid)
    {
        if (colid.transform.tag == "ball")
        {
            colid.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            colid.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(gameObject);
            whoCreated.GetComponent<FrostPlayerControl>().setCanFireSuperShot(true);
        }
    }

    public void setWhoCreated(GameObject go)
    {
        whoCreated = go;
    }
}
