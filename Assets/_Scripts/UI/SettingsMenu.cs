using UnityEditor;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject settingsCanvas;

    private bool isSettingsMenuActive;

    private void Start()
    {
        inputManager.OnSettingsMenu.AddListener(ToggleSettingsMenu);
        DisableSettingsMenu();
    }

    private void ToggleSettingsMenu()
    {
        if (!isSettingsMenuActive) EnableSettingsMenu();
        else DisableSettingsMenu();
    }

    private void EnableSettingsMenu()
    {
        Time.timeScale = 0f;
        settingsCanvas.SetActive(true);
        isSettingsMenuActive = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void DisableSettingsMenu()
    {
        Time.timeScale = 1f;
        settingsCanvas.SetActive(false);
        isSettingsMenuActive = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
