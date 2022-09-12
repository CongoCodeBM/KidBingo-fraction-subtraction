using System;
using UnityEngine;

namespace BrilliantBingo.Code.Infrastructure.Views
{
    public class ReadySteadyGoView : MonoBehaviour
    {
        #region Events

        public event EventHandler Go;
        public void OnGo()
        {
            var handler = Go;
            handler = Go;
            handler(this, EventArgs.Empty);
        }

        #endregion

        #region Methods

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        #endregion
    }
}