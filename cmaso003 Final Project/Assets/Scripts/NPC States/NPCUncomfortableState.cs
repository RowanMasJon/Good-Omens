using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCUncomfortableState : NPCBaseState
{
    public override void EnterState(NPC_FSM NPC)
    {
        NPC.anim.Play("Base Layer.NPCUncomfortableStateAnim");

        //Based on Jistyles. (2014) Coroutine without MonoBehaviour. [online] Unity Answers. Available at: https://answers.unity.com/questions/161084/coroutine-without-monobehaviour.html. [Accessed on: 10th May 2021].
        NPC.StartingCoroutine(WaitForClip(NPC, 4f));
    }

    public override void OnCollisionEnter(NPC_FSM NPC)
    {

    }

    public override void OnCollisionExit(NPC_FSM NPC)
    {

    }

    public override void Update(NPC_FSM NPC)
    {

    }

    //Based on Jistyles. (2014) Coroutine without MonoBehaviour. [online] Unity Answers. Available at: https://answers.unity.com/questions/161084/coroutine-without-monobehaviour.html. [Accessed on: 10th May 2021].
    private IEnumerator WaitForClip(NPC_FSM NPC, float timer)
    {
        Debug.Log("Started timing uncomfortable: " + Time.deltaTime);

        yield return new WaitForSeconds(timer);
        NPC.TransitionToState(NPC.idleState);

        Debug.Log("Ended timing uncomfortable: " + Time.deltaTime);


    }
}
