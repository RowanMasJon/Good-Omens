using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCKissingState : NPCBaseState
{
    public override void EnterState(NPC_FSM NPC)
    {
        NPC.anim.Play("Base Layer.NPCKissingStateAnim");
        NPC.player.SendMessage("Surprised");

        //Based on Jistyles. (2014) Coroutine without MonoBehaviour. [online] Unity Answers. Available at: https://answers.unity.com/questions/161084/coroutine-without-monobehaviour.html. [Accessed on: 10th May 2021].
        NPC.StartingCoroutine(WaitForClip(NPC, 4f));
    }

    public override void OnCollisionEnter(NPC_FSM NPC)
    {

    }

    public override void OnCollisionExit(NPC_FSM NPC)
    {
        NPC.TransitionToState(NPC.idleState); //Change back to idle state when finished kissing
        Debug.Log("Kiss ended");
    }

    public override void Update(NPC_FSM NPC)
    {

    }

    //Based on Jistyles. (2014) Coroutine without MonoBehaviour. [online] Unity Answers. Available at: https://answers.unity.com/questions/161084/coroutine-without-monobehaviour.html. [Accessed on: 10th May 2021].
    private IEnumerator WaitForClip(NPC_FSM NPC, float timer)
    {
        Debug.Log("Started timing kiss: " + Time.deltaTime);

        yield return new WaitForSeconds(timer);
        NPC.player.SendMessage("Idling");

        Debug.Log("Ended timing kiss: " + Time.deltaTime);
    }
}
