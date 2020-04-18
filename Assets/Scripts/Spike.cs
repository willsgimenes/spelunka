using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    
    private bool isCoRunning = false;
    
    void Start() {}

    private void Update() {}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player collided with the spike");

        if (other.CompareTag("Player"))
        {
            StartCoroutine(ExecuteAfterTimer(.1f, () =>
            {
                other.GetComponent<PlayerInit>().Hit();
            }));
        }
        
    }
    
    IEnumerator ExecuteAfterTimer(float time, Action task)
    {
        if (isCoRunning)
            yield break;

        isCoRunning = true;
        
        yield return new WaitForSeconds(time);

        task();

        isCoRunning = false;
    }

        
}