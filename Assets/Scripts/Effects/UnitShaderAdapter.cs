using System;
using UnityEngine;

namespace Effects
{
    [RequireComponent(typeof(MeshRenderer))]
    public class UnitShaderAdapter : ShaderAdapter, IUnitShaderAdapter
    {
        public float MeshScaleFactor 
        {
            get => GetCurrentUnitMaterial().GetFloat(_scaleFactorPropertyName);
            set => GetCurrentUnitMaterial().SetFloat(_scaleFactorPropertyName, value);
        }
        public Color HighlightColor
        {
            get => GetCurrentUnitMaterial().GetColor(_highlightColorPropertyName);
            set => GetCurrentUnitMaterial().SetColor(_highlightColorPropertyName, value);
        }

        [SerializeField] private string _highlightColorPropertyName = "HighlightColor";
        [SerializeField] private string _scaleFactorPropertyName = "ScaleFactor";
    }
}
