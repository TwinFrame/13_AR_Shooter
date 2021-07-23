using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	[SerializeField] private Player _player;
	[SerializeField] private Spawner _spawner;
	[SerializeField] private Transform _containerBullets;
	[Header("UI")]
	[Header("Menu")]
	[SerializeField] private MenuViewer _playMenu;
	[SerializeField] private MenuViewer _pauseMenu;
	[Header("Button")]
	[SerializeField] private Button _menu;
	[SerializeField] private Button _continue;
	[SerializeField] private Button _restart;
	[SerializeField] private Button _quit;

	private bool _isPlay;

	public bool IsPlay => _isPlay;

	private void OnEnable()
	{
		_menu.onClick.AddListener(PauseGame);
		_continue.onClick.AddListener(ContinueGame);
		_restart.onClick.AddListener(RestartGame);
		_quit.onClick.AddListener(QuitGame);
	}

	private void OnDisable()
	{
		_menu.onClick.RemoveListener(PauseGame);
		_continue.onClick.RemoveListener(ContinueGame);
		_restart.onClick.RemoveListener(RestartGame);
		_quit.onClick.RemoveListener(QuitGame);
	}

	private void Start()
	{
		StartGame();
	}

	private void StartGame()
	{
		_isPlay = true;

		Time.timeScale = 1;

		_player.ResetScore();
		_spawner.ResetEnemy();

		_pauseMenu.Close();
		_playMenu.Open();
	}

	private void PauseGame()
	{
		_isPlay = false;

		Time.timeScale = 0;

		_playMenu.Close();
		_pauseMenu.Open();
	}

	private void ContinueGame()
	{
		_isPlay = true;

		Time.timeScale = 1;

		_pauseMenu.Close();
		_playMenu.Open();
	}

	private void RestartGame()
	{
		_isPlay = true;

		Time.timeScale = 1;

		_player.ResetScore();
		_spawner.ResetEnemy();
		ResetBullets();

		_pauseMenu.Close();
		_playMenu.Open();
	}

	private void QuitGame()
	{
		Application.Quit();
	}

	private void ResetBullets()
	{
		for (int i = 0; i < _containerBullets.childCount; i++)
		{
			Destroy(_containerBullets.GetChild(i).gameObject);
		}
		
	}
}
