using System.Collections;
using UnityEngine;
using Cinemachine;
 
public class VCamShake : MonoBehaviour {
 
    public static VCamShake instance;
 
    private CinemachineVirtualCamera vcam;
    private CinemachineBasicMultiChannelPerlin noise;
    private float _timeAtCurrentFrame;
    private float _timeAtLastFrame;
    private float _fakeDelta;
 
 
    void Awake()
    {
        instance = this;
        vcam = GetComponent<CinemachineVirtualCamera>();
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
 
    void Update()
    {
        // Calculate a fake delta time, so we can Shake while game is paused.
        _timeAtCurrentFrame = Time.realtimeSinceStartup;
        _fakeDelta = _timeAtCurrentFrame - _timeAtLastFrame;
        _timeAtLastFrame = _timeAtCurrentFrame;
    }
 
    public static void Shake(float duration)
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.cShake(duration));
    }
 
    public IEnumerator cShake(float duration)
    {
        while (duration > 0)
        {
            noise.m_AmplitudeGain = 1f;
            duration -= _fakeDelta;
            yield return null;
        }
 
        noise.m_AmplitudeGain = 0f;
    }  
}