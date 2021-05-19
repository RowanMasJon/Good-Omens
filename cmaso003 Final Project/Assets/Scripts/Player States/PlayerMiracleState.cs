using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMiracleState : PlayerBaseState
{


    public override void EnterState(PlayerController_FSM player)
    {
        //player.flowerSprite.color = new Color(1, 1, 1, 1); //Render kiss sprite visible
        player.anim.Play("Base Layer.PlayerMiracleStateAnim");
        player.crowley.SendMessage("Uncomfortable");

        //Based on Jistyles. (2014) Coroutine without MonoBehaviour. [online] Unity Answers. Available at: https://answers.unity.com/questions/161084/coroutine-without-monobehaviour.html. [Accessed on: 10th May 2021].
        player.StartingCoroutine(WaitForClip(player, 3f));

        //Debug.Log("Enter miracle state");
    }

    public override void OnCollisionEnter(PlayerController_FSM player)
    {

    }

    public override void OnCollisionExit(PlayerController_FSM player)
    {

    }

    public override void Update(PlayerController_FSM player)
    {
        /*  if (Input.GetButtonUp("Fire1"))
          {
              Debug.Log("Finished casting miracle");
              player.flowerSprite.color = new Color(0, 0, 0, 0); //Render kiss sprite visible
              player.TransitionToState(player.idleState); //Return to idle state when not casting miracle
          }*/
    }

    private IEnumerator WaitForClip(PlayerController_FSM player, float timer)
    {
        //Debug.Log("Started timing miracle: " + Time.deltaTime);

        yield return new WaitForSeconds(timer);
        player.TransitionToState(player.walkingState); //Return to idle state when not reading

        //Debug.Log("Ended timing miracle: " + Time.deltaTime);
    }
}