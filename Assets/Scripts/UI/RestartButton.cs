using Assets.Scripts.UI;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : UIButton
{
    protected override void Start()
    {
        base.Start();
        _button.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Statistics.Instance.Reset();
        _button.onClick.RemoveAllListeners();

        SceneManager.LoadScene(currentScene);
    }
}
