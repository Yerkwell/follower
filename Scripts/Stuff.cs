using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Types
{
    public static Color getColor(int type)
    {
        switch (type)
        {
            case 0:
                return new Color32(147, 0, 190, 255);
            case 1:
                return new Color32(247, 0, 45, 255);
            case 2:
                return new Color32(45, 0, 247, 255);
            case 3:
                return new Color32(247, 247, 0, 255);
            case 4:
                return new Color32(45, 247, 0, 255);
            default:
                return Color.white;
        }
    }

    public static int random()
    {
        return (int)(Random.value * 5);
    }
}
