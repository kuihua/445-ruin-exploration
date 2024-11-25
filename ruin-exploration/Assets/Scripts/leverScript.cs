using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class leverScript : MonoBehaviour
{
    // array of levers that will be changed if its flicked
    [SerializeField] GameObject[] affectedLevers;
    [SerializeField] private AudioClip leverSoundClip;
    private bool isOn;

    // Start is called before the first frame update
    // void Start()
    // {
    //     // myAnimator = gameObject.GetComponent<Animator>();
    // }

    // Update is called once per frame
    void Update()
    { 
        // Debug.Log(isOn + " " + transform.localRotation.eulerAngles.x);
        
        // set animator parameter based on if its flicked on/off
        // if (transform.localRotation.eulerAngles.x == 40) {
        //     isOn = true;
        // } else {
        //     isOn = false;
        // }
    }

    public void changeLeverStates() {
        
        //  for each lever that will get affected, play animation
        if (affectedLevers != null) {
            for (int i = 0; i < affectedLevers.Length; i++)
            {
                affectedLevers[i].GetComponent<Animator>().SetTrigger("LeverOn");
                affectedLevers[i].GetComponent<leverScript>().setIsOn();
                SoundFXManager.instance.PlaySoundFXClip(leverSoundClip, transform, 1f);
                // Debug.Log(isOn + " " + transform.localRotation.eulerAngles.x);
                // if (transform.localRotation.eulerAngles.x == 40) {
                //     isOn = true;
                // } else {
                //     isOn = false;
                // }
                // Debug.Log(isOn + " " + transform.localRotation.eulerAngles.x);
            }
        }
    }

    // function to set bool isOn, setting/checking in update does not work
    public void setIsOn() {
        if (transform.localRotation.eulerAngles.x == 40) {
            isOn = true;
            Debug.Log(isOn + " " + transform.localRotation.eulerAngles.x);
        } else if (transform.localRotation.eulerAngles.x == 320) {
            isOn = false;
            Debug.Log(isOn + " " + transform.localRotation.eulerAngles.x);
        }
    }

    public bool IsOn(){
        return isOn;
    }
}
