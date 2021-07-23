using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField] private Transform _shootPoint;
	[SerializeField] private Bullet _bullet;
	[SerializeField] private Transform _container;

	private void Update()
	{

		if (Input.touchCount > 0)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began)
			{
				Instantiate(_bullet, _shootPoint.transform.position, Quaternion.identity, _container);
			}
		}
		else if (Input.GetMouseButtonDown(0))
		{
			Instantiate(_bullet, _shootPoint.transform.position, Quaternion.identity, _container);
		}
	}
}
