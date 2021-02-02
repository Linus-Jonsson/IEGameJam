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
    [SerializeField] private GameObject Uzi;
    private GunAnimator uziAnimator;

    void Start()
    {
        state = PlayerState.notAiming;
        uziAnimator = Uzi.GetComponent<GunAnimator>();
    }

    void Update()
    {
        if (uziAnimator != null)
        {
            if (state == PlayerState.aiming)
            {
                uziAnimator.isAiming(true);
            }
            else
            {
                uziAnimator.isAiming(false);
            }
        }
        else
        {
            uziAnimator = Uzi.GetComponent<GunAnimator>();
        }
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
