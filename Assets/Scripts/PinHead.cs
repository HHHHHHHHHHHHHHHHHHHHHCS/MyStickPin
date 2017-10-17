using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.PinHead))
        {
            transform.parent.GetComponent<Pin>().StopFly();
            GameManager.Instance.FailGame();
        }
    }
}
