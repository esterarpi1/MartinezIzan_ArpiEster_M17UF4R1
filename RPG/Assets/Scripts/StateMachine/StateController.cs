using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    State currentState;

    public WalkState walkState = new WalkState();
    public RunState runState = new RunState();
    public AttackState attackState = new AttackState();
    public InjuredState injuredState = new InjuredState();
    public DeadState deadState = new DeadState();
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(walkState);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnUpdate();
        }   
    }
    public void ChangeState(State newState)
    {
        if(currentState != null)
        {
            currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter();
    }
    public interface IState
    {
        public void OnEnter(StateController controller);

        public void UpdateState(StateController controller);

        public void OnHurt(StateController controller);

        public void OnExit(StateController controller);
    }
}
