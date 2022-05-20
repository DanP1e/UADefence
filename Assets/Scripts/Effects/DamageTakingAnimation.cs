using InspectorAddons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{    
    public class DamageTakingAnimation : MonoBehaviour
    {
        private class MaterialInfo
        {
            public IUnitShaderAdapter Adapter;
            public float StartScale;
            public Color StartHighlightColor;

            public MaterialInfo(
                IUnitShaderAdapter adapter, 
                float startScale, 
                Color startHighlightColor)
            {
                Adapter = adapter;
                StartScale = startScale;
                StartHighlightColor = startHighlightColor;
            }
        }
        
        [SerializeField] private List<InterfaceComponent<IUnitShaderAdapter>> _unitShaderAdapter;
        [SerializeField] private Gradient _gradient;
        [SerializeField] private AnimationCurve _scaleCurve;

        private List<MaterialInfo> _materialsInfo;

        private void Start()
        {
            UpdateBaseValues();
        }

        private IEnumerator Animation() 
        {
            float startTime = Time.realtimeSinceStartup;
            float endTime = _scaleCurve.keys[_scaleCurve.length - 1].time;
            
            while (true)
            {
                float animationTime = Time.realtimeSinceStartup - startTime;
                if (animationTime > endTime)
                    break;

                float curveValue = _scaleCurve.Evaluate(animationTime);
                float gradientTime = animationTime / endTime;
                
                foreach (var item in _materialsInfo)
                {
                    item.Adapter.MeshScaleFactor = item.StartScale + curveValue;
                    item.Adapter.HighlightColor = _gradient.Evaluate(gradientTime);
                }
               
                yield return new WaitForEndOfFrame();       
            }

            foreach (var item in _materialsInfo)
            {
                item.Adapter.HighlightColor = item.StartHighlightColor;
                item.Adapter.MeshScaleFactor = item.StartScale;
            }

            yield return null;
        }

        public void UpdateBaseValues() 
        {
            _materialsInfo = new List<MaterialInfo>();
            foreach (var item in _unitShaderAdapter)
            {
                var adapter = item.Interface;
                _materialsInfo.Add(
                    new MaterialInfo(adapter,
                    adapter.MeshScaleFactor, 
                    adapter.HighlightColor));
            }
        }
        public void PlayAnimation() 
        {
            StopAllCoroutines();

            if(gameObject.activeInHierarchy)
                StartCoroutine(Animation());
        }
    }
}
