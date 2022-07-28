using UnityEngine;

namespace Weapon
{
    public interface ITowerPlacer
    {
        void PlaceTower(ITower towerPrefab, Vector3 placePosition);
    }
}