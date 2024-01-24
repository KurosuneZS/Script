using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{ 
    Rigidbody2D rb;
    [Header("Player System")]
    public float speed = 1f;
    public float jumpPower = 1.5f;


    int point;
    float t; /////////////// เป็นตัวแปรเวลา ///////////////////

    bool onPlatform;
    bool isStop;
    Vector2 reset_pos;

    // Use This For Initialization
    void Start()
    {
        reset_pos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        isStop = false;
        reset_pos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStop) SunnyController();
    }

    void Update()
    {
        if (!isStop) Jump();
        if (Input.GetKeyDown(KeyCode.R)) Application.LoadLevel(0);
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    void SunnyController()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            transform.position -= Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.Translate(new Vector2(0, 0));
        }
    }
    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && onPlatform)
        {
            rb.velocity = new Vector2(0, jumpPower);
            onPlatform = false;
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Platform")
        {
            onPlatform = true;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Point")
        {
            Destroy(c.gameObject);
        }
    }
}
