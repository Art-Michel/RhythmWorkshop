using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class UIBlur : MonoBehaviour
{
    [SerializeField] VolumeProfile volume;
    private void OnEnable()
    {
        DepthOfField dof;
        if (volume.TryGet<DepthOfField>(out dof))
            dof.active = true;
    }

    private void OnDisable()
    {
        DepthOfField dof;
        if (volume.TryGet<DepthOfField>(out dof))
            dof.active = false;
    }
}
