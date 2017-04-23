using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreOcean : MonoBehaviour
{
	public Text Score;

	public float score;

	public DataSaving Saving;

	public SaveHighScore save;

	// Use this for initialization
	void Start()
	{
		Saving = new DataSaving();
		save = Saving.Load();
		score = 0;
	}

	// Update is called once per frame
	void Update()
	{
		score += Time.deltaTime;
		Score.text = string.Format("Score: {0}", Mathf.Round(score));
	}

	void OnDestroy()
	{
		if (score > save.OceanScore)
		{
			save.OceanScore = score;
		}
		Saving.Save(save);
		Debug.Log("Saved score ocean: " + save.OceanScore);
		Debug.Log("Saved score sky: " + save.SkyScore);
		Debug.Log("Saved score space: " + save.SpaceScore);
	}
}