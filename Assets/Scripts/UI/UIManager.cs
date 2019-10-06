using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.LWRP;
using TMPro;
using UnityEngine.Rendering;

public class UIManager : MonoBehaviour{

    // Menus
    public GameObject mainMenu;
    public GameObject optionsMenu;

    // Graphics Qualities
    public LightweightRenderPipelineAsset lowQuality;
    public LightweightRenderPipelineAsset mediumQuality;
    public LightweightRenderPipelineAsset highQuality;

    // Quality Picker Dropdown
    public TMP_Dropdown dropdown;

    // Awake function
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start Game
    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Go to options menu
    public void GoToOptionsMenu() {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    // Set graphics quality
    public void SetGraphics() {
        LightweightRenderPipelineAsset chosenQuality;
        chosenQuality = null;
        Debug.Log(dropdown.value);

        switch (dropdown.value) {
            case 0:
                chosenQuality = lowQuality;
                break;
            case 1:
                chosenQuality = mediumQuality;
                break;
            case 2:
                chosenQuality = highQuality;
                break;
        }

        GraphicsSettings.renderPipelineAsset = chosenQuality;
    }

    // Go back to main menu
    public void GoToMainMenu() {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    // Go to main menu from any scene
    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

    // Toggle fullscreen function
    public void ToggleFullscreen() {
        Screen.fullScreen = !Screen.fullScreen;
    }

    // Quit game
    public void QuitGame() {
        Debug.Log("Quit!");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
