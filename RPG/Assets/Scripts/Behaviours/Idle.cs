using Unity.VisualScripting;
using UnityEngine;

public class Idle : StateMachineBehaviour
{
    private Animator _animator;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _animator = animator;

        InputController.Crouch += Crouch;
        InputController.Walk += Walk;
        InputController.Aim += Aim;
        InputController.Jump += Jump;
        InputController.Hit += Hit;
    }
    private void Jump()
    {
        _animator.SetBool("isJumping", true);
    }
    private void Aim()
    {
        if (_animator.GetLayerWeight(_animator.GetLayerIndex("Attack")) == 0) _animator.SetLayerWeight(_animator.GetLayerIndex("Attack"), 1);
        else _animator.SetLayerWeight(_animator.GetLayerIndex("Attack"), 0);
    }
    private void Crouch()
    {
        _animator.SetBool("isCrouching", true);
    }
    private void Walk(bool walking)
    {
        _animator.SetBool("isWalking", walking);
    }
    private void Hit()
    {
        _animator.SetBool("isHitting", true);
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
        InputController.Walk -= Walk;
        InputController.Aim -= Aim;
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
