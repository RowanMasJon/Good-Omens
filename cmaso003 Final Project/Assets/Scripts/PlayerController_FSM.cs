using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_FSM : MonoBehaviour

/*
 * This script provide the 'context' to maintain an instance of a concrete state (player specific states) as the current state. The initial state will be idle state.
 * 
 * Based on Unity Technologies (2021) Finite State Machines in Unity. [online] Unity Learn. Available at: https://learn.unity.com/tutorial/managing-state?uv=2019.3&projectId=5db812ecedbc2a0020e271cb#. [Accessed on 20th March 2021).
*/

{
    //Hide the variable sections to minimise clutter
    #region Player Variables 

    [Header("Required gameobject")]
    [Tooltip("Please drag the appropriate gameobject to here.")]
    public MeshRenderer bodyRender; //Refer to gameobject mesh renderer
    public Transform wingSprite; //To flutter the wings
    public SpriteRenderer flowerSprite; //To change transparency
    public Animator teaAnim; //Access the tea's animator component
    public Animator bookAnim; //Access the book's animator component

    public Animator anim; //Refer to animator component

    private Rigidbody rbody;
    public Rigidbody Rbody
    {
        get { return rbody; } //Allow concrete states to access this as needed
    }

    //public GameObject angels;
    //public GameObject demons;
    public GameObject crowley; //Refer to main NPC

    #endregion

    //Variables relating to activating a state
    #region State Variables 

    private PlayerBaseState currentState; //access the abstract state to maintain an instance of concrete state that will be considered as current state

    public PlayerBaseState CurrentState
    {
        get { return currentState; } //Access and check which state that player avatar is currently in
    }

    //An instance of each states avaiable to this context script in readonly form so won't change variable by accident
    public readonly PlayerIdleState idleState = new PlayerIdleState(); //Initial state of player avatar
    public readonly PlayerWalkingState walkingState = new PlayerWalkingState();
    public readonly PlayerDrinkingState drinkingState = new PlayerDrinkingState();
    public readonly PlayerReadingState readingState = new PlayerReadingState();
    public readonly PlayerMiracleState miracleState = new PlayerMiracleState();
    public readonly PlayerSurprisedState surprisedState = new PlayerSurprisedState();
    public readonly PlayerWorriedState worriedState = new PlayerWorriedState();

    #endregion

    private void Start()
    {
        anim = GetComponent<Animator>();

        TransitionToState(idleState); //When the game start, the avatar will be initialised in the idle state
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
        currentState.OnCollisionExit(this); //When left collision, check current state's OnCollisionExit function and execute
    }

    public void TransitionToState(PlayerBaseState state)
    {
        //Store and set current concrete state
        currentState = state; //set the state as the current state
        currentState.EnterState(this); //Activate the EnterState function of a new state for player avatar when a transition is triggered
    }

    public void DrinkingTea()
    {
        TransitionToState(drinkingState);
        //Debug.Log("Drinking tea yum!");
    }

    public void ReadingBook()
    {
        TransitionToState(readingState);
        //Debug.Log("Reading time now");
    }

    public void Surprised()
    {
        TransitionToState(surprisedState);
        //Debug.Log("Surprised by kiss!");
    }

    public void Worried()
    {
        TransitionToState(worriedState);
        //Debug.Log("Worried by snake");
    }

    public void Idling()
    {
        TransitionToState(idleState);
        //Debug.Log("Idling");
    }
    public void StartingCoroutine(IEnumerator coroutineMethod)
    {
        //To add in delay of state change when animation clip is playing
        //Using Coroutine method
        StartCoroutine(coroutineMethod);
    }
}