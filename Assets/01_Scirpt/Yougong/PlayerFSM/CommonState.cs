using System;
using UnityEngine;

public interface IState
{
    void EnterState();
    void UpdateState();
    void ExitState();
}


public abstract class CommonState : MonoBehaviour, IState
{

    public FSMState _myState;
    protected FSM fsm;
    
    
    public FSM FSMMain => fsm;
    protected AnimationController _animator;

    public Transform Character
    {
        get;
        private set;
    }
    
    

    public Action Init = null;
    public Action UpdateAction = null;
    
    /// <summary>
    /// 필요하면 넣기
    /// </summary>
    public Action EventAction = null;
    public Action EndAction = null;



    protected void Awake() 
    {

        fsm = transform.parent.GetComponent<FSM>();
        Character = transform.parent.parent.transform;
       // _animator = transform.parent.parent.Find("Visual").GetComponent<AnimationController>();
        
        fsm.AddState(_myState, this);
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    

}