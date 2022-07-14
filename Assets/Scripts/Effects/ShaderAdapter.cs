using System;
using UnityEngine;

namespace Effects
{
    [RequireComponent(typeof(MeshRenderer))]
    public class ShaderAdapter : MonoBehaviour, IShaderAdapter
    {
        [SerializeField] private string _shaderFullName = "Shader Graphs/";
        [SerializeField] private string _baseColorPropertyName = "BaseColor";

        private MeshRenderer _meshRenderer;
        private int? _materialId = null;

        public Color BaseColor
        {
            get => GetCurrentUnitMaterial().GetColor(_baseColorPropertyName);
            set => GetCurrentUnitMaterial().SetColor(_baseColorPropertyName, value);
        }

        private void Awake()
        {
            _materialId = GetCurrentUnitMaterialId();
        }

        public Material GetCurrentUnitMaterial()
        {
            if (_materialId == null)
                _materialId = GetCurrentUnitMaterialId();

            return _meshRenderer.materials[(int)_materialId];
        }
        public int GetCurrentUnitMaterialId()
        {
            if (_meshRenderer == null)
                _meshRenderer = GetComponent<MeshRenderer>();

            int matId = 0;
            foreach (var material in _meshRenderer.materials)
            {
                if (material.shader.name == _shaderFullName)
                {
                    break;
                }
                matId++;
            }

            if (_meshRenderer.materials[matId] == null)
                throw new ArgumentNullException("MeshRenderer component does not " +
                    $"contains a material with a {_shaderFullName} shader name!");

            return matId;
        }
#if UNITY_EDITOR
        [ContextMenu("Print Shader Info")]
        public void PrintShaderInfo()
        {
            if (_meshRenderer == null)
                _meshRenderer = GetComponent<MeshRenderer>();

            Material unitMaterial = null;
            int matId = 0;
            foreach (var material in _meshRenderer.sharedMaterials)
            {
                if (material.shader.name == _shaderFullName)
                {
                    unitMaterial = material;
                    break;
                }
                matId++;
            }

            if (unitMaterial == null)
                throw new ArgumentNullException("MeshRenderer component does not " +
                    $"contains a material with a {_shaderFullName} shader name!");

            int propertyCount = unitMaterial.shader.GetPropertyCount();

            for (int i = 0; i < propertyCount; i++)
                Debug.Log(unitMaterial.shader.GetPropertyName(i));
        }
#endif
    }
}