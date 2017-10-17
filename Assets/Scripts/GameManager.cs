using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get;
        private set;
    }




    [SerializeField]
    private Transform startPoint,swpanPoint;
    [SerializeField]
    private GameObject pinPrefab;
    [SerializeField]
    private RotateSelf circle;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Animation failAnim;



    private Pin currentPin;

    private bool canFly,isFail;

    private int score;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Pin.spawnEndEvent += SpawnEnd;
        Pin.flyEndEvent += FlyEnd;
        Pin.Init(startPoint,circle.transform);
        RefreshScoreText();
        SpawnPin();
    }

    private void SpawnPin()
    {
        currentPin=Instantiate(pinPrefab, swpanPoint.position
            ,pinPrefab.transform.rotation).GetComponent<Pin>();
    }



    private void Update()
    {
        if(!isFail&&Input.GetMouseButtonDown(0)&& canFly)
        {
            canFly = false;
            currentPin.StartFly();
        }
    }


    private void SpawnEnd()
    {
        canFly = true;
    }


    private void FlyEnd()
    {
        SpawnPin();

        AddScore();
    }


    public void FailGame()
    {
        if(!isFail)
        {
            isFail = true;
            circle.isFail = true;
            failAnim.Play("FailGameAnim");
        }
    }

    private void AddScore()
    {
        score += 1;
        RefreshScoreText();
    }

    public void RefreshScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
