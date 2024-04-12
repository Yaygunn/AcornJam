using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameMini : MonoBehaviour
{
    [SerializeField] ImageManage ImageManage;

    [SerializeField] InputSpace InputSpace;

    [SerializeField] MiniGamWin miniGamWin;

    private float GameSpeed = 0;

    private float LerpSpeedChange;

    private float LerpSpeedNormal = 0.2f;

    private float minSpeed = -1;

    private float maxSpeed = 0.3f;

    private float SpaceSpeedChange = -0.3f;

    private bool ControlSuccess = false;

    [HideInInspector] public bool GameContinue; 
    void Start()
    {
        StartGame();
        InputSpace.SpaceF = SpacePressed;
    }

    private void SpacePressed()
    {
        if (miniGamWin.PressedEnterOnTheRightTime())
        {
            GameSpeed = SpaceSpeedChange;
            LerpSpeedChange = 0;
            Invoke("ResetSpeedChange",0.1f);
        }
    }

    private void ResetSpeedChange()
    {
        LerpSpeedChange = LerpSpeedNormal;
    }
    public void StartGame()
    {
        GameContinue = true;
        StartSettings();
        StartCoroutine(MiniGame());
    }

    private void StartSettings()
    {
        GameSpeed = 0.2f;
    }

    IEnumerator MiniGame()
    {
        ControlSuccess = false;
        LerpSpeedChange = LerpSpeedNormal;
        float FilledAmount = 0;
        Invoke("StartWhite", 1.7f);
        Invoke("StartControl", 2f);
        while (NotSuccesseded(FilledAmount))
        {
  
            yield return null;
            NormalizeSpeed();
            FilledAmount += Time.deltaTime * GameSpeed;
            ImageManage.SetImageRate( FilledAmount );
            SpeedChange();
            FilledAmount = math.clamp( FilledAmount, -0.2f, 1 );

        }
        Succeded();
    }

    private void StartControl()
    {
        ControlSuccess = true;
    }
    private void Succeded()
    {
        print("MiniGameSuccess");
        GameContinue = false;
        miniGamWin.EndWhite();
        ImageManage.End();
    }

    private bool NotSuccesseded(float rate)
    {
        if(!ControlSuccess)
            return true;
        if(rate < 0.4f)
            return false; 
        return true;
    }

    private void StartWhite()
    {
        miniGamWin.CreateWhite();
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
            GameSpeed += LerpSpeedChange * Time.deltaTime * 0.5f;
        }
    }
}
