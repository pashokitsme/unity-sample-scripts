using UnityEngine;

namespace Scripts.Other
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(MeshRenderer))]
	[DisallowMultipleComponent]
	public class MaterialAutoTiling : MonoBehaviour
	{
		[SerializeField] private bool _destroyOnStart = true;

		private Material _material;
		private readonly int _mainTex = Shader.PropertyToID("_MainTex");

		private void Awake()
		{
			_material = GetComponent<MeshRenderer>().sharedMaterial;
		}

		private void Update()
		{
			if(Application.isPlaying && _destroyOnStart)
				Destroy(this);

			if(_material.GetTextureScale(_mainTex) != (Vector2)transform.localScale)
				_material.SetTextureScale(_mainTex, transform.localScale);
		}
	}
}