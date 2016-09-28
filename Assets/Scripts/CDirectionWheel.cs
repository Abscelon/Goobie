using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDirectionWheel : MonoBehaviour
{ /*  This script controls the GUI Direction Wheel */
    public static CDirectionWheel instance;

    private Image img;
    private Animator anim;
    private Touch t;
    private Vector2 initialTouch;
    private Vector2 touchDelta;
    private float hipotenuse;
    private float angle;
    private float x, y;

    void Awake()
    {
        instance = this;
    }

	void Start ()
    {
        img = GetComponent<Image>();
        anim = GetComponent<Animator>();
        img.enabled = false;
	}
	
	void Update ()
    {
		if(Input.touchCount > 0)
        {
            t = Input.GetTouch(0);
            switch (t.phase)
            {
                case TouchPhase.Began:
                    initialTouch = t.position;
                    Enable(t.position);
                    break;
                case TouchPhase.Moved:
                    touchDelta = t.position - initialTouch;
                    AdjustImage(touchDelta.magnitude);
                    x = t.position.x - initialTouch.x;
                    y = t.position.y - initialTouch.y;
                    hipotenuse = Vector2.Distance(t.position, initialTouch);
                    x = x / hipotenuse;
                    y = y / hipotenuse;
                    angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
                    Rotate(angle);
                    break;
                case TouchPhase.Ended:
                    img.enabled = false;
                    anim.SetInteger("NivelDeFuerza", 0);
                    break;
                default:
                    break;
            }
        }
	}

    public void Enable(Vector2 pos)
    {
        img.enabled = true;
        transform.position = pos;
    }

    public void AdjustImage(float magnitude)
    {
        if(magnitude < 100)
        {
            magnitude = 0;
        }
        else if(magnitude > 100 && magnitude < 150)
        {
            magnitude = 1;
        }
        else if(magnitude > 150 && magnitude < 200)
        {
            magnitude = 2;
        }
        else if(magnitude > 200 && magnitude < 250)
        {
            magnitude = 3;
        }
        else if(magnitude > 250)
        {
            magnitude = 4;
        }
        anim.SetInteger("NivelDeFuerza", (int)magnitude);
    }

    public void Rotate(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
