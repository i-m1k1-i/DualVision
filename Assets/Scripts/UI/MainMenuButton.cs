using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class MainMenuButton : UIButton
    {
        private const string MainMenu = nameof(MainMenu);

        protected override void Start()
        {
            base.Start();

            _button.onClick.AddListener(LoadMainMenu);
        }

        private void LoadMainMenu()
        {
            SceneManager.LoadScene(MainMenu);
        }
    }
}