using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private RectTransform _topMenu;
    [SerializeField] private RectTransform _pauseMenu;
    [SerializeField] private RectTransform _deadMenu;

    [SerializeField] private Text _mainMenuScore;
    [SerializeField] private Text _mainMenuHealth;

    [SerializeField] private Text _pauseMenuScore;
    [SerializeField] private Text _pauseMenuBestScore;

    [SerializeField] private Text _deadMenuScore;
    [SerializeField] private Text _deadMenuBestScore;

    private PMsDI _compositionRoot;

    public void Init(PMsDI compositionRoot)
    {
        _compositionRoot = compositionRoot;
    }

    public void Pause()
    {
        HideTopMenu();
        ShowPauseMenu();
        HideDeadMenu();

        Time.timeScale = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        ShowTopMenu();
        HidePauseMenu();
        HideDeadMenu();

        Time.timeScale = 1;
    }

    public void Resume()
    {
        ShowTopMenu();
        HidePauseMenu();
        HideDeadMenu();

        Time.timeScale = 1;
    }

    public void OnChangeHealth(int health)
    {
        _mainMenuHealth.text = $"{health}";
    }

    public void OnChangeScore(int score)
    {
        _mainMenuScore.text = $"{score}";
        _pauseMenuScore.text = $"Результат: {score}";
        _deadMenuScore.text = $"Результат: {score}";
    }

    public void OnChangeBestScore(int bestScore)
    {
        _pauseMenuBestScore.text = $"Лучший результат: {bestScore}";
        _deadMenuBestScore.text = $"Лучший результат: {bestScore}";
    }

    public void OnDead()
    {
        HideTopMenu();
        HidePauseMenu();
        ShowDeadMenu();

        Time.timeScale = 0;
    }

    private void ShowTopMenu() => _topMenu.gameObject.SetActive(true);
    private void HideTopMenu() => _topMenu.gameObject.SetActive(false);

    private void ShowPauseMenu() => _pauseMenu.gameObject.SetActive(true);
    private void HidePauseMenu() => _pauseMenu.gameObject.SetActive(false);

    private void ShowDeadMenu() => _deadMenu.gameObject.SetActive(true);
    private void HideDeadMenu() => _deadMenu.gameObject.SetActive(false);
}