using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private static Vector3 startPoint, circle;
    private const float circleRadius = 2.2f;
    [SerializeField]
    private float speed = 5;

    private bool isFly;
    private bool isReach;


    public static void Init(Transform _startPoint, Transform _circle)
    {
        startPoint = _startPoint.position;
        circle = _circle.position - new Vector3(0, circleRadius, 0);
    }

    private void Update()
    {
        if (!isFly)
        {
            if (!isReach)
            {
                Vector3 offest = Vector3.MoveTowards(transform.position, startPoint
                    , speed * Time.deltaTime);
                if (offest.y > startPoint.y)
                {
                    Debug.Log(1);
                    transform.position = startPoint;
                    isReach = true;
                }
                else
                {
                    transform.position = offest;
                }
            }
        }
        else
        {
            Vector3 offest = Vector3.MoveTowards(transform.position, circle
                    , speed * Time.deltaTime);
            if (offest.y > circle.y)
            {
                transform.position = circle;
                isFly = false;
            }
            else
            {
                transform.position = offest;
            }
        }
    }



    public void StartFly()
    {
        isFly = true;
    }
}
