using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCamera : MonoBehaviour
{
    public Transform goobie;
	// Use this for initialization
	void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(goobie.position.x, goobie.position.y, -10f);	
	}
}
