using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
	[SerializeField] private ParticleSystem _deathEffect;

	private Vector3 _currentScale;
	private float _speed = 20f;
	private Coroutine _scaleOut;

	public event UnityAction<Enemy> Dying;

	public void Die()
	{
		Dying?.Invoke(this);

		if (_scaleOut != null)
			StopCoroutine(_scaleOut);

		_scaleOut = StartCoroutine(ScaleOut());

		Instantiate(_deathEffect, transform.position, Quaternion.identity);
	}

	private IEnumerator ScaleOut()
	{
		_currentScale = transform.localScale;

		while (_currentScale.x > 0.1f)
		{
			_currentScale -= new Vector3(_currentScale.x, _currentScale.y, _currentScale.z) * _speed * Time.deltaTime;

			transform.localScale = _currentScale;

			yield return null;
		}

		Destroy(gameObject);
	}
}
