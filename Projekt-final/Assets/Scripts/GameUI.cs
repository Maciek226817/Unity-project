using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Header("Friut Counter")]
    [SerializeField] private TextMeshProUGUI fruitCounterText;//licznik owoców

    [Header("Game Over Screen")]
    [SerializeField] private GameObject gameOverScreenObject; //referencja do ca³ego obiektu
    [SerializeField] private Button gamOverRestartButton;// przycisk restaru

    [Header("Complete Level Screen")]
    [SerializeField] private GameObject levelCompleteScreenObject; //referencja do ca³ego obiektu
    [SerializeField] private Button nextLevelButton;// przycisk nastêpnego levelu

    [Header("Complete Game Screen")]
    [SerializeField] private GameObject gameCompleteScreenObject; //referencja do ca³ego obiektu
    [SerializeField] private Button restartGameButton;// przycisk restaru
    [SerializeField] private Button exitGameButton;// przycisk wy³aczenia gry
    [SerializeField] private Button menuButton;// przycisk powrotu do menu
    [SerializeField] private int FirstIndex = 1;// pierwszy index

    private Player player; // referencja do gracza
    private PlayerInventory playerInventory; // referencja do ekwipunku gracza
    private int FruitsOnMap; // liczba oowców na mapie 


    private void Awake()//Metoda ta jest wywo³ywana zaraz po utworzeniu obiektu w scenie, przed metod¹ Start.
    {
        player = FindObjectOfType<Player>();// Wyszukuje referencjê do obiektu Player w scenie
        playerInventory = FindObjectOfType<PlayerInventory>();// Wyszukuje referencjê do obiektu PlayerInventory w scenie

        var fruits = FindObjectsOfType<Fruits>();// var - pozwala na deklaracjê zmiennej bez koniecznoœci jawnego okreœlania jej typu
                                                 // Znajduje wszystkie obiekty Fruits w scenie i zlicz ich iloœæ
        FruitsOnMap = fruits.Length;

        // Wy³¹cza ró¿ne ekrany na pocz¹tku
        levelCompleteScreenObject.SetActive(false);
        gameCompleteScreenObject.SetActive(false);
        gameOverScreenObject.SetActive(false);

        // Dodaje funkcjê DisplayGameOverScreen do zdarzenia OnLose gracza
        player.OnLose += DisplayGameOverScreen;

        // Przypisanie  funkcji do przycisków
        gamOverRestartButton.onClick.AddListener(RestartScene);
        nextLevelButton.onClick.AddListener(MoveToNextLevel);
        restartGameButton.onClick.AddListener(RestartGame);
        exitGameButton.onClick.AddListener(ExitGame);
        menuButton.onClick.AddListener(BackToMenu);

    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("Menu");// Po kliknieciu powrót do menu 
    }

    private void ExitGame()
    {
        Application.Quit(); //Wy³¹czenie gry, aplikacji
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(FirstIndex);// Oznacza to ze za³aduje nam 1 scene gry
                                           // indeksowanie jest od zera dlatego jest utworzona zmienna
                                           // firstindex ustawiona na 1 bo index zera ma menu
    }

    private void MoveToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// Przejscie do nastepnego levelu(za³adowanie sceny o indeksie wiêkszym o 1)
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Ladowanie aktualnej sceny
    }

    private void DisplayGameOverScreen()
    {
        gameOverScreenObject.SetActive(true); // Pokazanie ekranu game over , Aktywuje obiekt ekranu koñca gry po przegranej.
    }


    private void Update()// Funkcja to wywo³ywana jest co klatkê
    {
        // Aktualizuje tekst licznika owoców ,( licznik w prawym górnym rogu)
        fruitCounterText.text = $"{playerInventory.GetCollectedFruits()}/{FruitsOnMap}";
        // Sprawdzenie warunek wygranej(czy zebrane wszytkie owoce i czy ekran ukoñczenia poziomu nie jest aktywny 
        if (playerInventory.GetCollectedFruits() == FruitsOnMap && !levelCompleteScreenObject.activeSelf) 
        {
            // Jezeli wygramy natsepuje wylaczenie obiektu gracza po ukoñczeniu poziomu
            player.gameObject.SetActive(false);

            //Sprawdzenie czy istnieje kolejny Level
            if(Application.CanStreamedLevelBeLoaded(SceneManager.GetActiveScene().buildIndex + 1))
            {
                levelCompleteScreenObject.SetActive(true);// czyli go w³¹czymy jezeli istnieje  
            }
            else
            {
                gameCompleteScreenObject.SetActive(true);// W przeciwnym przypadku odpalamy Obraz konca gry
            }

            
        }

    }
}
