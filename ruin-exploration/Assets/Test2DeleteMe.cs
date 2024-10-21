using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2DeleteMe : MonoBehaviour
{

    [SerializeField]
    TestDeleteMe referenceToScript;

    GameObject randomObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomObject.transform.rotation = referenceToScript.getRotation();
    }
}
