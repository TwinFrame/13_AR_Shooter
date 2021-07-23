using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
	private void OnTriggerExit(Collider other)
	{
		if (other.TryGetComponent(out Bullet bullet))
		{
			Destroy(bullet.gameObject);
		}
	}
}
