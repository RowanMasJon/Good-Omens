using System.Collections;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
/*
 * The initial state for player avatar. When the player is not controlling the avatar, they will return to idle state.
 * 
  * Based on Unity Technologies (2021) Finite State Machines in Unity. [online] Unity Learn. Available at: https://learn.unity.com/tutorial/managing-state?uv=2019.3&projectId=5db812ecedbc2a0020e271cb#. [Accessed on 20th March 2021).
 */
{
    public override void EnterState(PlayerController_FSM player)
    {
        //Debug.Log("Entered idle state by starting idle state");
    }

    public override void OnCollisionEnter(PlayerController_FSM player)
    {
        //Not applicable to idle state
    }

    public override void OnCollisionExit(PlayerController_FSM player)
    {

    }

    public override void Update(PlayerController_FSM player)
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            //When buttons for walking left or right is pressed, start walking state
            player.TransitionToState(player.walkingState);
            //Debug.Log("Transition to walking state");
        }
    }
}