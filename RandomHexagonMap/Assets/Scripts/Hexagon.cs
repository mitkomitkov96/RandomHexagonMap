using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon
{

    private readonly int col, row;
    private static readonly float radius = 1;
    private static readonly float sqrt3 = Mathf.Sqrt(3);

    public Hexagon(int col, int row)
    {
        this.col = col;
        this.row = row;
    }

    public Vector3 GetPosition()
    {
        return new Vector3(
            sqrt3 * radius * ((float)col + (row % 2 == 1 ? radius/2f : 0))
            , 0,
            row * radius * 1.5f
            );
    }

}
