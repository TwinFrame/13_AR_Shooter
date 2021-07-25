using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Shooter : MonoBehaviour
{
	[SerializeField] private Transform _shootPoint;
	[SerializeField] private Bullet _bullet;
	[SerializeField] private Transform _container;
	[Header("Audio Clip")]
	[SerializeField] private AudioClip _shoot;

	private InputsGames _input;

	private AudioSource _audio;

	private void Awake()
	{
		_audio = GetComponent<AudioSource>();

		_input = new InputsGames();

		_input.Player.Shoot.performed += ctx => OnShoot();
	}
	private void OnEnable()
	{
		_input.Enable();
	}

	private void OnDisable()
	{
		_input.Disable();
	}

	private void OnShoot()
	{
		Instantiate(_bullet, _shootPoint.transform.position, _shootPoint.rotation, _container);

		_audio.pitch = Random.Range(0.95f, 1f);
		_audio.PlayOneShot(_shoot);
	}
}
