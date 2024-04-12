using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ImageManage : MonoBehaviour
{
    [SerializeField] Transform BlackImage;
    [SerializeField] Transform WhiteImage;


    private float BaseScale;
    [SerializeField] float FilledScale;

    [SerializeField] float WhiteBaseScale;
    [SerializeField] float WhiteReadyScale;
    [SerializeField] float WhiteEndScale;

    [SerializeField] Image WhiteViewImage;
    [SerializeField] Image Target1;
    [SerializeField] Image Target2;

    [SerializeField] Color TargetColorWhite;
    [SerializeField] Color TargetColorBlack;
    [SerializeField] Color TargetColorRed;


    void Start()
    {
        BaseScale = BlackImage.localScale.x;
    }

    public void SetImageRate(float rate)
    {
        float newScale = Mathf.Lerp(BaseScale, FilledScale, rate);
        SetImageScale(newScale);
    }

    public void SetWhiteImageRateBefore(float rate)
    {
        float newScale = Mathf.Lerp(WhiteBaseScale, WhiteReadyScale, rate);
        SetWhiteImageScale(newScale);
    }

    public void SetWhiteImageRateAfter(float rate)
    {
        float newScale = Mathf.Lerp(WhiteReadyScale, WhiteEndScale, rate);
        SetWhiteImageScale(newScale);
    }

    void SetImageScale(float scale)
    {
        BlackImage.transform.localScale = new Vector3(scale, scale, scale);
    }
    void SetWhiteImageScale(float scale)
    {
        WhiteImage.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void PressedSpace(bool success)
    {
        StartCoroutine(Space(success));
    }
    IEnumerator Space(bool success)
    {
        float rate = 1;
        if (success)
        {
            while(rate>0)
            {
                SetTargetColor(TargetColorBlack);
                SetWhiteImageRateBefore(rate);
                SetTargetImageVisibility(rate);
                rate -= 10 * Time.deltaTime;
                yield return null;
            }
            SetWhiteImageRateBefore(rate);
            SetTargetImageVisibility(rate);
        }
        else
        {
            SetTargetColor(TargetColorRed);
            WhiteViewImage.color = TargetColorRed;

            yield return new WaitForSeconds(0.1f);

            ResetColor();
            SetTargetImageVisibility(0);
        }
    }

    private void ResetColor()
    {
        WhiteViewImage.color = TargetColorWhite;
        Target1.color = TargetColorWhite;
        Target2.color = TargetColorWhite;   
    }

    private void SetTargetColor(Color color)
    {
        Target1.color = color;
        Target2.color = color;
    }
    public void SetTargetImageVisibility(float rate)
    {
        Color c = Target1.color;
        c.a = rate;
        Target1.color = c;
        Target2.color = c;
    }
}
