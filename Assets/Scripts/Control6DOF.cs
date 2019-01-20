using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control6DOF : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // todo: paste the code from the Unity 6DOF tutorial here!
		
	}
	
	// Update is called once per frame
	void Update () {

        // todo: in addition to the code from the tutorial, need to add the collision

        // psuedo code
        // on collision enter
        // other.find component<audioplayer>.play()
        // other.find soundanimation.play
		
	}

    void Load_a_Scene()
    {
        SceneManager.LoadSceneAsync(1);
        // that should do it!
    }
}
