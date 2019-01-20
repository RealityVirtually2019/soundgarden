using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;


public class Control6DOF : MonoBehaviour {

    #region Private Variables
    private MLInputController _controller;
    #endregion

    #region Public Variables
    public bool AllowEnter = true;
    public bool AllowExit = true;

    // todo: could put the four color GO's here and then I don't need to look for them
    public GameObject Yellow;
    public GameObject Blue;
    public GameObject Pink;
    public GameObject Green;
    #endregion

    #region Unity Methods
    void resetMoodVisuals()
    {
        Blue.SetActive(false);
        Yellow.SetActive(false);
        Pink.SetActive(false);
        Green.SetActive(false);
    }
    void Start()
    {
        //Start receiving input by the Control
        MLInput.Start();
        _controller = MLInput.GetController(MLInput.Hand.Left);
        resetMoodVisuals();
    }
    void OnDestroy()
    {
        //Stop receiving input by the Control
        MLInput.Stop();
    }
    void Update()
    {
        //Attach the Beam GameObject to the Control
        transform.position = _controller.Position;
        transform.rotation = _controller.Orientation;

        // todo: in addition to the code from the tutorial, need to add the collision

        // psuedo code
        // on collision enter
        // other.find component<audioplayer>.play()
        // other.find soundanimation.play


    }

    private void OnTriggerEnter(Collider other)
    {
        if (AllowEnter)
        {
            Debug.Log("entered the " + other.name);
            if (other.GetComponent<AudioSource>())
            {
                try
                {
                    other.GetComponent<AudioSource>().Play();
                }
                catch
                {
                    Debug.Log("no audio clip");
                }
            }
            string myname = other.name;
            if (myname.Contains("Yellow"))
            {
                resetMoodVisuals();
                Yellow.SetActive(true);
                // todo: loop through children and start animations!
            }
            else if (myname.Contains("Blue"))
            {
                resetMoodVisuals();
                Blue.SetActive(true);
            }
            else if (myname.Contains("Pink"))
            {
                resetMoodVisuals();
                Pink.SetActive(true);
            }
            else if (myname.Contains("Green"))
            {
                resetMoodVisuals();
                Green.SetActive(true);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (AllowExit)
        {
            Debug.Log("exited");
        }
    }

    #endregion

}
