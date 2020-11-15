using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    public GameObject panel;
    public Text finalTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
            finalTime.text = GetComponent<DllManager>().LoadTotalTime().ToString() + " Seconds";
        }
    }
}
