﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Created by Jacob Quirk, April 22, 2017
/// This class allows configuration of a speechbubble that shows text over time, in unity
/// </summary>
public class SpeechBubble : MonoBehaviour
{
	/// <summary>
	/// FISH
	/// </summary>
	public GameObject BubbleFollowsThis;

	/// <summary>
	/// Offset from what it is follow, unless you want it underneath
	/// </summary>
	public Vector3 PositionOffset;

	/// <summary>
	/// The actual Text
	/// </summary>
	public string TextInBubble;

	/// <summary>
	/// Set the text of the reference using TextInBubble
	/// </summary>
	public Text TextBubbleReference;

	/// <summary>
	/// How fast before the next character appears in the bubble
	/// </summary>
	public float SpeedOfText;

	/// <summary>
	/// How long until the entire bubble disappears or whatever
	/// </summary>
	public float Seconds;

	/// <summary>
	/// Change whats in the text box immediately
	/// </summary>
	/// <param name="text"></param>
	/// <param name="characterSpeed"></param>
	/// <param name="howLongTestStays"></param>
	public void ChangeTextBubble(string text, float characterSpeed, float howLongTestStays)
	{
		Seconds = howLongTestStays;
		SpeedOfText = characterSpeed;
		TextInBubble = text;
		TextBubbleReference.text = TextInBubble;
	}

	/// <summary>
	/// Launch this to make the bubble stay for a few seconds and say some text then disappear!
	/// </summary>
	/// <param name="seconds"></param>
	/// <param name="text"></param>
	/// <param name="speedOfText"></param>
	/// <returns></returns>
	IEnumerator SetTextFor(float seconds, string text, float speedOfText)
	{
		TextBubbleReference.text = "";
		Stopwatch timer = Stopwatch.StartNew();
		int characterCounter = 0;
		while(true)
		{
			if(characterCounter < text.Length - 1)
			{
				TextBubbleReference.text += text[characterCounter++];
				UnityEngine.Debug.Log(text[characterCounter]);
			}
			yield return new WaitForSeconds(speedOfText);
			if(timer.Elapsed.TotalSeconds > seconds)
			{
				break;
			}
		}
		TextBubbleReference.text = "";
	}

	/// <summary>
	/// Unity Start
	/// </summary>
	void Start ()
	{
		StartCoroutine(SetTextFor(Seconds, TextInBubble, Math.Abs(SpeedOfText)));
	}

	/// <summary>
	/// Unity Update
	/// </summary>
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.G))
		{
			StartCoroutine(SetTextFor(Seconds, TextInBubble, Math.Abs(SpeedOfText)));
		}
		transform.position = PositionOffset + BubbleFollowsThis.transform.position;
	}
}