using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UIPopupTextController : MonoBehaviour {

    private static UIPopupText popupText;
    private static GameObject canvas;

    public static void Initialize()
    {

        canvas = GameObject.Find("UICanvas");
        popupText = Resources.Load<UIPopupText>("Prefabs/PopupTextParent");
    }

    public static void CreatePopupText(string text, Transform location)
    {
        // TODO: Now working atm, link to tutorial followed found here: https://www.youtube.com/watch?v=fbUOG7f3jq8
        UIPopupText instance = Instantiate(popupText);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x + Random.Range(-0.5f, .5f), location.position.y + Random.Range(-0.5f, .5f)));
        // Accsess properties
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText(text);
    }


}
