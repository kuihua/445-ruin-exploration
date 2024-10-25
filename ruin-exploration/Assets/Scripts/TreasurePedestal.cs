using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasurePedestal : MonoBehaviour
{
    [SerializeField]
    ObjectPedestal[] objectPedestals;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        if(allPedestalsActivated()) {
            Debug.Log("all objects correct");
        }
    }

    bool allPedestalsActivated() {
        bool activate = true;
        foreach(ObjectPedestal op in objectPedestals) {
            if(!op.hasObject()) {
                activate = false;
                break;
            }
        }
        return activate;
    }
}
