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
                                                              // ustawiioony na 1 poniewa� liczymy indeksy od 0
                                                              // a indeks 0 w moim przypadku to menu

    private void Start()
    {
        //Dodaje listenery do przycisk�w, dzi�ki kt�rym zostan� wykonane odpowiednie metody po klikni�ciu przycisk�w.
        startGameButton.onClick.AddListener(StartGame);
        exitGameButton.onClick.AddListener(ExitGame);
    }


    private void ExitGame()//Metoda ExitGame jest wywo�ywana po klikni�ciu przycisku "Exit".
                           //Wywo�uje ona Application.Quit(), co ko�czy dzia�anie aplikacji.
    {
        Application.Quit();
    }

    private void StartGame()//Metoda StartGame jest wywo�ywana po klikni�ciu przycisku "Start Game".
                            //Wywo�anie jej powoduje za�adowanie sceny o indeksie firstGameplaySceneIndex.
    {
        SceneManager.LoadScene(firstGameplaySceneIndex);
    }
}
