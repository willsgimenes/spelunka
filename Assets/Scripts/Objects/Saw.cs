using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    private bool _isCoRunning;
    
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
        if (_isCoRunning)
            yield break;

        _isCoRunning = true;
        
        yield return new WaitForSeconds(time);

        task();

        _isCoRunning = false;
    }
}
