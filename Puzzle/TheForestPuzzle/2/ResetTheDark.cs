using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTheDark : MonoBehaviour
{
    public TheDarkManage theDarkManage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SendReset();
        }
    }

    public void SendReset()
    {
        theDarkManage.ReceivedReset("PlayerOut");
    }
}
