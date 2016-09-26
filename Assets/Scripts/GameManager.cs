using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text text; // temporal
    public GameObject Player;
    public GameObject SpritePlayer;
    public Vector2 initialTouch;
    public Vector2 currentTouch;
    public Vector2 finalTouch;
    private Vector2 touchDelta;
    private Rigidbody2D bodyPlayer;
    private Rigidbody2D spriteRigidbody;
    private Touch t;
    private CDirectionWheel wheel;
    private float angle;
    private float x;
    private float y;
    private float hip;
    public float rotationSpeed;

    // Use this for initialization
    void Start ()
    {
        wheel = CDirectionWheel.instance;
        bodyPlayer = Player.GetComponent<Rigidbody2D>();
        Input.simulateMouseWithTouches = true; // temporal
        spriteRigidbody = SpritePlayer.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        rotationSpeed = Vector2.Distance(initialTouch, currentTouch); // TODO - explain
        spriteRigidbody.angularVelocity = rotationSpeed;
        if (Input.touchCount > 0)
        {
            t = Input.GetTouch(0);
            text.text = Input.touchCount.ToString();
            switch(t.phase)
            {
                case TouchPhase.Began:
                    initialTouch = t.position;
                    break;
                case TouchPhase.Moved: // TODO - simplify
                    touchDelta = t.position - initialTouch;
                    wheel.AdjustImage(touchDelta.magnitude);
                    x = t.position.x - initialTouch.x;
                    y = t.position.y - initialTouch.y;
                    hip = Vector2.Distance(t.position, initialTouch);
                    x = x / hip;
                    y = y / hip;
                    angle = Mathf.Atan2(y,x) * Mathf.Rad2Deg;
                    wheel.Rotate(angle);
                    break;
                case TouchPhase.Ended: //TODO - limit the player velocity to steps
                    finalTouch = t.position;
                    touchDelta = finalTouch - initialTouch;
                    bodyPlayer.velocity = touchDelta;
                    break;
                default:
                    break;
            }
        }
        else // TODO - explain
        {
            rotationSpeed = Mathf.Lerp(rotationSpeed, 0, 0.7f);
        }

    }
}
