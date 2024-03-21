using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject GameOver;
    private Animator animator;
    public bool activate = false;
    public Transform player;
    private Vector3 lastPosition;

    private Coroutine activateCoroutine;
    private Coroutine deactivateCoroutine;
    private KillPlayer killPlayer;

    void Start()
    {
        animator = GetComponent<Animator>();
        killPlayer = GetComponent<KillPlayer>();
    }

    void Update()
    {
        if (activate == true)
        {
            Killing();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (activateCoroutine == null)
                activateCoroutine = StartCoroutine(ActivateLoop());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (activateCoroutine != null)
            {
                StopCoroutine(activateCoroutine);
                activateCoroutine = null;
            }
        }
    }

    public void disable(string message)
    {
        activate = false;
    }

    public void PlayerPos(string message)
    {
        lastPosition = player.position;
        activate = true;
    }

    void Killing()
    {
        if (player.position != lastPosition)
        {
            // GameOver.SetActive(true);
            // Destroy(player.gameObject);
            // Destroy(killPlayer);
            Debug.Log("YouDie" + " at " + player.position + "form" + lastPosition);
        }
    }

    IEnumerator ActivateLoop()
    {
        while (true)
        {
            float delay = Random.Range(1f, 3f);
            float delay2 = Random.Range(3f, 5f);

            yield return new WaitForSeconds(delay);

            Debug.Log("FirstDelay : " + delay2);

            yield return new WaitForSeconds(delay);

            Debug.Log("Delay : " + delay);
            if(animator != null)
            {
                animator.Play("Activate");
            }

            yield return new WaitForSeconds(delay2);

            Debug.Log("Delay2 : " + delay2);

            yield return new WaitForSeconds(delay);

            Debug.Log("Delay : " + delay);
            if (animator != null)
            {
                animator.Play("Deactivate");
                
            }
        }
    }
}
