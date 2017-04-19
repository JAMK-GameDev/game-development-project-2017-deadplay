using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopupTextController : MonoBehaviour {

    private static UIPopupText popupText;

    public static void Initialize()
    {
        popupText = Resources.Load<UIPopupText>("/Prefabs/Popup Text Parent");
    }

    public static void CreatePopupText(string text, Transform location)
    {

    }


}
