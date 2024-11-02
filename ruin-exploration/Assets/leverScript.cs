using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class leverScript : MonoBehaviour
{
    // array of levers that will be changed if its flicked
    [SerializeField] GameObject[] affectedLevers;
    // Animator myAnimator;
    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        // myAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
Debug.Log(isOn + " " + transform.rotation.x);
        }
        
        // set animator parameter based on if its flicked on/off
        if (transform.rotation.x <= 0) {
            isOn = true;
        } else {
            isOn = false;
        }
    }

    public void changeLeverStates() {
        // Debug.Log(myAnimator.name);
        // Debug.Log(myAnimator.GetCurrentAnimatorStateInfo(0).IsName("leverOn"));
        // Debug.Log(myAnimator.GetBool(0));
        
        //  for each lever that will get affected, play animation
        if (affectedLevers != null) {
            for (int i = 0; i < affectedLevers.Length; i++)
            {
                affectedLevers[i].GetComponent<Animator>().SetTrigger("LeverOn");
                
            }
        }
        // Debug.Log(isOn + " " + transform.rotation.x);

        // Debug.Log(myAnimator.GetBool(0));

        // Debug.Log(myAnimator.GetCurrentAnimatorStateInfo(0).IsName("leverOn"));

        // if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("leverOn")) {
        //     Debug.Log("lever on");
        //         // isOn = true;
        //     } else if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("leverOff")){
        //         Debug.Log("lever off");
        //         // isOn = false;
        // }
    }

    public bool IsOn(){
        // the animation rotates the x axis between +- 45 degrees when its switched on/off
        // so if x is positive, its on
        // if (transform.rotation.x >= 0) {
        //     // Debug.Log("lever on");
        //     isOn = true;
        // } else {
        //     // Debug.Log("lever off");
        //     isOn = false;
        // }

        // checks for animation state of lever
        // if(myAnimator.GetCurrentAnimatorStateInfo(0).IsName("leverOn")) {
        //     isOn = true;
        // } else {
        //     isOn = false;
        // }


        return isOn;
    }
}
