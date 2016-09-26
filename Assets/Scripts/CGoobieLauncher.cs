using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGoobieLauncher : MonoBehaviour
{
    public GameObject goobieSprite;

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
                    rb.velocity = touchDelta;
                    break;
                default:
                    break;
            }
        }
    }
}
