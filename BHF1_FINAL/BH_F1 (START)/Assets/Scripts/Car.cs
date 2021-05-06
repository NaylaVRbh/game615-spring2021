using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    //Rigidbodies
    [SerializeField] private Rigidbody srb;

    //Numeric Variables
    private float forwardAccel = 8f;
    private float reverseAccel = 4f;
    private float maxSpeed = 50f;
    private float turnStrength = 180;
    private float speedInput;
    private float turnInput;
    private float gravityForce = 10f;
    private float groundRayLength = 0.5f;
    private float dragGround = 3f;
    private float maxwheelTurn = 25f;
    public static float carCurrentSpeed = 0f;

    //Transform Variables

    [SerializeField] private Transform groundRayPoint;
    [SerializeField] private Transform leftFromWheel;
    [SerializeField] private Transform rightFromWheel;

    [SerializeField] private bool isGrounded;

    [SerializeField] private LayerMask Ground;

    [SerializeField] private AudioSource CarSound;
    

    void Start()
    {
        srb.gameObject.transform.parent = null;
    }


    void Update()
    {
        speedInput = 0f;

        CarSound.pitch = carCurrentSpeed;

        if (Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000;
           // CarSound.pitch += 0.1f;
            carCurrentSpeed = (srb.velocity.magnitude * 3.6f) / 50;
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel * 1000;
            //CarSound.pitch -= 0.1f;
        }

        if (CarSound.pitch < 1)
            CarSound.pitch = 1.1f;
        else
            CarSound.pitch = carCurrentSpeed;

        turnInput = Input.GetAxis("Horizontal");

        if(isGrounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
        }

        leftFromWheel.localRotation = Quaternion.Euler(leftFromWheel.localRotation.eulerAngles.x, (turnInput * maxwheelTurn) - 180, leftFromWheel.localRotation.eulerAngles.z );
        rightFromWheel.localRotation = Quaternion.Euler(rightFromWheel.localRotation.eulerAngles.x, turnInput * maxwheelTurn, rightFromWheel.localRotation.eulerAngles.z);
        transform.position = srb.transform.position;
    }

    private void FixedUpdate()
    {
        //srb.AddForce(transform.forward * forwardAccel * 1000f);

        isGrounded = false;


        RaycastHit hit;

        if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, Ground))
        {
            isGrounded = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if(isGrounded)
        {
            srb.drag = dragGround;

            if (Mathf.Abs(speedInput) > 0)
            {
                srb.AddForce(transform.forward * speedInput);
            }
        }
        else
        {
            srb.drag = 0.1f;
            srb.AddForce(Vector3.up * -gravityForce * 100);
        }

        
    }
}
