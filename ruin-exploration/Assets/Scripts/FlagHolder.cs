using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagHolder : MonoBehaviour
{
    [SerializeField] GameObject[] levers;
    bool revealFlag;

    [SerializeField] Transform lidTarget;
    // Start is called before the first frame update
    void Start()
    {
        revealFlag = false;
    }

    void Update()
    {
        if(!revealFlag && allLeversOn()) {
            Debug.Log("all levers are on");
            revealFlag = true;
            // GetComponent<Renderer>().material.color = Color.red;
        } 
        else if (revealFlag) {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lidTarget.rotation, 100 * Time.deltaTime);
        }
        // else {
        //     GetComponent<Renderer>().material.color = Color.blue;
        // }
    }

    bool allLeversOn() {
        // bool correctLevers = true;

        for (int i = 0; i < levers.Length; i++) {
            if (!levers[i].GetComponent<leverScript>().IsOn()) {
                // correctLevers = false;
                return false;
            } 
        }
        return true;
    }
}
