using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Player _player;
    private Animator animator;
    private void Awake()
    {
        _player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetFloat("Velocity", _player.GetCurrentSpeed());
        animator.SetFloat("HasJumped", InputManager._INPUT_MANAGER.TimeSinceSouthButtonPressed());
        animator.SetFloat("HasThrowed", InputManager._INPUT_MANAGER.TimeSinceThrowPressed());
        animator.SetFloat("Crouch",_player.GetCrouch());
    }
}
