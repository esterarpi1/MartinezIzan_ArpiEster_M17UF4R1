using System;
using System.Collections;
using System.Collections.Generic;
using GameInputs;
using UnityEngine;

public class Walking : StateMachineBehaviour
{
    private Animator _animator;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _animator = animator;
        InputController.Crouch += Crouch;
        InputController.Run += Run;
        InputController.Walk += Walk;
    }

    private void Crouch()
    {
        _animator.SetBool("isCrouching", true);
    }
    private void Run()
    {
        _animator.SetBool("isRunning", true);
    }
    private void Walk(bool walking)
    {
        if(!walking) _animator.SetBool("isWalking", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        InputController.Crouch -= Crouch;
        InputController.Run -= Run;
        InputController.Walk -= Walk;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
