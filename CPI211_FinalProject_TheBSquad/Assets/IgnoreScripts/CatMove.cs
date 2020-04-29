using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    public float moveSpeed;

    void Start()
    {
        moveSpeed = 1f;
    }

    void Update()
    {
        //transform.Translate(1f * Time.deltaTime, 0f, 0f);
        //transform.Translate(Input.GetAxis("Horizontal")* Time.deltaTime, 0f, 0f);
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
