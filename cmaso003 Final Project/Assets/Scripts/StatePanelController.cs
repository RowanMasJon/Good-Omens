using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatePanelController : MonoBehaviour
/*
 * Based on Unity Technologies (2021) Finite State Machines in Unity. [online] Unity Learn. Available at: https://learn.unity.com/tutorial/managing-state?uv=2019.3&projectId=5db812ecedbc2a0020e271cb#. [Accessed on 20th March 2021).
 */
{
    //Hide the variable section to minimise clutter
    #region Visible States Variables

    [Header("Representation of Player's States")]
    [Tooltip("Please drag the related button to the relevant section.")]
    public Image idleStateButton;
    public Image walkingStateButton, readingStateButton, drinkingStateButton, miracleStateButton, surprisedStateButton; //Access images representing states

    [Header("Representation of NPC's States")]
    [Tooltip("Please drag the related button to the relevant section.")]
    public Image NPCIdleStateButton;
    public Image NPCKissingStateButton, NPCTransformStateButton, NPCTalkingStateButton, NPCUncomfortableStateButton;

    public Color currentStateColor; //Access base colour of image when a state is activated
    public Color releasedStateColour; //Revent back to base colour of image when a state is not in use

    #endregion

    private PlayerController_FSM player;
    private NPC_FSM NPC;

    private void Start()
    {
        player = FindObjectOfType<PlayerController_FSM>();
        NPC = FindObjectOfType<NPC_FSM>();
    }

    private void Update()
    {
        if (null != player && null != player.CurrentState)
        {
            playerShowState(player.CurrentState);
        }

        if (null != NPC && null != NPC.CurrentState)
        {
            NPCShowState(NPC.CurrentState);
        }
    }

    //Representing the state of player avatar aka white angel
    public void playerShowState(PlayerBaseState state)
    {
        //Check if current state is idle state
        if (state.GetType() == typeof(PlayerIdleState))
        {
            setButtonDown(idleStateButton); //Is currently idle
            setButtonUp(walkingStateButton); //Not currently walking
            setButtonUp(readingStateButton); //Not currently reading
            setButtonUp(drinkingStateButton); //Not currently eating
            setButtonUp(miracleStateButton); //Not currently casting miracle
            setButtonUp(surprisedStateButton); //Not currently surprised
            //Debug.Log("Idle button on");
        }
        else if (state.GetType() == typeof(PlayerWalkingState))
        {
            setButtonUp(idleStateButton); //Not currently idle
            setButtonDown(walkingStateButton); //Is currently walking
            setButtonUp(readingStateButton); //Not currently reading
            setButtonUp(drinkingStateButton); //Not currently eating
            setButtonUp(miracleStateButton); //Not currently casting miracle
            setButtonUp(surprisedStateButton); //Not currently surprised
            //Debug.Log("Walking button on");
        }
        else if (state.GetType() == typeof(PlayerReadingState))
        {
            setButtonUp(idleStateButton); //Not currently idle
            setButtonUp(walkingStateButton); //Not currently walking
            setButtonDown(readingStateButton); //Is currently reading
            setButtonUp(drinkingStateButton); //Not currently eating
            setButtonUp(miracleStateButton); //Not currently casting miracle
            setButtonUp(surprisedStateButton); //Not currently surprised
            //Debug.Log("Reading button on");
        }
        else if (state.GetType() == typeof(PlayerDrinkingState))
        {
            setButtonUp(idleStateButton); //Not currently idle
            setButtonUp(walkingStateButton); //Not currently walking
            setButtonUp(readingStateButton); //Not currently reading
            setButtonDown(drinkingStateButton); //Is currently eating
            setButtonUp(miracleStateButton); //Not currently casting miracle
            setButtonUp(surprisedStateButton); //Not currently surprised
            //Debug.Log("Eating button on");
        }
        else if (state.GetType() == typeof(PlayerMiracleState))
        {
            setButtonUp(idleStateButton); //Not currently idle
            setButtonUp(walkingStateButton); //Not currently walking
            setButtonUp(readingStateButton); //Not currently reading
            setButtonUp(drinkingStateButton); //Not currently eating
            setButtonDown(miracleStateButton); //Is currently casting miracle
            setButtonUp(surprisedStateButton); //Not currently surprised
            //Debug.Log("Miracle button on");
        }
        else if (state.GetType() == typeof(PlayerSurprisedState))
        {
            setButtonUp(idleStateButton); //Not currently idle
            setButtonUp(walkingStateButton); //Not currently walking
            setButtonUp(readingStateButton); //Not currently reading
            setButtonUp(drinkingStateButton); //Not currently eating
            setButtonUp(miracleStateButton); //Not currently casting miracle
            setButtonDown(surprisedStateButton); //Is currently surprised
            //Debug.Log("Surprised button on");
        }
        else if (state.GetType() == typeof(PlayerWorriedState))
        {
            setButtonUp(idleStateButton); //Not currently idle
            setButtonUp(walkingStateButton); //Not currently walking
            setButtonUp(readingStateButton); //Not currently reading
            setButtonUp(drinkingStateButton); //Not currently eating
            setButtonUp(miracleStateButton); //Not currently casting miracle
            setButtonDown(surprisedStateButton); //Is currently surprised
            //Debug.Log("Surprised button on");
        }
    }

    //Representing the current state of Crowley aka black angel
    public void NPCShowState(NPCBaseState state)
    {
        //Check if current state is idle state
        if (state.GetType() == typeof(NPCIdleState))
        {
            setButtonDown(NPCIdleStateButton); //Is currently idle
            setButtonUp(NPCKissingStateButton); //Not currently kissing
            setButtonUp(NPCTransformStateButton); //Not currently transforming
            setButtonUp(NPCTalkingStateButton); //Not currently talking
            setButtonUp(NPCUncomfortableStateButton); //Not currently uncomfortable
        }
        else if (state.GetType() == typeof(NPCKissingState))
        {
            setButtonUp(NPCIdleStateButton); //Not currently idle
            setButtonDown(NPCKissingStateButton); //Is currently kissing
            setButtonUp(NPCTransformStateButton); //Not currently transforming
            setButtonUp(NPCTalkingStateButton); //Not currently talking
            setButtonUp(NPCUncomfortableStateButton); //Not currently uncomfortable
        }
        else if (state.GetType() == typeof(NPCTransformState))
        {
            setButtonUp(NPCIdleStateButton); //Not currently idle
            setButtonUp(NPCKissingStateButton); //Not currently kissing
            setButtonDown(NPCTransformStateButton); //Is currently transforming
            setButtonUp(NPCTalkingStateButton); //Not currently talking
            setButtonUp(NPCUncomfortableStateButton); //Not currently uncomfortable
        }
        else if (state.GetType() == typeof(NPCTalkingState))
        {
            setButtonUp(NPCIdleStateButton); //Not currently idle
            setButtonUp(NPCKissingStateButton); //Not currently kissing
            setButtonUp(NPCTransformStateButton); //Not currently transforming
            setButtonDown(NPCTalkingStateButton); //Is currently talking
            setButtonUp(NPCUncomfortableStateButton); //Not currently uncomfortable
        }
        else if (state.GetType() == typeof(NPCUncomfortableState))
        {
            setButtonUp(NPCIdleStateButton); //Not currently idle
            setButtonUp(NPCKissingStateButton); //Not currently kissing
            setButtonUp(NPCTransformStateButton); //Not currently transforming
            setButtonUp(NPCTalkingStateButton); //Not currently talking
            setButtonDown(NPCUncomfortableStateButton); //Is currently uncomfortable
        }
    }

    private void setButtonDown(Image button)
    {
        button.color = currentStateColor;
        button.GetComponent<Image>().color = Color.blue;
        button.GetComponentInChildren<Text>().color = Color.yellow;
    }

    private void setButtonUp(Image button)
    {
        button.color = currentStateColor;
        button.GetComponent<Image>().color = Color.white;
        button.GetComponentInChildren<Text>().color = Color.black;
    }
}