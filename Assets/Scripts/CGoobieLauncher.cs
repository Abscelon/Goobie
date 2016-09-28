using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGoobieLauncher : MonoBehaviour
{
    public GameObject goobieSprite;
    public Text text; // for debugging
    private Rigidbody2D rb;
    private Rigidbody2D spriteRb;
    private Touch t;
    private Vector2 initialTouch;
    private Vector2 touchDelta;
    private float hipotenuse;
    private float angle;
    private float x, y;
    // test
    private float rotationSpeed;
    private Vector2 currentTouch;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //spriteRb = goobieSprite.GetComponentInChildren<Rigidbody2D>();
        spriteRb = GetComponentInChildren<Rigidbody2D>();
    }

    void Update()
    {
        rotationSpeed = Vector2.Distance(initialTouch, currentTouch); // TODO - explain
        spriteRb.angularVelocity = rotationSpeed;
        text.text = touchDelta.magnitude.ToString();
        if (Input.touchCount > 0)
        {
            t = Input.GetTouch(0);
            switch (t.phase)
            {
                case TouchPhase.Began:
                    initialTouch = t.position;
                    break;
                case TouchPhase.Ended:
                    touchDelta = t.position - initialTouch;
                    float newX, newY;
                    newX = Mathf.Pow(touchDelta.x, 2f) / touchDelta.magnitude;
                    // set velocity levels
                    if(touchDelta.magnitude < 100f) // TODO
                    {
                        rb.velocity = Vector2.zero;
                    }
                    else if(touchDelta.magnitude > 100f && touchDelta.magnitude < 150f)
                    {
                        newX = (Mathf.Pow(touchDelta.x, 2f) / touchDelta.magnitude) * 10f;
                        newY = (Mathf.Pow(touchDelta.y, 2f) / touchDelta.magnitude) * 10f;
                        rb.velocity = new Vector2(newX, newY);
                    }
                    else if (touchDelta.magnitude > 150f && touchDelta.magnitude < 200f)
                    {
                        newX = (Mathf.Pow(touchDelta.x, 2f) / touchDelta.magnitude) * 30f;
                        newY = (Mathf.Pow(touchDelta.y, 2f) / touchDelta.magnitude) * 30f;
                        rb.velocity = new Vector2(newX, newY);
                    }
                    else if (touchDelta.magnitude > 200f && touchDelta.magnitude < 250f)
                    {
                        newX = (Mathf.Pow(touchDelta.x, 2f) / touchDelta.magnitude) * 50f;
                        newY = (Mathf.Pow(touchDelta.y, 2f) / touchDelta.magnitude) * 50f;
                        rb.velocity = new Vector2(newX, newY);
                    }
                    else if (touchDelta.magnitude > 250f)
                    {
                        newX = (Mathf.Pow(touchDelta.x, 2f) / touchDelta.magnitude) * 60f;
                        newY = (Mathf.Pow(touchDelta.y, 2f) / touchDelta.magnitude) * 60f;
                        rb.velocity = new Vector2(newX, newY);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
