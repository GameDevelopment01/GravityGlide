using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrustInput;
    [SerializeField] InputAction turnInput;
    Rigidbody rb;
    [SerializeField] float thrustForce = 10f;
    [SerializeField] float rotateForce = 10f;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable() 
    {
        thrustInput.Enable();    
        turnInput.Enable();
    }

    void FixedUpdate()
    {
        Thrust();

        Turn();
    }

    private void Turn()
    {
        float rotationValue = turnInput.ReadValue<float>();
        if(rotationValue > 0)
        {
            ApplyRotation(-rotateForce);
        }
        else if(rotationValue < 0)
        {
            ApplyRotation(rotateForce);
        }
    }

    private void ApplyRotation(float rotationDirection)
    {
        transform.Rotate(Vector3.forward * rotationDirection * Time.fixedDeltaTime);
    }

    private void Thrust()
    {
        if (thrustInput.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.fixedDeltaTime, ForceMode.Force);
        }
    }
}
