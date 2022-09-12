using UnityEngine;

namespace BrilliantBingo.Code.Scripts
{
    public class BingoBallDisabler : MonoBehaviour
    {
        public void DisableBingoBall()
        {
            gameObject.SetActive(false);
        }
    }
}