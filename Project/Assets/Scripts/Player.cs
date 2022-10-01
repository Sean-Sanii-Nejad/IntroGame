using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    
    private Rigidbody rigidbodyComponent;
    private bool _jumpKeyWasPressed;
    private float _horizontalInput;
    
    

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpKeyWasPressed = true;
        }
        _horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(_horizontalInput*2, rigidbodyComponent.velocity.y, rigidbodyComponent.velocity.z);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }
        
        if (_jumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            _jumpKeyWasPressed = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
        }
    }
}
