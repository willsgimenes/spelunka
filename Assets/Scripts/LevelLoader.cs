using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public void LoadNextLevel(string screen_name)
    {
        StartCoroutine(LoadLevel(screen_name));
    }

    IEnumerator LoadLevel(string screen_name)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(screen_name);
    }
}
