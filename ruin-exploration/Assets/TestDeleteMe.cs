using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDeleteMe : MonoBehaviour
{

    Quaternion rotationInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationInfo = gameObject.transform.localRotation;
    
    }

    public Quaternion getRotation()
    {
        return rotationInfo;
    }
}
