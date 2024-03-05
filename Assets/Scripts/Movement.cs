using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Movement : MonoBehaviour
{
    static public Movement instance;
    
    private float rotationX = 0f;

    private float rotationY = 0f;

    private float rotationZ = 0f;

    private float sensitivity = 20f;

    NewControls NewControls;

    private float playerSpeed = 10.0f;

    public Rigidbody rb;

    // Start is called before the first frame update

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        NewControls = new NewControls();

        NewControls.Enable();

        instance = this;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 moveVec = NewControls.PlayerMovement.Movement.ReadValue<Vector2>();

        GetComponent<Rigidbody>().transform.Translate(new Vector3(-moveVec.y, 0, 0) * playerSpeed * Time.deltaTime);

        rotationY += Input.GetAxis("Mouse X") * sensitivity;

        rotationX += Input.GetAxis("Mouse Y") * sensitivity;

        transform.localEulerAngles = new Vector3(0, rotationY, rotationX);

        rb.AddForce(moveVec);
    }
}
