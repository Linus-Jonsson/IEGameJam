using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    aiming,
    notAiming,
    dead,
    won
}
public class PlayerController : MonoBehaviour
{
    private PlayerState state;
    private Animator animator;

    void Start()
    {
        state = PlayerState.notAiming;
    }

    void Update()
    {
        
    }

    public void SetState(PlayerState s)
    {
        state = s;
    }
    public PlayerState GetState()
    {
        return state;
    }
}
