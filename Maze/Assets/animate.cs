﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeholder : MonoBehaviour
{

    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
       // dir = GetComponent<Sprite Renderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey (KeyCode.RightArrow)){
            anim.SetInteger("New Int", 1);
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) <= 0.1){
       // anim.SetInteger("New Int", 0);
       }
        }}
