using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullHolder : MonoBehaviour
{
    [SerializeField]
    Grave[] graves;

    bool revealSkull;

    // Start is called before the first frame update
    void Start()
    {
        revealSkull = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!revealSkull && allGravesCorrect()) {
            Debug.Log("all graves correct");
            revealSkull = true;
            GetComponent<Renderer>().material.color = Color.red;
        }
    }

    bool allGravesCorrect() {
        bool correctGraves = true;
        foreach(Grave grave in graves) {
            if(!grave.hasFlower()) {
                correctGraves = false;
                break;
            }
        }
        return correctGraves;
    }
}
