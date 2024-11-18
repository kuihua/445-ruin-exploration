using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    [SerializeField]
    Transform player;
    Rigidbody rb;
    float visDist = 10.0f;
    float attackDist = 3.0f;
    public float moveSpeed = 30;
    const int IDLE = 0;
    const int FOLLOW = 1;
    const int ATTACK = 2;
    int state;
    Color ogcolour;
    float changeDirTimer;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        state = IDLE;
        ogcolour = GetComponent<Renderer>().material.color;
        changeDirTimer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(CanAttackPlayer()) {
            state = ATTACK;
        }
        else if(CanSeePlayer()) {
            // Debug.Log("can see");
            state = FOLLOW;
        }
        else {
            state = IDLE;
        }

        switch(state) {
            case IDLE:
                // rb.velocity = new Vector3(0, 0, 0);
                rb.velocity = transform.forward * 2;
                changeDirTimer -= Time.deltaTime;
                if(changeDirTimer <= 0) {
                    ChangeDirection(100);
                }
                GetComponent<Renderer>().material.color = ogcolour;
                break;
            case FOLLOW:
                FollowPlayer();
                GetComponent<Renderer>().material.color = ogcolour;
                break;
            case ATTACK:
                GetComponent<Renderer>().material.color = Color.red;
                break;
        }
    }

    public bool CanSeePlayer()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        if (direction.magnitude < visDist)
        {
            return true;
        }
        return false;
    }

    public bool CanAttackPlayer()
    {
        Vector3 direction = player.position - transform.position;
        if (direction.magnitude < attackDist)
        {
            return true;
        }
        return false;
    }

    public void FollowPlayer() {
        Vector3 direction = player.position - transform.position;
        rb.velocity = direction.normalized * moveSpeed * Time.deltaTime;
    }

    void ChangeDirection(int halfRange) {
        if(Random.Range(0, 1.0f) < 0.5f) {
            float angleInc = Random.Range(-halfRange, halfRange);
            transform.Rotate(0, angleInc, 0);
            Debug.Log("change direction");
        }
        changeDirTimer = 1;
    }
}
