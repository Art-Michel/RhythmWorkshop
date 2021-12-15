using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    Image _image;
    float t;
    private void Start()
    {
        _image = GetComponent<Image>();
        t= 0;
    }

    void Update()
    {
        t += Time.deltaTime * 0.7f;
        Debug.Log(t);
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, Mathf.Lerp(0, 1, t));
    }
}
