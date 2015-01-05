﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTime : MonoBehaviour {
	public static int TIME_IN_SECONDS;

	public int  minutes;
	public int 	seconds;

	private int CountSeconds;
	private int CountMinutes;

	private int restSeconds;

	public static string TEXT_TIME;

	public Text text;
	public Text pointText;
	

	// Update is called once per frame
	public void FixedUpdate () {

		var guitime = Time.time;

		restSeconds= CountSeconds + (int)guitime;

		TIME_IN_SECONDS = restSeconds;
		seconds = restSeconds % 60;
		minutes = restSeconds / 60;

		TEXT_TIME = string.Format("{0:00}:{1:00}", minutes, seconds);

		text.text = TEXT_TIME;

		pointText.text = GameManger.TOTAL_POINTS_COUNT.ToString();
	}


}
