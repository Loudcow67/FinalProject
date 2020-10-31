using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    Camera cam;
    RaycastHit HitInfo;
    public Transform Cube;

    private void Awake()
    {
        cam = Camera.main;
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
                }
            }
        }
    }
}
