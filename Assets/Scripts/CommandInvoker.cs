using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CommandInvoker : MonoBehaviour
{
    static Queue<ICommand> commandBuff;

    static List<ICommand> commandHis;
    static int counter;

    GameObject toggle1;
    GameObject toggle2;

    public Text blockCounter;
    static int cubeCounter = 4;

    private void Awake()
    {
        commandBuff = new Queue<ICommand>();
        commandHis = new List<ICommand>();
        toggle1 = GameObject.Find("Toggle (2)");
        toggle2 = GameObject.Find("Toggle (3)");
    }

    public static void AddCommand(ICommand command)
    {
        if (counter < commandHis.Count)
        {
            while (commandHis.Count > counter)
            {
                commandHis.RemoveAt(counter);
            }
        }
        if (commandHis.Count < 4)
        {
            commandBuff.Enqueue(command);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (commandBuff.Count > 0)
        {
            ICommand x = commandBuff.Dequeue();
            x.Execute();

            commandHis.Add(x);
            counter++;
            cubeCounter--;
            Debug.Log("Length: " + commandHis.Count);
            blockCounter.text = "x" + (cubeCounter).ToString();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (counter > 0)
            {
                counter--;
                cubeCounter++;
                commandHis[counter].Undo();
                blockCounter.text = "x" + (cubeCounter).ToString();
                if (toggle1 != null)
                {
                    toggle1.GetComponent<Toggle>().isOn = true;
                }
                else
                {
                    return;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (counter < commandHis.Count)
            {
                commandHis[counter].Execute();
                counter++;
                cubeCounter--;
                blockCounter.text = "x" + (cubeCounter).ToString();
                if (toggle2 != null)
                {
                    toggle2.GetComponent<Toggle>().isOn = true;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
