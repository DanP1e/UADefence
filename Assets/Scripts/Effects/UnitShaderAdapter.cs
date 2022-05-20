using System;
using UnityEngine;

namespace Effects
{
    [RequireComponent(typeof(MeshRenderer))]
    public class UnitShaderAdapter : MonoBehaviour, IUnitShaderAdapter
    {
        public Color BaseColor 
        { 
            get => GetCurrentUnitMaterial().GetColor(BaseColorPropertyName); 
            set => GetCurrentUnitMaterial().SetColor(BaseColorPropertyName, value); 
        }
        public float MeshScaleFactor 
        {
            get => GetCurrentUnitMaterial().GetFloat(ScaleFactorPropertyName);
            set => GetCurrentUnitMaterial().SetFloat(ScaleFactorPropertyName, value);
        }
        public Color HighlightColor
        {
            get => GetCurrentUnitMaterial().GetColor(HighlightColorPropertyName);
            set => GetCurrentUnitMaterial().SetColor(HighlightColorPropertyName, value);
        }

        [SerializeField] private string ShaderFullName = "Shader Graphs/UnitShader";
        [SerializeField] private string BaseColorPropertyName = "Color_2291741ace314e6b803574ef38cc054f";
        [SerializeField] private string HighlightColorPropertyName = "Color_52bc822c8f5947c19aab71c8ae1df4ab";
        [SerializeField] private string ScaleFactorPropertyName = "Vector1_9874a6f4f8a243bc8f0d2f32314cddbe";

        private MeshRenderer _meshRenderer;
        private int? _materialId = null;

        private void Awake()
        {
            _materialId = GetCurrentUnitMaterialId();
        }
        private int GetCurrentUnitMaterialId() 
        {
            if(_meshRenderer == null)
                _meshRenderer = GetComponent<MeshRenderer>();

            int matId = 0;
            foreach (var material in _meshRenderer.materials)
            {
                if (material.shader.name == ShaderFullName)
                {
                    break;
                }
                matId++;
            }

            if (_meshRenderer.materials[matId] == null)
                throw new ArgumentNullException("MeshRenderer component does not " +
                    $"contains a material with a {ShaderFullName} shader name!");

            return matId;
        }
        private Material GetCurrentUnitMaterial()
        {
            if (_materialId == null)
                _materialId = GetCurrentUnitMaterialId();

            return _meshRenderer.materials[(int)_materialId];
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
                if (material.shader.name == ShaderFullName)
                {
                    unitMaterial = material;
                    break;
                }
                matId++;
            }

            if (unitMaterial == null)
                throw new ArgumentNullException("MeshRenderer component does not " +
                    $"contains a material with a {ShaderFullName} shader name!");

            int propertyCount = unitMaterial.shader.GetPropertyCount();

            for (int i = 0; i < propertyCount; i++)
                Debug.Log(unitMaterial.shader.GetPropertyName(i));
        }
#endif
    }
}
