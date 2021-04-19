using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public GameObject deathMenu;
    public GameObject optionsMenu;
    public GameObject startMenu;
    public GameObject hudUI;
    private GameObject camera;
    public AudioSource music;
    private bool options = false;
    private bool hud = false;
    private bool playerDead = false;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        Time.timeScale = 0;
    }

    // PUBLIC METHODS
    public void ShowDeathMenu()
    {
        Time.timeScale = 0;
        deathMenu.SetActive(true);
        HudUI();
        AdjustVolume(0);
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        HudUI();
        Time.timeScale = 1;
    }

    public void OptionsMenu()
    {
        if (!options)
            ShowOptionsMenu();
        else if(options)
            HideOptionsMenu();
    }

    public void HudUI()
    {
        if (!hud)
            ShowHud();
        else
            HideHud();
    }

    public void RestartGame()
    {
        //Destroy(camera);
        SceneManager.LoadScene("GameScene");
    }

    public void AdjustVolume(float volume)
    {
        music.volume = volume;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // PRIVATE METHODS
    private void ShowOptionsMenu()
    {
        Time.timeScale = 0;
        optionsMenu.SetActive(true);
        deathMenu.SetActive(false);
        startMenu.SetActive(false);
        options = true;
    }

    private void HideOptionsMenu()
    {
        Time.timeScale = 1;
        optionsMenu.SetActive(false);
        options = false;
    }

    private void ShowHud()
    {
        hudUI.SetActive(true);
        hud = true;
    }

    private void HideHud()
    {
        hudUI.SetActive(false);
        hud = false;
    }
}
