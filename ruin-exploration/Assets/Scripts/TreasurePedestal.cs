using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasurePedestal : MonoBehaviour
{
    [SerializeField]
    ObjectPedestal[] objectPedestals;
    [SerializeField]
    Transform target;
    
    bool revealTreasure;
    float moveSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        revealTreasure = false;
        Debug.Log(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(!revealTreasure && allPedestalsActivated()) {
            Debug.Log("all objects correct");
            revealTreasure = true;
        }
        else if(revealTreasure) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
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
