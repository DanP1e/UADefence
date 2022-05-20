using UnityEngine;

namespace Effects
{
    public interface IUnitShaderAdapter : IShaderAdapter
    {
        Color HighlightColor { get; set; }
        float MeshScaleFactor { get; set; }
    }
}