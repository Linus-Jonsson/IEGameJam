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
