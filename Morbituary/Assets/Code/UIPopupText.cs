using System.Collections;
using System.Collections.Generic;
using Assets.Code.Actors;
using UnityEngine;
using UnityEngine.UI;

public class UIPopupText : MonoBehaviour {


    public Animator animator;
    private Text dmgText;

    void Start()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        // Destroy popup text when anim ends
        Destroy(gameObject, clipInfo[0].clip.length);
        dmgText = animator.GetComponent<Text>();

    }

    public void SetText(string text)
    {
		// Since damage / weapons have frequency, show cooldown
		// TODO: Should disable attack animation when cooldown
		if (text != "0")
		{
			animator.GetComponent<Text>().text = text;
		}
		if (text == "0")
		{
			animator.GetComponent<Text>().text = "cooldown";
		}
    }
}
