using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasurePedestal : MonoBehaviour
{
    [SerializeField]
    ObjectPedestal[] objectPedestals;
    [SerializeField]
    Transform target;

    [SerializeField] private AudioClip revealTreasureSoundClip;

    [SerializeField] GameObject chalice;
    
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
            chalice.SetActive(true);
            SoundFXManager.instance.PlaySoundFXClip(revealTreasureSoundClip, transform, 1f);
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
