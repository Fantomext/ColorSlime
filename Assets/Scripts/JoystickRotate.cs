using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickRotate : MonoBehaviour
{
	[SerializeField] private Transform _player;
	[SerializeField] private Joystick _joystick;
	[SerializeField] private GameObject _Object;
	private Vector2 _GameobjectRotation;
	private float _GameobjectRotation2;
	private float _GameobjectRotation3;

	private bool _facingRight = true;

	void Update()
	{
		//Gets the input from the jostick
		_GameobjectRotation = new Vector2(_joystick.Horizontal, _joystick.Vertical);

		_GameobjectRotation3 = _GameobjectRotation.x;

		if (_facingRight)
		{
			//Rotates the object if the player is facing right
			_GameobjectRotation2 = _GameobjectRotation.x + _GameobjectRotation.y * 90;
			_Object.transform.rotation = Quaternion.Euler(0f, 0f, _GameobjectRotation2);
		}
		else
		{
			//Rotates the object if the player is facing left
			_GameobjectRotation2 = _GameobjectRotation.x + _GameobjectRotation.y * -90;
			_Object.transform.rotation = Quaternion.Euler(0f, 180f, -_GameobjectRotation2);
		}
		if (_GameobjectRotation3 < 0 && _facingRight)
		{
			// Executes the void: Flip()
			Flip();
			FlipRotatePlayer();
		}
		else if (_GameobjectRotation3 > 0 && !_facingRight)
		{
			// Executes the void: Flip()
			Flip();
			FlipRotatePlayer();
		}
	}

	private void FlipRotatePlayer()
	{
		Vector3 currentRotate = _player.localEulerAngles;
		currentRotate.y += 180;
		_player.localEulerAngles = currentRotate;

	}
	private void Flip()
	{
		// Flips the player.
		_facingRight = !_facingRight;

		transform.Rotate(0, 180, 0);
	}
}
