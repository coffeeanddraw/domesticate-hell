// Credit: Jared Halpern from "Developing 2D Games with Unity"  
// Used for: Domesticate Hell 2019
// Adopted by: Cattatonicat 2019

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import the Cinemachine framework to write an extension component for Cinemachine Virtual Camera
using Cinemachine;

// Components that hook into Cinemachine's processing pipeline must inherit from CinemachineExtension
public class RoundCameraPos : CinemachineExtension
{
    [SerializeField]
    private float PixelsPerUnit = 16;

    // This method is required by all classes that inherit from CinemachineExtension 
    // Called by Cinemachine after the Confiner is done processing 
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        // The Confiner Virtual Camera has a post-processing pipeline consisting of several stages 
        // Check to see what stage of the camera's post-processing cinemachine is in 
        // If the Cinemachine VC is in the "Body" stage, VC's position in space can be set
        if (stage == CinemachineCore.Stage.Body)
        {
            // Retrieve the VC's final position
            Vector3 pos = state.FinalPosition; 
            // Call the Rounding method to round the position, and then create a new Vector with the result
            Vector3 pos2 = new Vector3(Round(pos.x), Round(pos.y), pos.z);
            // Set the VC's new position to the difference between the old position and the new rounded position 
            state.PositionCorrection += pos2 - pos;
        }
    }

    // Round the input value 
    float Round(float x)
    {
        return Mathf.Round(x * PixelsPerUnit) / PixelsPerUnit; 
    }
}
