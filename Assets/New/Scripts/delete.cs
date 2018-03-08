using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour {

    public float lifetime = 1000;

    private Transform tr;
    private float spawntime;

    void OnEnable()
    {
        tr = transform;
        spawntime = Time.time;
    }
	
	void Update () {
		if(Time.time > spawntime + lifetime)
        {
            Destroy(gameObject);
        }
        //if(transform.position.y <= 1f)
        //{
        //    Destroy(gameObject);
        //}
	}
}
