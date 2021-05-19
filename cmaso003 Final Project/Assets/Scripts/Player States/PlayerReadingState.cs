using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReadingState : PlayerBaseState
{


    public override void EnterState(PlayerController_FSM player)
    {
        player.anim.Play("Base Layer.PlayerSittingAnim");
        player.bookAnim.Play("Base Layer.PlayerReadingStateAnim");

        //Based on Jistyles. (2014) Coroutine without MonoBehaviour. [online] Unity Answers. Available at: https://answers.unity.com/questions/161084/coroutine-without-monobehaviour.html. [Accessed on: 10th May 2021].
        player.StartingCoroutine(WaitForClip(player, 5f));

        //Debug.Log("Enter reading state");
    }

    public override void OnCollisionEnter(PlayerController_FSM player)
    {

    }

    public override void OnCollisionExit(PlayerController_FSM player)
    {

    }

    public override void Update(PlayerController_FSM player)
    {

    }

    //Based on Jistyles. (2014) Coroutine without MonoBehaviour. [online] Unity Answers. Available at: https://answers.unity.com/questions/161084/coroutine-without-monobehaviour.html. [Accessed on: 10th May 2021].
    private IEnumerator WaitForClip(PlayerController_FSM player, float timer)
    {
        //Debug.Log("Started timing book: " + Time.deltaTime);

        yield return new WaitForSeconds(timer);
        player.TransitionToState(player.idleState); //Return to idle state when not reading

        //Debug.Log("Ended timing book: " + Time.deltaTime);
    }
}