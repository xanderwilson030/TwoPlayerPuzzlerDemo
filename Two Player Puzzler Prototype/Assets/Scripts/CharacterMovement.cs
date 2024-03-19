using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed;

    [SerializeField] string horizontalAxisName;
    [SerializeField] string verticalAxisName;

    private float moveFB;
    private float moveLR; 

    private CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        moveFB = Input.GetAxis(verticalAxisName) * speed;
        moveLR = Input.GetAxis(horizontalAxisName) * speed;

        Vector3 movement = new Vector3(moveLR, 0, moveFB).normalized * speed;

        movement = transform.rotation * movement;
        cc.Move(movement * Time.deltaTime);
    }

}
