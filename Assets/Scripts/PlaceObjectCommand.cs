using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectCommand : ICommand
{
    Vector3 position;
    Transform transform;

    public PlaceObjectCommand(Vector3 position, Transform transform)
    {
        this.position = position;
        this.transform = transform;
    }

    public void Execute()
    {
        CubePlacer.placeShape(position, transform);
    }

    public void Undo()
    {
        CubePlacer.removeObject(position);
    }
}
