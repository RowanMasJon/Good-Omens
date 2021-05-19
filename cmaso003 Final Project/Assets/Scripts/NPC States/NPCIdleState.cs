using UnityEngine;

public class NPCIdleState : NPCBaseState
{
    int randomNumber;

    public override void EnterState(NPC_FSM NPC)
    {
        //Debug.Log("Crowley is in idle state");
    }

    public override void OnCollisionEnter(NPC_FSM NPC)
    {
        randomNumber = Random.Range(1, 10); //When collided with player avatar, a random number is polled which will then become the condition to execute one of following options:
        //Debug.Log("Random number is: " + randomNumber);

        //If the random number polled is 8 or higher, do this
        if (randomNumber > 7)
        {
            NPC.TransitionToState(NPC.kissingState); //Transition to kissing state
            //Debug.Log("Kissing time!");
        }
        //If the random number is between 1 and 4, do this
        else if (randomNumber > 0 && randomNumber < 5)
        {
            NPC.TransitionToState(NPC.transformingState); //Transition to transforming state
            //Debug.Log("Transforming time!");
        }
        else
        {
            NPC.TransitionToState(NPC.talkingState);
            //If draw a number without set condition, do nothing
            Debug.Log("Failed roll");
        }
    }

    public override void OnCollisionExit(NPC_FSM NPC)
    {

    }

    public override void Update(NPC_FSM NPC)
    {

    }
}
