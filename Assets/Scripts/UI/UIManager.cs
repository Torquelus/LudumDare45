using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour{

    // Menus
    public GameObject mainMenu;
    public GameObject optionsMenu;

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
