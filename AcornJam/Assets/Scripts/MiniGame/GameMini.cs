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
    void Start()
    {
        StartGame();
        InputSpace.SpaceF = SpacePressed;
    }

    private void SpacePressed()
    {
    }
    public void StartGame()
    {
        StartCoroutine(MiniGame());
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
            GameSpeed += LerpSpeedChange * Time.deltaTime;

        }
    }

    private void NormalizeSpeed()
    {
        GameSpeed = Mathf.Clamp(GameSpeed, minSpeed, maxSpeed);
    }
}
