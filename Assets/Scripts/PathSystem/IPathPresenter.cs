using UnityEngine;

namespace PathSystem
{
    public interface IPathPresenter
    {
        /// <summary>
        /// Returns the progress of the path traveled based on the walker position.
        /// </summary>
        float GetProgress(Vector3 walkerPosition);
        Vector3 GetPathPoint(Vector3 pathWalkerPosition);
    }
}