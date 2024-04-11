using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamWin : MonoBehaviour
{
    [SerializeField] ImageManage ImageManage;
    [SerializeField] GameMini gameMini;

    bool whiteExists = false;
    float speed = 1.0f;
    float ReadySpeed = 5f;
    float CurrentRate;
    bool Ready = false;

    public void CreateWhite()
    {
        if (whiteExists)
            return;

        StartCoroutine(WhiteProcess());
    }

    IEnumerator WhiteProcess()
    {
        CurrentRate = 0;
        while (true)
        {
            CurrentRate += speed * Time.deltaTime;

            if(CurrentRate >= 1)
            {
                break;
            }

            ImageManage.SetWhiteImageRateBefore(CurrentRate);

            yield return null;
        }

        CurrentRate = 0;
        Ready = true;
        while (true)
        {
            CurrentRate += ReadySpeed * Time.deltaTime;

            if (CurrentRate >= 1)
            {
                break;
            }

            ImageManage.SetWhiteImageRateAfter(CurrentRate);

            yield return null;
        }
        EndWhite();

    }

    public void EndWhite()
    {
        StopAllCoroutines();
        whiteExists = false;
        ImageManage.SetWhiteImageRateBefore(0);
    }
}
