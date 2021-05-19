using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
/*
 * Code how to prevent walking animation from starting when playing surprised animation came from:
 * Talinro. (2017) Stop movement of character on specific animation. (online) Unity Answers. Available at: https://answers.unity.com/questions/1399466/stop-movement-of-character-on-specific-animation.html. (Accessed on: 28th April 2021).
 */
{
    //Hide the variable section to minimise clutter
    #region Player Variables 

    float walkSpeed = 2.0f;

    #endregion


    public override void EnterState(PlayerController_FSM player)
    {
        player.wingSprite.localPosition = new Vector3(player.wingSprite.localPosition.x, 2.3f, player.wingSprite.localPosition.z); //Return wings to its original position when not walking

        if (player.anim != null)
        {
            //Check whether the animation tagged 'isSurprised' (for PlayerSurprisedStateAnim) is playing
            if (player.anim.GetCurrentAnimatorStateInfo(0).IsTag("isSurprised"))
            {
                //Prevent the walking animation from starting when surprised anim is playing
                Debug.Log("Continuing with surprised anim");
                return;
            }
            else
            {
                //If it is not playing, then play walking anim
                player.anim.Play("Base Layer.PlayerWalkingStateAnim");
                Debug.Log("Not playing surprised anim");
            }
            //Debug.Log("Aziraphale is walking!");
        }
    }

    public override void OnCollisionEnter(PlayerController_FSM player)
    {

    }

    public override void OnCollisionExit(PlayerController_FSM player)
    {

    }

    public override void Update(PlayerController_FSM player)
    {
        //Player controller movement on horizontal axis, aka walk left or right
        player.transform.Translate(Input.GetAxisRaw("Horizontal") * walkSpeed * Time.deltaTime, 0, 0);
        //Debug.Log("Moved");

        //Return to idle state when player stop using input to move the avatar
        if (Input.GetButtonUp("Horizontal"))
        {
            //Debug.Log("Finished walking");

            player.wingSprite.localPosition = new Vector3(player.wingSprite.localPosition.x, 2f, player.wingSprite.localPosition.z); //Return wings to its original position when not walking

            player.TransitionToState(player.idleState); //Return to idle state when not walking
        }

        //If button pressed is mouse's left button
        if (Input.GetButtonDown("Fire1"))
        {
            //Transition to miracle state
            player.TransitionToState(player.miracleState);

            //Debug.Log("Transition to miracle state");
        }
    }
}