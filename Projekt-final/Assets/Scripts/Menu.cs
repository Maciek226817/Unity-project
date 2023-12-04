using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button startGameButton;// deklaracja prywatnego pola przycisku startgame
    [SerializeField] private Button exitGameButton;// deklaracja prywatnego pola przycisku exitgame 
    [SerializeField] private int firstGameplaySceneIndex = 1; // deklaracja indeksu pierwszej sceny gry
                                                              // ustawiioony na 1 poniewa¿ liczymy indeksy od 0
                                                              // a indeks 0 w moim przypadku to menu

    private void Start()
    {
        //Dodaje listenery do przycisków, dziêki którym zostan¹ wykonane odpowiednie metody po klikniêciu przycisków.
        startGameButton.onClick.AddListener(StartGame);
        exitGameButton.onClick.AddListener(ExitGame);
    }


    private void ExitGame()//Metoda ExitGame jest wywo³ywana po klikniêciu przycisku "Exit".
                           //Wywo³uje ona Application.Quit(), co koñczy dzia³anie aplikacji.
    {
        Application.Quit();
    }

    private void StartGame()//Metoda StartGame jest wywo³ywana po klikniêciu przycisku "Start Game".
                            //Wywo³anie jej powoduje za³adowanie sceny o indeksie firstGameplaySceneIndex.
    {
        SceneManager.LoadScene(firstGameplaySceneIndex);
    }
}
