using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDisable : MonoBehaviour
{
    public void OnAnimationComplete()
    {
        gameObject.SetActive(false);
    }
}
