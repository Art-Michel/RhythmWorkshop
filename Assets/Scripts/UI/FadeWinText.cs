using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeWinText : MonoBehaviour
{
    Image text;
    Color color = new Color();
    float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        color = text.color;
        color.a = 0.1f;
        text.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        text.color = color; 
        color.a += Time.unscaledDeltaTime * speed;
        text.color = color;
    }
}
