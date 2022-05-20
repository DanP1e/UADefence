using System;

namespace PathSystem
{
    public interface IPathDriver : IDriver
    {
        /// <summary>
        /// Notifies when the object no longer uses this path.
        /// </summary>
        event Action<IPathDriver, IPathPresenter> LeftPath;
        float GetPathProgress();
        void SetPathPresenter(IPathPresenter pathPresenter);
    }
}