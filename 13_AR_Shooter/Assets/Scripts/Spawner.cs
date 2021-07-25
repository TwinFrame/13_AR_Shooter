using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Spawner : MonoBehaviour
{
	[SerializeField] private Player _target;
	[SerializeField] private float _spawnRadius;
	[SerializeField] private float _secondsBetweenSpawn;
	[SerializeField] private Enemy[] _enemies;
	[SerializeField] private Transform _container;
	[Header("Audio Clip")]
	[SerializeField] private AudioClip _die;
	[SerializeField] private AudioClip _create;

	private AudioSource _audio;

	private WaitForSeconds _waitForSeconds;

	private void Start()
	{
		_waitForSeconds = new WaitForSeconds(_secondsBetweenSpawn);

		_audio = GetComponent<AudioSource>();

		StartCoroutine(SpawnRandomEnemy());
	}

	private IEnumerator SpawnRandomEnemy()
	{
		while (true)
		{
			Enemy enemy = Instantiate(_enemies[Random.Range(0, _enemies.Length)], GetRandomPointInSphere(_spawnRadius), Quaternion.identity, _container);

			Vector3 lookDirection = _target.transform.position - enemy.transform.position;

			enemy.transform.rotation = Quaternion.LookRotation(lookDirection);

			enemy.Dying += OnEmenyDying;

			yield return _waitForSeconds;
		}
	}

	private Vector3 GetRandomPointInSphere(float radius)
	{
		return Random.onUnitSphere * radius;
	}

	private void OnEmenyDying(Enemy enemy)
	{
		enemy.Dying -= OnEmenyDying;

		_target.AddScore();

		_audio.pitch = Random.Range(0.8f, 1.2f);
		_audio.PlayOneShot(_die);
	}

	public void ResetEnemy()
	{
		for (int i = 0; i < _container.childCount; i++)
		{
			 Destroy(_container.GetChild(i).gameObject);
		}
		
	}
}
