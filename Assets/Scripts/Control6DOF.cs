using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;


public class Control6DOF : MonoBehaviour {

    #region Private Variables
    private MLInputController _controller;
    #endregion

    #region Unity Methods
    void Start()
    {
        //Start receiving input by the Control
        MLInput.Start();
        _controller = MLInput.GetController(MLInput.Hand.Left);
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
    #endregion

}
