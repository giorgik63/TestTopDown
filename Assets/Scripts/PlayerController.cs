using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;  // radianti
    public Animator animator;

    private float f_h;
    private bool b_move;

    // Update is called once per frame
    private void Update()
    {
        // Get Input
        f_h = Input.GetAxisRaw("Horizontal");  // rotazione orario - antiorario
        b_move = Input.GetKey(KeyCode.W);      // movimento in avanti

        transform.Rotate(-Vector3.forward, f_h * rotationSpeed, 0);
       
        if (b_move)
        {
            transform.Translate(0f, speed * Time.deltaTime, 0f);  //, Space.Self);
        }
    }

    private void FixedUpdate()
    {
        //--------------- Animazioni ---------------
        animator.SetBool("walk", b_move);  // Idle -> Walk o Walk -> Idle
    }
}
