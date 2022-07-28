using Interaction;
using UnityEngine;

namespace ViewControllers
{
    public interface IIcon : ISelectable
    {
        Vector2 TemporarySizeModifierInPercents { get; set; }

        void SetSprite(Sprite image);

        void SetBaseSize(Vector2 size);

        void Destroy();
    }
}
