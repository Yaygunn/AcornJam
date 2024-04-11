using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImageManage : MonoBehaviour
{
    [SerializeField] Transform BlackImage;
    [SerializeField] Transform WhiteImage;


    private float BaseScale;
    [SerializeField] float FilledScale;

    [SerializeField] float WhiteBaseScale;
    [SerializeField] float WhiteReadyScale;
    [SerializeField] float WhiteEndScale;

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
}
