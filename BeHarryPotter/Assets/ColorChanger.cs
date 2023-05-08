using System;
using UnityEngine;

//public class ColorChanger : MonoBehaviour
//{
//    /// <param name="trans"></param>
//    /// <param name="color"></param>
//    private void SetColor(Transform trans, Color color)
//    {
//        trans.GetComponent<Renderer>().material.color = color;
//    }

//    /// <summary>
//    /// Updates the color of GameObject with the names specified in the input values.
//    /// </summary>
//    /// <param name="values"></param>
//    public void UpdateColor(string[] values)
//    {
//        var colorString = values[0];
//        var shapeString = values[1];    //¿¡·¯³²

//        if (!ColorUtility.TryParseHtmlString(colorString, out var color)) return;
//        if (string.IsNullOrEmpty(shapeString)) return;

//        foreach (Transform child in transform) // iterate through all children of the gameObject.
//        {
//            if (child.name.IndexOf(shapeString, StringComparison.OrdinalIgnoreCase) != -1) // if the name exists
//            {
//                SetColor(child, color);
//                return;
//            }
//        }
//    }
//}

public class ColorChanger : MonoBehaviour
{
    private void SetColor(Transform transform, Color color)
    {
        transform.GetComponent<Renderer>().material.color = color;
    }

    public void UpdateColor(string[] values)
    {
        var colorString = values[0];
        var shapeString = values[1];
        Console.WriteLine(colorString);
        Console.WriteLine(shapeString);

        if (ColorUtility.TryParseHtmlString(colorString, out var color))
        {
            if (!string.IsNullOrEmpty(shapeString))
            {
                var shape = transform.Find(shapeString);
                if (shape) SetColor(shape, color);
            }
            else
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    SetColor(transform.GetChild(i), color);
                }
            }
        }
    }
}