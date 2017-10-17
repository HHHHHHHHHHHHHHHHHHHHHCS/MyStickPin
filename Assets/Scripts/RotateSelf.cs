using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    public float speed = 90;
    public bool isFail;

    private void Update()
    {
        if(!isFail)
        {
            transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
        }

    }

}
