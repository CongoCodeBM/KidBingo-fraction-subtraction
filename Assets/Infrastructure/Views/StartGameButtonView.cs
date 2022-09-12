using UnityEngine;

namespace BrilliantBingo.Code.Infrastructure.Views
{
    public class StartGameButtonView : MonoBehaviour
    {
        [SerializeField]
        private string _bingoGameSceneName = "BrilliantBingoScene";

        public void StartBingoGame()
        {
            Application.LoadLevel(_bingoGameSceneName);
        }
    }
}