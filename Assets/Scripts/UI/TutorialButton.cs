using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class TutorialButton : UIButton
    {
        private const string Tutorial = nameof(Tutorial);

        protected override void Start()
        {
            base.Start();
            _button.onClick.AddListener(LoadTutorialScene);
        }

        private void LoadTutorialScene()
        {
            SceneManager.LoadScene(Tutorial);
        }
    }
}
