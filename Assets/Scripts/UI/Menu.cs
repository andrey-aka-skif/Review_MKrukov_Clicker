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

    public void OnPause()
    {
        HideTopMenu();
        ShowPauseMenu();
        HideDeadMenu();
    }

    public void OnRestart()
    {
        ShowTopMenu();
        HidePauseMenu();
        HideDeadMenu();
    }

    public void OnResume()
    {
        ShowTopMenu();
        HidePauseMenu();
        HideDeadMenu();
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
    }

    private void ShowTopMenu() => _topMenu.gameObject.SetActive(true);
    private void HideTopMenu() => _topMenu.gameObject.SetActive(false);

    private void ShowPauseMenu() => _pauseMenu.gameObject.SetActive(true);
    private void HidePauseMenu() => _pauseMenu.gameObject.SetActive(false);

    private void ShowDeadMenu() => _deadMenu.gameObject.SetActive(true);
    private void HideDeadMenu() => _deadMenu.gameObject.SetActive(false);
}