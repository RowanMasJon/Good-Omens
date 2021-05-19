using UnityEngine;

public abstract class NPCBaseState  //Doesn't derive from MonoBehaviour
/*
 * This script act as the abstract state, aka parent script, for the concrete states, aka children scripts. This script will provide three key functions that all state scripts require. The concrete scripts will be able to override the listed functions to serve their need as needed.
 * 
 * Based on Unity Technologies (2021) Finite State Machines in Unity. [online] Unity Learn. Available at: https://learn.unity.com/tutorial/managing-state?uv=2019.3&projectId=5db812ecedbc2a0020e271cb#. [Accessed on 20th March 2021).
*/

{
    //When the state activate, it will begin with EnterState function
    public abstract void EnterState(NPC_FSM NPC);

    //Update the state if there are any specific condition(s) placed
    public abstract void Update(NPC_FSM NPC);

    //Useful condition that activate on collision eg colliding with player avatar
    public abstract void OnCollisionEnter(NPC_FSM NPC);

    public abstract void OnCollisionExit(NPC_FSM NPC);
}
