using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
    float val;
    float speed = 0.4f;
    [SerializeField] Image text;

    private void Update()
    {
        Debug.Log("spin " + val);
        val +=  speed * Time.unscaledDeltaTime;
        transform.localScale= new Vector3(Mathf.Lerp(0.2f,1,val),Mathf.Lerp(0.2f,1,val),0);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 720, val));
    }
}
