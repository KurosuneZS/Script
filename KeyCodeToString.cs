using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCodeToString : MonoBehaviour
{
    public class KeyCodeToString : MonoBehaviour
    {
        public string keycodeString;

        void Update()
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(keyCode))
                    {
                        string keyName = Enum.GetName(typeof(KeyCode), keyCode);
                        Debug.Log("Pressed: " + keyName);
                    }
                }
            }
        }
    }
}