/*
 * Script: GestureDetection.cs
 * Author: King
 * Site: http://codeofcodehall.co.uk
 * Date: May 6th 2018
 * Lumin SDK: 0.13.0
 * Desc: Setup the gestures we want to track.
 *       When the gesture is detected update 
 *       the position of the hand.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
public class GestureDetection : MonoBehaviour
{
    //game object representing the finger position
    public Transform finger;
    public AudioSource aud;
    // Use this for initialization
    void Start()
    {
        MLHands.Start();
        if (!MLHands.IsStarted)
        {
            Debug.Log("MLHands didn't start...bail.");
            return;
        }
        // set gestures to track
        setGesturesToTrack();
    }

    // Update is called once per frame
    void Update()
    {
        //if MLHands is running start tracking gestures
        if (MLHands.IsStarted)
            gestureTracker();
    }

    //set the gestures to track
    void setGesturesToTrack()
    {
        List<MLHandKeyPose> gestures = new List<MLHandKeyPose>();
        //add the gestures we want to track
        gestures.Add(MLHandKeyPose.Finger);
        gestures.Add(MLHandKeyPose.L);
        gestures.Add(MLHandKeyPose.Fist);
        gestures.Add(MLHandKeyPose.C);
        //add the gestures to the gesture manager
        MLHands.KeyPoseManager.EnableKeyPoses(gestures.ToArray(), true, true);
    }

    //track the gestures
    void gestureTracker()
    {
        // let's test out playing a sound as a function of the hand gesture!

        if (MLHands.Left.KeyPose == MLHandKeyPose.C || MLHands.Right.KeyPose == MLHandKeyPose.C)
        {
            Debug.Log("C-pose!");
            aud.Play();

            return;
        }


        if (MLHands.Left.KeyPose == MLHandKeyPose.Fist || MLHands.Right.KeyPose == MLHandKeyPose.Fist)
        {
            Debug.Log("Fist");
            return;
        }
        //check for the l or finger gesture
        //and that we've got some keypoints
        if ((MLHands.Left.KeyPose == MLHandKeyPose.Finger ||
               MLHands.Left.KeyPose == MLHandKeyPose.L))
        {
            positionHand(MLHands.Left);
        }
        //check for the l or finger gesture
        //and that we've got some keypoints
        if ((MLHands.Right.KeyPose == MLHandKeyPose.Finger ||
                MLHands.Right.KeyPose == MLHandKeyPose.L))
        {
            positionHand(MLHands.Right);
        }
    }

    //position the game object to the tracked finger
    void positionHand(MLHand hand)
    {
        //in Lumin SDK 0.13 only the center hand position
        //updates so we need to use that until it's fixed
        finger.position = hand.Index.Tip.Position;
        //finger.position = hand.Center;
        //set the finger position to the tip of the finger
        //finger.position = hand[1].position;
        Debug.Log("Hand position Z " + hand.Center + " / " + finger.position + " finger position" );
    }

    private void OnDestroy()
    {
        MLHands.Stop();
    }
}
