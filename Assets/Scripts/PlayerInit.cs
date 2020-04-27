using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        transform.position = GameObject.FindWithTag("RespawnPoint").transform.position;
    }

    public void Exit()
    {
        transform.position = GameObject.FindWithTag("RespawnPoint").transform.position;
    }
}
