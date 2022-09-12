using System;
using System.Globalization;
using BrilliantBingo.Code.Infrastructure.Models;
using UnityEngine;
using UnityEngine.UI;

namespace BrilliantBingo.Code.Infrastructure.Views
{
    public class BingoBallView : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        private Text _letterText;

        [SerializeField]
        private Text _numberText;

        private Image _ballImage;

        private RectTransform _rectTransform;

        private int _currentBallPosition;

        private Animator _animator;

        private AudioSource _audioSource;

        private const int MaxBallsCount = 6;

        private const string MoveToNextPositionAnimationParameterName 
            = "CurrentBallPosition";

        #endregion

        #region Methods

        public void Awake()
        {
            _ballImage = GetComponent<Image>();
            _rectTransform = GetComponent<RectTransform>();
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
            _currentBallPosition = 0;
        }

        public void PlayBallArivedSound()
        {
            _audioSource.Play();
        }

        public void ApplyBingoBallModel(BingoBall ball)
        {
            if (ball == null)
            {
                throw new ArgumentNullException("ball");
            }
            _letterText.text = BingoLetterCaster.BingoLetterToString(ball.Letter);
            _numberText.text = ball.Number.ToString(CultureInfo.InvariantCulture);
        }

        public void ApplyBallSprite(Sprite sprite)
        {
            if (sprite == null)
            {
                throw new ArgumentNullException("sprite");
            }
            _ballImage.sprite = sprite;
        }

        public void Appear(Vector3 appearancePosition)
        {
            _currentBallPosition = 0;
            _rectTransform.anchoredPosition = appearancePosition;
            gameObject.SetActive(true);
            _animator.SetInteger(MoveToNextPositionAnimationParameterName, _currentBallPosition);
        }

        public void Disappear()
        {
            _animator.SetInteger(MoveToNextPositionAnimationParameterName, MaxBallsCount);
        }

        public void MoveToNextPosition()
        {
            _currentBallPosition++;
            _animator.SetInteger(MoveToNextPositionAnimationParameterName, _currentBallPosition);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        #endregion

        #region Properties

        public bool IsDisabled
        {
            get { return !gameObject.activeInHierarchy; }
        }

        #endregion
    }
}