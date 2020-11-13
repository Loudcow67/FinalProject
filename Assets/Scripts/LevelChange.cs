using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChange : MonoBehaviour
{
    public int index;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CommandInvoker.counter = 0;
            CommandInvoker.cubeCounter = 4;
            CubePlacer.clearList();
            SceneManager.LoadScene(index);
        }
    }
}