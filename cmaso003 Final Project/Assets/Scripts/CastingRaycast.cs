using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingRaycast : MonoBehaviour
{
    /*
     * To be attached to Game Manager
     * 
     * Using mouse over (and set input if so conditioned) to detect any gameobject with a collider
     * Useful to recognise specific gameobject when needed
     * 
     * Based on: Unity Technologies. (2020) Rays from the Camera. (online) Unity Documentation. Available at: https://docs.unity3d.com/Manual/CameraRays.html. (Accessed on: 23rd April 2021).
     */

    //Hide the variable sections to minimise clutter
    #region Variable 

    [Header("Require Camera")]
    [Tooltip("Please drag the appropriate camera to here.")]
    public new Camera camera; //Refer to the camera 
    public GameObject player; //Refer to gameobject with relevant script, in this case, the player avatar

    public bool inZone = false;

    #endregion

    private void Update()
    {
        Raycasting();
        //Continously check what the raycast is detecting
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Box")
        {
            inZone = true;
            Debug.Log("Box found"); //Check if in trigger zone of gameobject
        }
    }
    public void Raycasting()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition); //Cast the ray to the mouse's position new Ray(origin, direction);
        RaycastHit hit;

        //Visual representation of raycast in yellow
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.yellow);

        if (Physics.Raycast(ray, out hit, 500f))
        {
            // Debug.Log("Ray hit distance: " + hit.distance);

            //If pressing a mouse's left button when raycasting whilst in a trigger zone, do this
            if (inZone == true && Input.GetButtonDown("Fire1"))
            {
                //hit.collider.GetComponent<Renderer>().material.color = Color.yellow;
                //Debug.Log("Ray hit distance 2: " + hit.distance);

                //If the ray detected a gameobject named "Tea", do this
                if (hit.collider.name == "Tea")
                {

                    //Send a message to PlayerController_FSM script to activate the function "DrinkingTea"
                    player.SendMessage("DrinkingTea");

                }
                //If the ray detected a gameobject named "Chair", do this instead
                else if (hit.collider.name == "Book")
                {
                    //Send a message to PlayerController_FSM script to activate the function "ReadingBook"
                    player.SendMessage("ReadingBook");
                }
                //If any other gameobject, do nothing
                else
                {

                    //Debug.Log("Nothing relevant found");
                }
            }
            Debug.Log("Hit: " + hit.collider.name); //Name the gameobject that raycast is currently detecting
            //Debug.Log("Hit distance: " + hit.distance);
        }
    }
}
