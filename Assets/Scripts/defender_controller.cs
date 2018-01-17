using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class defender_controller : MonoBehaviour {

	public float moveSpeed;
	public float turnSpeed;
	private Vector2 moveDirection;
	private Vector2 destination;

	void Start()
	{
	}

	void Update () {

		Vector2 currentPosition = transform.position;

		if (Input.GetMouseButton(0))
		{
			Vector2 moveTowards = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			moveDirection = moveTowards - currentPosition;
			moveDirection.Normalize();
			destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}

		Vector2 target = moveDirection + currentPosition;
		transform.position = Vector3.Lerp (currentPosition, target, moveSpeed * Time.deltaTime);

		float targetAngle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Slerp (transform.rotation, 
			Quaternion.Euler (0, 0, targetAngle), 
			turnSpeed * Time.deltaTime);
			}
	}
