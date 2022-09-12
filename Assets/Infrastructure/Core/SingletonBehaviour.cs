using UnityEngine;

namespace BrilliantBingo.Code.Infrastructure.Core
{
    public abstract class SingletonBehaviour<T> : MonoBehaviour
        where T : Component
    {
        #region Fields

        private static T _instance;

        #endregion

        #region Methods

        public virtual void Awake()
        {
            _instance = FindObjectOfType<T>();
        }

        #endregion

        #region Properties

        public static T Default
        {
            get { return _instance; }
        }

        #endregion
    }
}