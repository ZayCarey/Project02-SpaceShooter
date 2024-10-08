using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextSceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Loading Next Scene: " + nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
