﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class newthirdperson : MonoBehaviour
{

    [SerializeField]
    private float _moveSpeed = 7f;
    [SerializeField]
    private float _gravity = 9.81f;
    [SerializeField]
    private float _jumpSpeed = 4f;
    [SerializeField]
    //private float _doubleJumpMultiplier = 0.7f;

    private CharacterController _controller;

    private float _directionY;


    public Animator _anim;
      
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Vector3 direction = new Vector3(-horizontalInput, 0, -verticalInput);
        transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        Vector3 direction = transform.forward * verticalInput + transform.right * horizontalInput;

       
        if(_controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _directionY = _jumpSpeed;

            }
        }

        if (_anim)
        {
            _anim.SetFloat("speed", direction.magnitude);
            
        }
        if(_directionY > 0.5f)
        {
            AudioManager.Instance.PlaySound(Sounds.Jump, transform.position);

        }


        _directionY -= _gravity * Time.deltaTime;

        direction.y = _directionY;

        _controller.Move(direction * _moveSpeed * Time.deltaTime);
        
        
    }
  
}
