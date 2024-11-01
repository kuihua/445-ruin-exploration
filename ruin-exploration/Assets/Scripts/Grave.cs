using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    [SerializeField]
    List<GameObject> flowers;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // using collision
    void OnCollisionEnter(Collision collision) {
        GameObject other = collision.gameObject;
        if(other.CompareTag("Flower") && !flowers.Contains(other)) {
            flowers.Add(other);
        }
    }

    void OnCollisionExit(Collision collision) {
        GameObject other = collision.gameObject;
        if(other.CompareTag("Flower") && flowers.Contains(other)) {
            flowers.Remove(other);
        }
    }

    // using trigger
    // void OnTriggerEnter(Collider collider) {
    //     GameObject other = collider.gameObject;
    //     if(other.CompareTag("Flower") && !flowers.Contains(other)) {
    //         flowers.Add(other);
    //     }
    // }

    // void OnTriggerExit(Collider collider) {
    //     GameObject other = collider.gameObject;
    //     if(other.CompareTag("Flower") && flowers.Contains(other)) {
    //         flowers.Remove(other);
    //     }
    // }

    public bool hasFlower() {
        return flowers.Count > 0;
    }
}
