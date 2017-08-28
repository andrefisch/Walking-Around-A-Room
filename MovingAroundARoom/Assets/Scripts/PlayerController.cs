using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    
    // PLAYER SPECIFIC STUFF
    public float acceleration;
    public float maxSpeed;
    private Rigidbody2D rb2d;

    // UI STUFF
    public Text countText;
    public Text winText;
    private int count;

    // MOUSE AND ROTATION STUFF
    private Vector2 mousePos;
    private Vector2 screenPoint;
    private Vector2 offset;
    private float angle;

    // called once, when the script is loaded
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
    }

    // called before rendering a frame. most game code goes here
    void Update()
    {
        mousePos = Input.mousePosition;
        screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        // cap the speed at 10
        if(rb2d.velocity.magnitude > maxSpeed)
        {
            rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
        }
    }

    // called just before performing any physics calculations. this is where most physics code will go
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * acceleration);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Gold: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "Collected All Gold!";
        }
    }
}
