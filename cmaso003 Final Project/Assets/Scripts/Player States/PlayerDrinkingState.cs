using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrinkingState : PlayerBaseState
{
    //Variables
    #region

    public Color teaColour;

    #endregion

    public override void EnterState(PlayerController_FSM player)
    {
        player.anim.Play("Base Layer.PlayerSittingAnim");
        player.teaAnim.Play("Base Layer.PlayerDrinkingStateAnim");

        //Based on Jistyles. (2014) Coroutine without MonoBehaviour. [online] Unity Answers. Available at: https://answers.unity.com/questions/161084/coroutine-without-monobehaviour.html. [Accessed on: 10th May 2021].
        player.StartingCoroutine(WaitForClip(player, 4.8f));

        //Debug.Log("Enter drinking state");
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
        //Debug.Log("Started timing tea: " + Time.deltaTime);

        yield return new WaitForSeconds(timer);
        player.TransitionToState(player.idleState);

        //Debug.Log("Ended timing tea: " + Time.deltaTime);
    }
}