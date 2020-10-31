using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    static Queue<ICommand> commandBuff;

    static List<ICommand> commandHis;
    static int counter;

    private void Awake()
    {
        commandBuff = new Queue<ICommand>();
        commandHis = new List<ICommand>();
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

        commandBuff.Enqueue(command);
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
            Debug.Log("Length: " + commandHis.Count);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (counter > 0)
                {
                    counter--;
                    commandHis[counter].Undo();
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (counter < commandHis.Count)
                {
                    commandHis[counter].Execute();
                    counter++;
                }
            }
        }
    }
}
