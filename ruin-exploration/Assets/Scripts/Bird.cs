using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    GameObject walkModel;
    GameObject flyModel;
    
    [SerializeField]
    GameObject player;

    Vector3 anchorPos;
    float walkSpeed = 0.1f;
    float flySpeed = 0.5f;

    const int STILL = 0;
    const int WALK = 1;
    const int SCARED = 2;
    const int FLY = 3;
    const int LANDING = 4;
    int state;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        walkModel = transform.GetChild(0).gameObject;
        flyModel = transform.GetChild(1).gameObject;
        // ogPos = transform.position;
        state = STILL;
        flyModel.SetActive(false);

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // print(ogPos);
        float distance = Vector3.Distance(anchorPos, player.transform.position);
        // Debug.Log(distance);
        // if(distance > 20) {
        //     state = STILL;
        // }
        // else if(distance < 5) {
        //     state = FLY;
        // }
        // else {
        //     state = WALK;
        // }
        // rb.velocity = transform.forward * walkSpeed;

        switch(state) {
            case STILL:
                anchorPos = transform.position;
                if(distance < 20) {
                    state = WALK;
                }
                break;
            case WALK:
                rb.velocity = transform.forward * walkSpeed;

                anchorPos = transform.position;

                if(distance > 20) {
                    state = STILL;
                }
                if(distance < 5) {
                    state = SCARED;
                    flyModel.SetActive(true);
                    walkModel.SetActive(false);
                }
                break;
            case SCARED:
                break;
            case FLY:
                if(distance > 10) {
                    state = LANDING;
                }
                break;
            case LANDING:
                // if() {
                //     state = WALK;
                //     walkModel.SetActive(true);
                //     flyModel.SetActive(false);
                // }
                break;
        }
    }
}
