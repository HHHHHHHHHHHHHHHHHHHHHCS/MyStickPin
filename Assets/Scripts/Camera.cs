using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private bool canRestart;

    public void RestartEvent()
    {
        canRestart = true;
    }

    private void Update()
    {
        if(canRestart&&Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.Restart();
        }
    }
}
