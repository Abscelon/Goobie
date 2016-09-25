using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGoobieLauncher : MonoBehaviour
{
    public Text text;
    public Text text2;
    [Header("Force Settings")]
    [Range(2, 10)]
    public float forceMultiplier;
    [Range(100, 500)]
    public float maxForce;
    Vector3 firstTouchPos;
    Touch t;
    Rigidbody2D rb;
    bool firstTouch;
    bool launched;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        firstTouch = true;
        launched = false;
    }

    //void Update()
    //{
    //    if (firstTouch && Input.touchCount > 0)
    //    {
    //        // primer touch
    //        firstTouch = false;
    //        t = Input.GetTouch(0);
    //        firstTouchPos = t.position;
    //        text.text = "First touch: " + firstTouchPos.ToString();
    //    }
    //    else if(Input.touchCount > 0 && !firstTouch)
    //    {
    //        // arrastrar el touch
    //        t = Input.GetTouch(0);
    //        launched = false;
    //        text2.text = "Current pos: " + t.position;
    //    }
    //    else if(Input.touchCount == 0 && !launched)
    //    {
    //        // solto el touch
    //        launched = true;
    //        firstTouch = true;
    //        float x = t.position.x - firstTouchPos.x;
    //        float y = t.position.y - firstTouchPos.y;
    //        text2.text = "X: " + x + " Y: " + y;
    //        x = Mathf.Clamp(x, -maxForce, maxForce);
    //        y = Mathf.Clamp(y, -maxForce, maxForce);
    //        //text2.text = "X: " + x + " Y: " + y;
    //        Vector2 force = new Vector2(x, y) * forceMultiplier * Time.deltaTime;
    //        //text2.text = "Force: " + force.ToString();
    //        rb.velocity = Vector2.zero;
    //        rb.AddForce(force, ForceMode2D.Impulse);
    //    }
    //}

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
            t = Input.GetTouch(0);
        if (firstTouch && Input.touchCount > 0)
        {
            // primer touch
            firstTouch = false;
            t = Input.GetTouch(0);
            firstTouchPos = t.position;
            text.text = "First touch: " + firstTouchPos.ToString();
        }
        else if (Input.touchCount > 0 && !firstTouch)
        {
            // arrastrar el touch
            t = Input.GetTouch(0);
            launched = false;
            text2.text = "Current pos: " + t.position;
        }
        else if (Input.touchCount == 0 && !launched)
        {
            // solto el touch
            launched = true;
            firstTouch = true;
            float x = t.position.x - firstTouchPos.x;
            float y = t.position.y - firstTouchPos.y;
            text2.text = "X: " + x + " Y: " + y;
            x = Mathf.Clamp(x, -maxForce, maxForce);
            y = Mathf.Clamp(y, -maxForce, maxForce);
            //text2.text = "X: " + x + " Y: " + y;
            Vector2 force = new Vector2(x, y) * forceMultiplier * Time.deltaTime;
            //text2.text = "Force: " + force.ToString();
            rb.velocity = Vector2.zero;
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }

    //void OnMouseDrag()
    //{
    //    t = Input.GetTouch(0);
    //    text2.text = "Current pos: " + t.position;
    //}

    //void OnMouseUp()
    //{
    //    float x = t.position.x - firstTouchPos.x;
    //    float y = t.position.y - firstTouchPos.y;
    //    text2.text = "X: " + x + " Y: " + y;
    //    x = Mathf.Clamp(x, -maxForce, maxForce);
    //    y = Mathf.Clamp(y, -maxForce, maxForce);
    //    //text2.text = "X: " + x + " Y: " + y;
    //    Vector2 force = new Vector2(x, y) * forceMultiplier *  Time.deltaTime;
    //    //text2.text = "Force: " + force.ToString();
    //    rb.AddForce(-force, ForceMode2D.Impulse);
    //}
}
