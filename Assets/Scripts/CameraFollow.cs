using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*** 
*file: CameraFollow.cs 
*author: Flor Hernandez 
*class: CS 4700 – Game Development 
*assignment: Final Project 
*date last modified: 12/4/2022 
* 
*purpose: This code makes sure the camera follows the player
*as they move through the levels and is set to a certain offset
*within the player's range
* 
**/

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(3f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
