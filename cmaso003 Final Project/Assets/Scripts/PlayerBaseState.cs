using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class PlayerBaseState //Doesn't derive from MonoBehaviour
/*
 * This script act as the abstract state, aka parent script, for the concrete states, aka children scripts. This script will provide three key functions that all state scripts require. The concrete scripts will be able to override the listed functions to serve their need as needed.
 * 
 * Based on Unity Technologies (2021) Finite State Machines in Unity. [online] Unity Learn. Available at: https://learn.unity.com/tutorial/managing-state?uv=2019.3&projectId=5db812ecedbc2a0020e271cb#. [Accessed on 20th March 2021).
*/

{
    //When the state activate, it will begin with EnterState function
    public abstract void EnterState(PlayerController_FSM player);

    //Update the state if there are any specific condition(s) placed
    public abstract void Update(PlayerController_FSM player);

    //Useful condition that activate on collision eg hitting the ground after a jump
    public abstract void OnCollisionEnter(PlayerController_FSM player);

    //Useful condition that activate on collision exit
    public abstract void OnCollisionExit(PlayerController_FSM player);
}
