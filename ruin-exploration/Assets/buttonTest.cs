using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonTest : MonoBehaviour
{
    public bool appear = true;
    [SerializeField] public GameObject gb;

    public void ChangeState() {
        if(appear) {
            gb.SetActive(false);
            appear = false;
        } else {
            gb.SetActive(true);
            appear = true;
        }
    }
}
