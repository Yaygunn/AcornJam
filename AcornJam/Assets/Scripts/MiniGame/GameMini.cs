using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMini : MonoBehaviour
{
    [SerializeField] ImageManage ImageManage;

    [SerializeField] InputSpace InputSpace;

    private float GameSpeed = 0;

    private float LerpSpeedChange = 0.2f;

    private float minSpeed = -1;

    private float maxSpeed = 1;

    private float SpaceSpeedChange = -0.3f;
    void Start()
    {
        StartGame();
        InputSpace.SpaceF = SpacePressed;
    }

    private void SpacePressed()
    {
        GameSpeed = SpaceSpeedChange;
    }
    public void StartGame()
    {
        StartSettings();
        StartCoroutine(MiniGame());
    }

    private void StartSettings()
    {
        GameSpeed = 0.2f;
    }

    IEnumerator MiniGame()
    {
        float FilledAmount = 0;
        while (true)
        {
            yield return null;
            NormalizeSpeed();
            FilledAmount += Time.deltaTime * GameSpeed;
            ImageManage.SetImageRate( FilledAmount );
            SpeedChange();

        }
    }

    private void NormalizeSpeed()
    {
        GameSpeed = Mathf.Clamp(GameSpeed, minSpeed, maxSpeed);
    }
    private void SpeedChange()
    {
        GameSpeed += LerpSpeedChange * Time.deltaTime;
        if(GameSpeed < 0 ) 
        {
            GameSpeed += LerpSpeedChange * Time.deltaTime;
        }
    }
}
