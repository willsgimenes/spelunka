using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string screen_name;
    public LevelLoader _LevelLoader;
    
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() {}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<CharacterController2D>().mGrounded)
            {
                Exit(screen_name);
            }
        }
        
    }
    
    private void Exit(string screen_name)
    {
        _LevelLoader.LoadNextLevel(screen_name);
    }
}
