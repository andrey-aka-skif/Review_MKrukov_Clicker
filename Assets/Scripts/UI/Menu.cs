using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Общий скрипт для меню
/// </summary>
public class Menu : MonoBehaviour
{
    [SerializeField] 
    private RectTransform _topMenu;

    [SerializeField] 
    private RectTransform _pauseMenu;

    [SerializeField] 
    private RectTransform _deadMenu;


    [SerializeField] 
    private Text _mainMenuScore;

    [SerializeField] 
    private Text _mainMenuHealth;


    [SerializeField] 
    private Text _pauseMenuScore;

    [SerializeField] 
    private Text _pauseMenuBestScore;


    [SerializeField] 
    private Text _deadMenuScore;

    [SerializeField] 
    private Text _deadMenuBestScore;

    /// <summary>
    /// Пауза
    /// </summary>
    public void OnPause()
    {
        HideTopMenu();
        ShowPauseMenu();
        HideDeadMenu();
    }

    /// <summary>
    /// Рестарт
    /// </summary>
    public void OnRestart()
    {
        ShowTopMenu();
        HidePauseMenu();
        HideDeadMenu();
    }

    /// <summary>
    /// Продолжить
    /// </summary>
    public void OnResume()
    {
        ShowTopMenu();
        HidePauseMenu();
        HideDeadMenu();
    }

    /// <summary>
    /// Изменение здоровья
    /// </summary>
    /// <param name="health"></param>
    public void OnChangeHealth(int health)
    {
        _mainMenuHealth.text = $"{health}";
    }

    /// <summary>
    /// Изменение счета
    /// </summary>
    /// <param name="score"></param>
    public void OnChangeScore(int score)
    {
        _mainMenuScore.text = $"{score}";
        _pauseMenuScore.text = $"Результат: {score}";
        _deadMenuScore.text = $"Результат: {score}";
    }

    /// <summary>
    /// Изменение лучшего счета
    /// </summary>
    /// <param name="bestScore"></param>
    public void OnChangeBestScore(int bestScore)
    {
        _pauseMenuBestScore.text = $"Лучший результат: {bestScore}";
        _deadMenuBestScore.text = $"Лучший результат: {bestScore}";
    }

    /// <summary>
    /// Смерть
    /// </summary>
    public void OnDead()
    {
        HideTopMenu();
        HidePauseMenu();
        ShowDeadMenu();
    }

    /// <summary>
    /// Показать игровое меню (HUD + кнопка паузы)
    /// </summary>
    private void ShowTopMenu() => _topMenu.gameObject.SetActive(true);

    /// <summary>
    /// Скрыть основное меню (HUD + кнопка паузы)
    /// </summary>
    private void HideTopMenu() => _topMenu.gameObject.SetActive(false);


    /// <summary>
    /// Показать меню паузы
    /// </summary>
    private void ShowPauseMenu() => _pauseMenu.gameObject.SetActive(true);

    /// <summary>
    /// Скрыть меню паузы
    /// </summary>
    private void HidePauseMenu() => _pauseMenu.gameObject.SetActive(false);


    /// <summary>
    /// Показать меню смерти
    /// </summary>
    private void ShowDeadMenu() => _deadMenu.gameObject.SetActive(true);

    /// <summary>
    /// Скрыть меню смерти
    /// </summary>
    private void HideDeadMenu() => _deadMenu.gameObject.SetActive(false);
}
