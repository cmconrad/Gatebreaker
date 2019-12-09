using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public int index;
    public string levelName;

    void OnTriggerEnter2D(Collider2D door)
    {
        if (door.CompareTag("Player"))
        {
            //Load level with build index
            SceneManager.LoadScene(index);

            //Load level with scene name
            //SceneManager.LoadScene(levelName);


        }
    }
}
