using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueEndCheck : MonoBehaviour
{
    public GameObject EndingChoice;

    [Header("Player")]
    public PlayerMovement playerMovement;
    public PlayerAudioMovement playerAudioMovement;
    public Animator playerAnimator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            EndingChoice.SetActive(true);
            playerMovement.enabled = false;
            playerAudioMovement.enabled = false;
            playerAnimator.enabled = false;
        }
    }
}
