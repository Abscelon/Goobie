using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCamera : MonoBehaviour
{
    public GameObject goobie;
    private Vector3 pos;

	// Update is called once per frame
	void Update ()
    {
        pos = new Vector3(goobie.transform.position.x, goobie.transform.position.y, -10f);
	}
}
