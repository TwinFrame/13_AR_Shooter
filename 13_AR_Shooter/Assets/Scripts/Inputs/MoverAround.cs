using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAround : MonoBehaviour
{
	[SerializeField] private float _rotateSpeed;

	private InputsGames _input;

	private Vector2 _rotate;
	private Vector2 _rotation;
	private float _scaledRotateSpeed;

	private void Awake()
	{
		_input = new InputsGames();
		_input.Enable();
		//_input.Camera.Rotation.performed += ctx => OnRotation();
	}

	/*private void OnEnable()
	{
		_input.Enable();
	}

	private void OnDisable()
	{
		_input.Disable();
	}*/

	private void Update()
	{
		_rotate = _input.Camera.Rotation.ReadValue<Vector2>();

		Rotation(_rotate);
	}

	private void Rotation(Vector2 rotate)
	{
		if (rotate.sqrMagnitude < 0.1f)
			return;

		_scaledRotateSpeed = _rotateSpeed * Time.deltaTime;

		_rotation.y += rotate.x * _scaledRotateSpeed;
		_rotation.x = Mathf.Clamp(_rotation.x - rotate.y * _scaledRotateSpeed, -90, 90);

		transform.localEulerAngles = _rotation;
	}
}
