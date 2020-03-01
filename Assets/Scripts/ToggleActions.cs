﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

/// <summary>
/// Get flags from JointManger
/// </summary>
public class ToggleActions : MonoBehaviour
{
    public enum FlagType
    {
        isTouched,
        isOverlapped,
    }
    public FlagType flagType = FlagType.isTouched;

    Toggle toggle;

    TouchDetection thumb;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        toggle = transform.GetComponent<Toggle>();
        TouchDetection[] fingeres = GameObject.FindObjectsOfType<TouchDetection>();
        foreach (var finger in fingeres)
        {
            if (finger.fingertipType == Finger.thumb)
            {
                thumb = finger;
            }
        }
        switch (flagType)
        {
            case FlagType.isTouched:
                thumb.UpdateTouchStatus += ChangeToggleState;
                break;
            case FlagType.isOverlapped:
                thumb.UpdateOverlapStatus += ChangeToggleState;
                break;
            default:
                break;
        }
    }

    void ChangeToggleState(bool flag)
    {
        toggle.isOn = flag;
    }
}
