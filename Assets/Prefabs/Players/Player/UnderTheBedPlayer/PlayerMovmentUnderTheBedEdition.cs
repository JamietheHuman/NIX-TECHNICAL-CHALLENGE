using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentUnderTheBedEdition : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float gravity = -9.81f;
    
    public float groundDistance = 0.4f;
    public LayerMask groundmask;
    public float JumpHeight = 3f;
  
    Vector3 velocity;
    bool isGrounded;
    CharacterController pc;
    
    // Update is called once per frame
    void Start()
    {
        pc = GetComponent<CharacterController>();
       
    }
    void Update()
    {
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        
        
       


        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
       
    }
   
}
