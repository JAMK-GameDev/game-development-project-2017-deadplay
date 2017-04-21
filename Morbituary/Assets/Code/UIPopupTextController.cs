using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UIPopupTextController : MonoBehaviour {

    private static UIPopupText popupText;
    private static GameObject canvas;

    public static void Initialize()
    {

		canvas = GameObject.Find("Canvas");
		if (!popupText)
			popupText = Resources.Load<UIPopupText>("Prefabs/PopUpTextContainer");
    }

    public static void CreatePopupText(string text, Transform location)
    {
        UIPopupText instance = Instantiate(popupText);
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
		instance.SetText(text);
    }


}
