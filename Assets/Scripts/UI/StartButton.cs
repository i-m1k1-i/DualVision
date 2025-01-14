using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class StartButton : UIButton
    {
        private const string GameScene = "Game";

        protected override void Start()
        {
            base.Start();
            _button.onClick.AddListener(LoadGame);
        }

        private void LoadGame()
        {
            SceneManager.LoadScene(GameScene);
        }
    }
}