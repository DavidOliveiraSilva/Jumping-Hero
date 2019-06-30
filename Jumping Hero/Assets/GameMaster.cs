using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public bool playerDead;
    public bool playing;
    private GameObject startButton;
    private GameObject quitButton;
    private GameObject HP;
    private GameObject canvas;
    private GameObject player;
    private bool isRestart;
    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("StartButton");
        quitButton = GameObject.Find("QuitButton");
        HP = GameObject.Find("HP");
        canvas = GameObject.Find("Canvas");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        HP.GetComponent<Text>().text = player.GetComponent<Player>().GetHP().ToString();
    }

    public void StartGame() {
        if (isRestart) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            startButton.GetComponent<Image>().enabled = false;
            startButton.transform.Find("Text").GetComponent<Text>().enabled = false;
            quitButton.GetComponent<Image>().enabled = false;
            quitButton.transform.Find("Text").GetComponent<Text>().enabled = false;
            playing = true;
        } else {
            //canvas.SetActive(false);
            isRestart = true;
            startButton.GetComponent<Image>().enabled = false;
            startButton.transform.Find("Text").GetComponent<Text>().enabled = false;
            quitButton.GetComponent<Image>().enabled = false;
            quitButton.transform.Find("Text").GetComponent<Text>().enabled = false;

            changeStartButton();
            playing = true;
        }
    }

    

    public void GameOver() {
        //canvas.SetActive(true);

        startButton.GetComponent<Image>().enabled = true;
        startButton.transform.Find("Text").GetComponent<Text>().enabled = true;
        quitButton.GetComponent<Image>().enabled = true;
        quitButton.transform.Find("Text").GetComponent<Text>().enabled = true;

        playing = false;
    }

    public void Quit() {

    }

    public void changeStartButton() {
        startButton.transform.Find("Text").GetComponent<Text>().text = "Restart";
    }
}
