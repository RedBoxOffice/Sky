using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashAnimationsName : MonoBehaviour
{
    public int IdleHash { get; } = Animator.StringToHash("Idle");
    public int RunningHash { get; } = Animator.StringToHash("Running");
    public int FlyingHash { get; } = Animator.StringToHash("Flying");
    public int FallingHash { get; } = Animator.StringToHash("Falling");
    public int TreadingWater { get; } = Animator.StringToHash("TreadingWater");
}
