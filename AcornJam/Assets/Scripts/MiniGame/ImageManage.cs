using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImageManage : MonoBehaviour
{
    [SerializeField] Transform image;

    private float BaseScale;
    [SerializeField] float FilledScale;
    void Start()
    {
        BaseScale = image.localScale.x;
    }

    public void SetImageRate(float rate)
    {
        float newScale = Mathf.Lerp(BaseScale, FilledScale, rate);
        SetImageScale(newScale);
    }

    void SetImageScale(float scale)
    {
        image.transform.localScale = new Vector3(scale, scale, scale);
    }
}
