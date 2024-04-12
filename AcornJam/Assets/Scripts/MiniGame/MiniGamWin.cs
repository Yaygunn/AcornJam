using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamWin : MonoBehaviour
{
    [SerializeField] ImageManage ImageManage;
    [SerializeField] GameMini gameMini;

    bool whiteExists = false;
    float speed = 1.0f;
    float ReadySpeed = 1f;
    float CurrentRate;
    bool Ready = false;
    float RepeatTime = 0.5f;
    float FailRepeatTime = 0.4f;


    public void CreateWhite()
    {
        if (whiteExists)
            return;

        StartCoroutine(WhiteProcess());
    }

    IEnumerator WhiteProcess()
    {
        whiteExists = true;
        Ready = false;
        CurrentRate = 0;
        while (true)
        {
            CurrentRate += speed * Time.deltaTime;

            if(CurrentRate >= 1)
            {
                break;
            }

            ImageManage.SetTargetImageVisibility(CurrentRate * 0.1f);

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
                ImageManage.PressedSpace(false);
                break;
            }

            ImageManage.SetWhiteImageRateAfter(CurrentRate);

            yield return null;
        }
        EndWhite(false);

    }

    public bool PressedEnterOnTheRightTime()
    {
        if (whiteExists)
        {
            EndWhite(Ready);
            print("Ready is " + Ready);
            
            ImageManage.PressedSpace(Ready);
            
            return Ready;
        }

        ImageManage.PressedSpace(false);

        return false;
    }

    public void EndWhite(bool success)
    {
        StopAllCoroutines();
        whiteExists = false;
        //ImageManage.SetWhiteImageRateBefore(0);
        //ImageManage.SetTargetImageVisibility(0);
        if (success )
            Invoke("CreateWhite", RepeatTime);
        else
            Invoke("CreateWhite", FailRepeatTime);
    }
}
