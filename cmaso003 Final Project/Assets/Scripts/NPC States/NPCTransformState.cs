using UnityEngine;

public class NPCTransformState : NPCBaseState
{
    #region NPC Variables



    #endregion


    public override void EnterState(NPC_FSM NPC)
    {
        NPC.snakeSprite.color = new Color(1, 1, 1, 1); //Render snake sprite visible
        NPC.bodyRender.enabled = false; //Deactivate the gameobject mesh renderer
        NPC.wingSprite.gameObject.SetActive(false); //Deactivate wings to hide them
        Debug.Log("Transformed into a snake");


        //NPC.anim.Play("Base Layer.NPCKissingStateAnim");
        NPC.player.SendMessage("Worried");

        //Based on Jistyles. (2014) Coroutine without MonoBehaviour. [online] Unity Answers. Available at: https://answers.unity.com/questions/161084/coroutine-without-monobehaviour.html. [Accessed on: 10th May 2021].
        // NPC.StartingCoroutine(WaitForClip(NPC, 4f));
    }

    public override void OnCollisionEnter(NPC_FSM NPC)
    {

    }

    public override void OnCollisionExit(NPC_FSM NPC)
    {
        NPC.snakeSprite.color = new Color(1, 1, 1, 0); //Render snake sprite invisible
        NPC.bodyRender.enabled = true; //Reactivate gameobject mesh renderer
        NPC.wingSprite.gameObject.SetActive(true); //Reactivate wings to show them

        NPC.TransitionToState(NPC.idleState); //Change back to idle state when finished tranforming
    }

    public override void Update(NPC_FSM NPC)
    {

    }
}
