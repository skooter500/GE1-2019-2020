using UnityEngine;
using UnityEditor;

public class Utilities
{
    public static Color RandomColor()
    {
        return Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
    }

}