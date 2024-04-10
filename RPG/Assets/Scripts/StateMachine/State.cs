using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class State
{
    StateController sc;
    public virtual void OnEnter(StateController stateController)
    {
        sc = stateController;
        OnEnter();
    }
    public virtual void OnEnter()
    {

    }
    public void OnStateUpdate()
    {
        OnUpdate();
    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnHurt()
    {

    }

    public virtual void OnExit()
    {

    }
}
