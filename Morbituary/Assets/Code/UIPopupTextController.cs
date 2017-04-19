using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopupTextController : MonoBehaviour {

    private static UIPopupText popupText;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        popupText = Resources.Load<UIPopupText>("../Prefabs/Popup Text Parent");
    }

    public static void CreatePopupText(string text, Transform location)
    {
        Debug.Log("popupText is: " + popupText);
        UIPopupText instance = Instantiate(popupText);
        // Accsess properties
        instance.transform.SetParent(canvas.transform, false);
        instance.SetText(text);
    }


}
