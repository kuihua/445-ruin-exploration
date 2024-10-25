using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPedestal : MonoBehaviour
{
    [SerializeField]
    string objectTag;

    bool correctObject;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag(objectTag)) {
            correctObject = true;
            // Debug.Log(objectTag);
        }
    }

    void OnCollisionExit(Collision collision) {
        if(collision.gameObject.CompareTag(objectTag)) {
            correctObject = false;
            // Debug.Log("off");
        }
    }

    public bool hasObject() {
        return correctObject;
    }
}
