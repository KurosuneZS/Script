using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendToNext : MonoBehaviour
{
    public Animator animator;
    public string nextScene;
    private bool playerIn = false;

    void Update()
    {
        if(playerIn == true)
        {
            StartCoroutine(WaitAnimation());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerIn = true;
        }
    }

    public async void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator WaitAnimation()
    {
        animator.Play("SendPlayer");

        while(!animator.GetCurrentAnimatorStateInfo(0).IsName("SendPlayer") || animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return null;
        }

        NextScene();
    }
}
