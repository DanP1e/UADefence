using UnityEngine;

namespace ViewControllers
{
    public interface IIconFactory
    {
        public IIcon CreateNewIcon(Sprite image);
    }
}
