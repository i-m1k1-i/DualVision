using Assets.Scripts.UI;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : UIButton
{
    private Button _button;

    protected override void Start()
    {
        base.Start();
        _button = GetComponent<Button>();
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
