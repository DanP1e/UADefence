using InspectorAddons;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ViewControllers
{
    public class ShopIconFactory : MonoBehaviour, IIconFactory
    {
        [SerializeField] private InterfaceComponent<IIcon> _iconPrefab;
        [SerializeField] private HorizontalOrVerticalLayoutGroup _iconsContainer;
        [SerializeField] private Vector2 _iconBaseSize;

        private DiContainer _sceneContainer;

        [Inject]
        public void Construct(
            [Inject(Id = "scene")]
            DiContainer sceneContainer)
        {
            _sceneContainer = sceneContainer;
        }

        public IIcon CreateNewIcon(Sprite image)
        {
            GameObject obj = _sceneContainer.InstantiatePrefab(_iconPrefab.Object);
            obj.transform.SetParent(_iconsContainer.transform);
            IIcon icon = (IIcon)obj.GetComponent(typeof(IIcon));
            icon.SetBaseSize(_iconBaseSize);
            icon.SetSprite(image);       
            return icon;
        }
    }
}
