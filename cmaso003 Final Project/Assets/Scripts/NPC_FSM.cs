using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_FSM : MonoBehaviour
/*
 * This script provide the 'context' to maintain an instance of a concrete state (player specific states) as the current state. The initial state will be idle state.
 * 
 * Based on Unity Technologies (2021) Finite State Machines in Unity. [online] Unity Learn. Available at: https://learn.unity.com/tutorial/managing-state?uv=2019.3&projectId=5db812ecedbc2a0020e271cb#. [Accessed on 20th March 2021).
*/

{
    //Hide the variable sections to minimise clutter
    #region NPC Variables 

    [Header("Required gameobjects")]
    [Tooltip("Please drag the appropriate gameobject to here.")]
    public MeshRenderer bodyRender; //Access the gameobject mesh renderer
    public Transform wingSprite; //To flutter the wings
    public SpriteRenderer snakeSprite; //To change transparency
    public Animator anim; //Refer to animator component

    public GameObject player; //Refer to gameobject with relevant script, in this case, the player avatar

    private Rigidbody rbody;
    public Rigidbody Rbody
    {
        get { return rbody; } //Allow concrete states to access this as needed
    }

    //public GameObject angels;
    //public GameObject demons;

    #endregion

    //Variables relating to activating a state
    #region State Variables 

    private NPCBaseState currentState; //access the abstract state to maintain an instance of concrete state that will be considered as current state

    public NPCBaseState CurrentState
    {
        get { return currentState; } //Access and check which state that player avatar is currently in
    }

    //An instance of each states avaiable to this context script in readonly form so won't change variable by accident
    public readonly NPCIdleState idleState = new NPCIdleState(); //Initial state of player avatar
    public readonly NPCKissingState kissingState = new NPCKissingState();
    public readonly NPCTransformState transformingState = new NPCTransformState();
    public readonly NPCTalkingState talkingState = new NPCTalkingState();
    public readonly NPCUncomfortableState uncomfortableState = new NPCUncomfortableState();


    #endregion

    private void Start()
    {
        anim = GetComponent<Animator>();

        TransitionToState(idleState); //When the game start, the NPC will be initialised in the idle state
    }

    private void Update()
    {
        currentState.Update(this); //Check the Update function specific to current state (whichever state that may be) and execute it as necessary
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this); //When collision detected, check current state's OnCollisionEnter function and execute
    }

    private void OnCollisionExit(Collision collision)
    {
        currentState.OnCollisionExit(this); //When leaving collision, check current state's OnCollisionExit function and execute
    }

    public void TransitionToState(NPCBaseState state)
    {
        //Store and set current concrete state
        currentState = state; //set the state as the current state
        currentState.EnterState(this); //Activate the EnterState function of a new state for player avatar when a transition is triggered
    }

    //Based on Jistyles. (2014) Coroutine without MonoBehaviour. [online] Unity Answers. Available at: https://answers.unity.com/questions/161084/coroutine-without-monobehaviour.html. [Accessed on: 10th May 2021].
    public void StartingCoroutine(IEnumerator coroutineMethod)
    {
        //To add in delay of state change when animation clip is playing
        //Using Coroutine method
        StartCoroutine(coroutineMethod);
    }

    public void Uncomfortable()
    {
        TransitionToState(uncomfortableState);
        //Debug.Log("Uncomfortable by miracle");
    }
}
