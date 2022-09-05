using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Geometry
{
    public static bool CheckAngle(Vector3 startRotation, Vector3 endRotation, float angle)
    {
        var y = startRotation.y < 180 ? startRotation.y + 360 : startRotation.y;
        var charY = endRotation.y < 180 ? endRotation.y + 360 : endRotation.y;

        if (charY + (angle / 2) >= y && y >= charY - (angle / 2))
        {
            return true;
        }
        return false;
    }
}
