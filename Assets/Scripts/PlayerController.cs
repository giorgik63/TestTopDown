using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    //private CharacterController _characterController;
    private Rigidbody2D _rb;
    private Vector3 _moveDir = Vector3.zero;

    public float speed = 5.0f;
    public float rotationSpeed = 240.0f;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        //_characterController = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get Input
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Limit to forward movement
        //if (v < 0)
        //    v = 0;

        transform.Rotate(0, 0, -h * rotationSpeed * Time.deltaTime);
        if(v != 0)
        {
            //gameObject.transform.position += Input.GetAxisRaw("Vertical") * Vector3.up * Time.deltaTime;
            //transform.TransformVector(Input.GetAxisRaw("Vertical") * Vector3.up * Time.deltaTime);
            transform.Translate(transform.up * (v * Time.deltaTime));
        }
        
        /*
        if(_characterController.isGrounded)
        {
            bool move = (v > 0) || (h != 0);

            _animator.SetBool("walk", move);

            _moveDir = Vector3.forward * v;
            _moveDir = transform.TransformDirection(_moveDir);
            _moveDir *= speed;
        }
        
        _characterController.Move(_moveDir * Time.deltaTime);
        */
    }
}
