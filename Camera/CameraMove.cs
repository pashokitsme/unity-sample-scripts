using UnityEngine;

namespace Scripts.CameraControl
{
	[RequireComponent(typeof(Camera))]
	public class CameraMove : MonoBehaviour
	{
		[SerializeField] private float _speed;

		private Transform _cameraTransform;

		private void Start()
		{
			_cameraTransform = GetComponent<Camera>().transform;
		}

		private void Update()
		{
			var verticalAxis = Input.GetAxis("Vertical");
			var horizontalAxis = Input.GetAxis("Horizontal");
			var heightAxis = Input.GetAxis("Camera Height");

			var moveDirection = _cameraTransform.forward * verticalAxis + _cameraTransform.right * horizontalAxis;
			moveDirection.y += heightAxis;
			
			Move(moveDirection);
		}

		private void Move(Vector3 direction)
		{
			var position = transform.position;
			position = Vector3.LerpUnclamped(position, position + direction, _speed);
			transform.position = position;
		}
	}
}