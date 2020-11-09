using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPlacer : MonoBehaviour
{
    Camera cam;
    RaycastHit HitInfo;
    public Transform Cube;

    GameObject toggle;

    private void Awake()
    {
        cam = Camera.main;
        toggle = GameObject.Find("Toggle (1)");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out HitInfo, Mathf.Infinity))
            {
                if (HitInfo.collider.gameObject.tag == "Ground")
                {
                    ICommand command = new PlaceObjectCommand(HitInfo.point, Cube);
                    CommandInvoker.AddCommand(command);
                    FindObjectOfType<AudioManager>().Play("Place");
                    toggle.GetComponent<Toggle>().isOn = true;
                }
            }
        }
    }
}
