using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void FlyEndDelegate();
public delegate void SpawnEndDelegate();

public class Pin : MonoBehaviour
{
    public static event FlyEndDelegate flyEndEvent;
    public static event SpawnEndDelegate spawnEndEvent;

    private static Transform circle;
    private static Vector3 startPoint, circlePoint;
    private const float circleRadius = 2.0f;
    [SerializeField]
    private float speed = 5;

    private bool isFly;
    private bool isReach;


    public static void Init(Transform _startPoint, Transform _circle)
    {
        circle = _circle;
        startPoint = _startPoint.position;
        circlePoint = _circle.position - new Vector3(0, circleRadius, 0);
    }

    private void Update()
    {
        if (!isFly)
        {
            if (!isReach)
            {
                Vector3 offest = Vector3.MoveTowards(transform.position, startPoint
                    , speed * Time.deltaTime);
                if (offest.y >= startPoint.y)
                {

                    transform.position = startPoint;
                    isReach = true;
                    spawnEndEvent();

                }
                else
                {
                    transform.position = offest;
                }
            }
        }
        else
        {
            Vector3 offest = Vector3.MoveTowards(transform.position, circlePoint
                    , speed * Time.deltaTime);
            if (offest.y >= circlePoint.y)
            {
                transform.SetParent(circle);
                transform.position = circlePoint;
                isFly = false;
                flyEndEvent();
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

    public void StopFly()
    {
        isFly = false;
    }
}
