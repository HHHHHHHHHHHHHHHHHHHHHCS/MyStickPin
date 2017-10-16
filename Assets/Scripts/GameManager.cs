using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint,swpanPoint,circle;
    [SerializeField]
    private GameObject pinPrefab;

    private Pin currentPin;

    private void Start()
    {
        Pin.Init(startPoint,circle);
        SpawnPin();
    }

    private void SpawnPin()
    {
        currentPin=Instantiate(pinPrefab, swpanPoint.position
            ,pinPrefab.transform.rotation).GetComponent<Pin>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentPin.StartFly();
        }
    }
}
