using UnityEngine;

namespace Scripts.CameraControl
{
	[RequireComponent(typeof(Camera))]
	public class CameraMouseRotate : MonoBehaviour
	{
		[SerializeField] private float _sensitivity;
		
		private Vector3 _previousPosition;
		private Camera _camera;

		private void Start()
		{
			_previousPosition = Input.mousePosition;
			_camera = GetComponent<Camera>();
		}

		private void Update()
		{
			var delta = _previousPosition - Input.mousePosition;

			var rotation = new Vector3(delta.y, delta.x * -1, 0) * _sensitivity;
			
			if(Input.GetMouseButton(1))
				_camera.transform.eulerAngles += rotation;
			
			_previousPosition = Input.mousePosition;
		}
	}
}