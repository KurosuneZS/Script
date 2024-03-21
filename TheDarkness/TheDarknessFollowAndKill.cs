using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDarknessFollowAndKill : MonoBehaviour
{
    [Header("Follow")]
    public GameObject camera;
    public float xSlowPosition;
    public float speed;
    public float yPosition;
    private float tolerance = 0.01f;

    [Header("Kill Player")]
    public GameObject player;
    public GameObject gameOver;
    public GameObject TheDarkness;
    private GameObject gameObject;

    void Start()
    {
        gameObject = GetComponent<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOver.SetActive(true);
            Destroy(collision.gameObject);
            Destroy(TheDarkness);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(transform.position.x >= xSlowPosition)
        {
            speed = 3.5f;
        }
        
        Follow();
    }

    void Follow()
    {
        Vector3 camerarPosition = camera.transform.position;
        Vector3 direction = camerarPosition - transform.position;

        if (direction != Vector3.zero)
        {
            direction.Normalize();
            float moveX = direction.x * speed * Time.deltaTime;

            transform.position = new Vector3(transform.position.x, camerarPosition.y, transform.position.z);

            transform.Translate(moveX, 0, 0);
        }
    }
}
