using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DataConfig : ScriptableObject
{
    [Header("Player")]
    //Character locomotion
    public float JumpHeight;
    public float Gravity;
    public float StepDown;
    public float AirControl;
    public float JumpDamp;
    public float GroundSpeed;
    public float PushPower;

    //Character aiming
    public float TurnSpeed = 15f;

    [Header("UI")]
    public float NotifyLoadingTime = 5f;

    [Header("Game Component")]
    public float BounceSpeed = 8;
    public float BounceAmplitude = 0.05f;
    public float RotationSpeed = 90;

}
