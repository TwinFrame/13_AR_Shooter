using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]

public class Score : MonoBehaviour
{
	[SerializeField] private Player _player;

	private TMP_Text _text;

	private void OnEnable()
	{
		_player.ScoreAdded += OnScoreAdded;
	}

	private void OnDisable()
	{
		_player.ScoreAdded -= OnScoreAdded;
	}

	private void Awake()
	{
		_text = GetComponent<TMP_Text>();
	}

	private void OnScoreAdded(int score)
	{
		_text.text = score.ToString();
	}
}
