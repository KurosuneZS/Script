using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerPos;
    Vector3 offset;
    public bool freezeY;
    // Start is called before the first frame update
    void Start()
    {
        if(playerPos != null) offset = transform.position - playerPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos != null)
        {
            if (freezeY)
                transform.position = new Vector3(playerPos.position.x, 0, playerPos.position.z) + offset;
            else
                transform.position = playerPos.position + offset;
        }
    }
}
