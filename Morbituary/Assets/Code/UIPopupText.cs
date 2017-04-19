using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopupText : MonoBehaviour {

    public Animator animator;
    private Text dmgText;

    void OnEnable()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        // Destroy popup text when anim ends
        Destroy(gameObject, clipInfo[0].clip.length);
        dmgText = animator.GetComponent<Text>();

    }

    public void SetText(string text)
    {
        Debug.Log("SetText");
        dmgText.text = text;
    }
}
