using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDirectionWheel : MonoBehaviour
{
    //public Image[] images;
    public static CDirectionWheel instance;
    private Image img;
    private Touch t;
    private Animator anim;

    void Awake()
    {
        instance = this;
    }

	void Start ()
    {
        img = GetComponent<Image>();
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
		if(Input.touchCount == 1)
        {
            t = Input.GetTouch(0);
        }
        switch (t.phase)
        {
            case TouchPhase.Began:
                Enable(t.position);
                break;
            case TouchPhase.Moved:
                break;
            case TouchPhase.Ended:
                img.enabled = false;
                anim.SetInteger("NivelDeFuerza", 0);
                break;
            default:
                break;
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
        else if(magnitude > 250 && magnitude < 300)
        {
            magnitude = 3;
        }
        else if(magnitude > 300)
        {
            magnitude = 4;
        }
        anim.SetInteger("NivelDeFuerza", (int)magnitude);
    }

    public void Rotate(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        //transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Atan2(delta.y, delta.x)) * Mathf.Rad2Deg);
    }
}
