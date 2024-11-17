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
    float takeOffSpeed = 5;
    float flySpeed = 2;

    const int STILL = 0;
    const int WALK = 1;
    const int SCARED = 2;
    const int FLY = 3;
    const int LANDING = 4;
    int state;

    Rigidbody rb;
    float changeDirTimer;
    float yTarget;

    // Start is called before the first frame update
    void Start()
    {
        walkModel = transform.GetChild(0).gameObject;
        flyModel = transform.GetChild(1).gameObject;
        // ogPos = transform.position;
        state = STILL;
        // state = WALK;
        flyModel.SetActive(false);

        rb = GetComponent<Rigidbody>();
        changeDirTimer = 3;
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
        Vector3 flyDirection;
        switch(state) {
            case STILL:
                rb.velocity = new Vector3(0, 0, 0);
                anchorPos = transform.position;
                if(distance < 15) {
                    state = WALK;
                    // Debug.Log("walk");
                }
                break;
            case WALK:
                rb.velocity = transform.forward * walkSpeed;
                anchorPos = transform.position;

                changeDirTimer -= Time.deltaTime;
                if(changeDirTimer <= 0) {
                    ChangeDirection(20);
                }

                if(distance > 15) {
                    state = STILL;
                    // Debug.Log("still");
                }
                else if(distance < 5) {
                    state = SCARED;
                    yTarget = Random.Range(15, 20);
                    flyModel.SetActive(true);
                    walkModel.SetActive(false);
                    // Debug.Log("scared");
                }
                break;
            case SCARED:
                // Vector3 flyDirection = transform.forward + new Vector3(0, 3, 0);
                flyDirection = transform.forward + transform.up * 3;
                rb.velocity = flyDirection.normalized * takeOffSpeed;

                changeDirTimer -= Time.deltaTime;
                if(changeDirTimer <= 0) {
                    ChangeDirection(20);
                }

                if(transform.position.y >= yTarget) {
                    state = FLY;
                    // Debug.Log("fly");
                }
                break;
            case FLY:
                rb.velocity = transform.forward * flySpeed;

                changeDirTimer -= Time.deltaTime;
                if(changeDirTimer <= 0) {
                    ChangeDirection(40);
                }

                if(distance > 10) {
                    state = LANDING;
                    // Debug.Log("landing");
                }
                break;
            case LANDING:
                transform.LookAt(new Vector3(anchorPos.x, transform.position.y, anchorPos.z));

                flyDirection = anchorPos - transform.position;
                if(flyDirection.magnitude < takeOffSpeed * Time.deltaTime) {
                    rb.velocity = new Vector3(0, 0, 0);
                    transform.position = anchorPos;
                    // Debug.Log("landed");
                }
                else {
                    rb.velocity = flyDirection.normalized * takeOffSpeed;
                }
                // transform.LookAt(anchorPos);
                // Debug.Log(transform.rotation);
                
                if(transform.position.y == anchorPos.y) {
                    state = WALK;
                    walkModel.SetActive(true);
                    flyModel.SetActive(false);
                    // Debug.Log("walk");
                }
                break;
        }
    }

    void ChangeDirection(int halfRange) {
        // Debug.Log("called");
        if(Random.Range(0, 1.0f) < 0.5f) {
            float angleInc = Random.Range(-halfRange, halfRange);
            transform.Rotate(0, angleInc, 0);
            // Debug.Log(angleInc);
        }
        changeDirTimer = 1;
    }
}
