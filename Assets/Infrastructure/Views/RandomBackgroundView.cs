using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BrilliantBingo.Code.Infrastructure.Views
{
    public class RandomBackgroundView : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        private List<Sprite> _backgrounds;

        #endregion

        #region Methods

        public void Awake()
        {
            var image = GetComponent<Image>();
            if (image == null) return;
            var s = GetRandomSprite();
            if (s == null) return;
            image.sprite = s;
        }

        private Sprite GetRandomSprite()
        {
            if (_backgrounds == null || (_backgrounds.Count <= 0)) return null;
            return _backgrounds[Random.Range(0, _backgrounds.Count)];
        }

        #endregion
    }
}