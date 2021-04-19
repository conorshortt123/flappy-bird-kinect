using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;  // for stringbuilder
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;   // grammar recogniser


/*
 *  Uses English US in the settings - Keyboard (on the taskbar), Region, Preferred Language and Speech in Settings
 */

public class GrammarController : MonoBehaviour
{
    private GrammarRecognizer gr;
    Dictionary<string, string> phrase = new Dictionary<string, string>();
    private bool gameRunning = false;
    public MenuHandler mh;

    private void Start()
    {
        // Loads in the grammar recognizer at game start.
        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, "GameGrammar.xml"), ConfidenceLevel.Low);
        Debug.Log("Grammar loaded!");
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start();
        if (gr.IsRunning) Debug.Log("Recogniser running");

        Time.timeScale = 0f;
    }

    // Listens for phrases that are contained in the XML file.
    private void GR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        // Log to console that phrase was recognized
        Debug.Log("Recognized phrase");

        // read the semantic meanings from the args passed in.
        SemanticMeaning[] meanings = args.semanticMeanings;

        // use foreach to get all the meanings.
        foreach(SemanticMeaning meaning in meanings)
        {
            // Add key value pairs from phrase to Dictionary, E.G: "action":"start"
            phrase.Add(meaning.key.Trim(), meaning.values[0].Trim());
            Debug.Log("Key: " + meaning.key.Trim() + "\tValue: " + meaning.values[0].Trim());
        }

        string action = phrase["action"];

        switch (action)
        {
            case "new":
                mh.RestartGame();
                break;
            case "start":
                mh.StartGame();
                break;
            case "controls":
            case "pause":
                mh.OptionsMenu();
                break;
            case "quit":
                Application.Quit();
                break;
            case "resume":
                mh.OptionsMenu();
                break;
            case "restart":
                mh.RestartGame();
                break;
            case "pausemusic":
                mh.AdjustVolume(0);
                break;
            case "resumemusic":
                mh.AdjustVolume(0.1f);
                break;
            default:
                break;
        }

        // Clear dictionary so that there won't be a duplicate key error.
        phrase.Clear();
    }

    private void OnApplicationQuit()
    {
        if (gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= GR_OnPhraseRecognized;
            gr.Stop();
        }
    }
}
