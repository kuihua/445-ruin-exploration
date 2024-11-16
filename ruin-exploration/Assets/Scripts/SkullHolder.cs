using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullHolder : MonoBehaviour
{
    [SerializeField]
    Grave[] correctGraves;
    [SerializeField]
    Grave[] wrongGraves;

    // bool revealSkull;

    const int ASLEEP = 0;
    const int AWAKE = 1;
    const int OPEN = 2;
    const int ANGRY = 3;
    int state;

    Color ogColour;

    // Start is called before the first frame update
    void Start()
    {
        // revealSkull = false;
        state = ASLEEP;

        ogColour = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        // if(!revealSkull && allGravesCorrect()) {
        //     Debug.Log("all graves correct");
        //     revealSkull = true;
        //     GetComponent<Renderer>().material.color = Color.red;
        // }
        if(GravesWithFlower(correctGraves) == 0 && GravesWithFlower(wrongGraves) == 0) {
            state = ASLEEP;
        }
        else if(GravesWithFlower(correctGraves) == correctGraves.Length && GravesWithFlower(wrongGraves) == 0) {
            state = OPEN;
        }
        else if(GravesWithFlower(correctGraves) == 0 && GravesWithFlower(wrongGraves) == correctGraves.Length) {
            state = ANGRY;
        }
        else {
            state = AWAKE;
        }

        switch(state) {
            case ASLEEP:
                GetComponent<Renderer>().material.color = ogColour;
                break;
            case AWAKE:
                GetComponent<Renderer>().material.color = Color.blue;
                break;
            case OPEN:
                GetComponent<Renderer>().material.color = Color.black;
                break;
            case ANGRY:
                GetComponent<Renderer>().material.color = Color.red;
                break;
        }
    }

    int GravesWithFlower(Grave[] graveArray) {
        int graves = 0;
        foreach(Grave grave in graveArray) {
            if(grave.hasFlower()) {
                graves += 1;
            }
        }
        return graves;
    }

    bool allGravesCorrect() {
        bool correct = true;
        foreach(Grave grave in correctGraves) {
            if(!grave.hasFlower()) {
                correct = false;
                break;
            }
        }
        return correct;
    }
}
