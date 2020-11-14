using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class DllManager : MonoBehaviour
{

    const string DLL_NAME = "TimerDLL";

    [DllImport(DLL_NAME)]
    private static extern void ResetLogger();

    [DllImport(DLL_NAME)]
    private static extern void SaveCheckpointTime(float RTBC);

    [DllImport(DLL_NAME)]
    private static extern float GetTotalTime();

    [DllImport(DLL_NAME)]
    private static extern float GetCheckpointTime(int index);

    [DllImport(DLL_NAME)]
    private static extern int GetNumCheckpoint();

    float lastTime = 0.0f;

    public void SaveTime(float checkpointTime)
    {
        SaveCheckpointTime(checkpointTime);
    }

    public float LoadTime(int index)
    {
        if (index >= GetNumCheckpoint())
        {
            return -1.0f;
        }
        else
        {
            return GetCheckpointTime(index);
        }
    }

    public float LoadTotalTime()
    {
        return GetTotalTime();
    }

    public void ResetLoggerFunction()
    {
        ResetLogger();
    }

    GameObject toggle4;
    GameObject toggle5;

    static int counter;
    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
        toggle4 = GameObject.Find("Toggle (4)");
        toggle5 = GameObject.Find("Toggle (5)");
    }

    public Text timerText;
    public GameObject respawnFloor;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            counter++;
            float currentTime = Time.time;
            float checkpointTime = currentTime - lastTime;
            lastTime = currentTime;

            SaveTime(checkpointTime);
            Debug.Log(LoadTime(0));
            timerText.text = "Current Time: " + LoadTotalTime().ToString();
            Destroy(respawnFloor);
            if (toggle4 != null)
            {
                toggle4.GetComponent<Toggle>().isOn = true;

            }
            else
            {
                return;
            }
            if (counter >= 2 && toggle5 != null)
            {
                toggle5.GetComponent<Toggle>().isOn = true;
            }
            else
            {
                return;
            }
        }
    }

    private void OnDestroy()
    {
        ResetLoggerFunction();
    }
}
