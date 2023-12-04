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
    [SerializeField] private TextMeshProUGUI fruitCounterText;//licznik owoc�w

    [Header("Game Over Screen")]
    [SerializeField] private GameObject gameOverScreenObject; //referencja do ca�ego obiektu
    [SerializeField] private Button gamOverRestartButton;// przycisk restaru

    [Header("Complete Level Screen")]
    [SerializeField] private GameObject levelCompleteScreenObject; //referencja do ca�ego obiektu
    [SerializeField] private Button nextLevelButton;// przycisk nast�pnego levelu

    [Header("Complete Game Screen")]
    [SerializeField] private GameObject gameCompleteScreenObject; //referencja do ca�ego obiektu
    [SerializeField] private Button restartGameButton;// przycisk restaru
    [SerializeField] private Button exitGameButton;// przycisk wy�aczenia gry
    [SerializeField] private Button menuButton;// przycisk powrotu do menu
    [SerializeField] private int FirstIndex = 1;// pierwszy index

    private Player player; // referencja do gracza
    private PlayerInventory playerInventory; // referencja do ekwipunku gracza
    private int FruitsOnMap; // liczba oowc�w na mapie 


    private void Awake()//Metoda ta jest wywo�ywana zaraz po utworzeniu obiektu w scenie, przed metod� Start.
    {
        player = FindObjectOfType<Player>();// Wyszukuje referencj� do obiektu Player w scenie
        playerInventory = FindObjectOfType<PlayerInventory>();// Wyszukuje referencj� do obiektu PlayerInventory w scenie

        var fruits = FindObjectsOfType<Fruits>();// var - pozwala na deklaracj� zmiennej bez konieczno�ci jawnego okre�lania jej typu
                                                 // Znajduje wszystkie obiekty Fruits w scenie i zlicz ich ilo��
        FruitsOnMap = fruits.Length;

        // Wy��cza r�ne ekrany na pocz�tku
        levelCompleteScreenObject.SetActive(false);
        gameCompleteScreenObject.SetActive(false);
        gameOverScreenObject.SetActive(false);

        // Dodaje funkcj� DisplayGameOverScreen do zdarzenia OnLose gracza
        player.OnLose += DisplayGameOverScreen;

        // Przypisanie  funkcji do przycisk�w
        gamOverRestartButton.onClick.AddListener(RestartScene);
        nextLevelButton.onClick.AddListener(MoveToNextLevel);
        restartGameButton.onClick.AddListener(RestartGame);
        exitGameButton.onClick.AddListener(ExitGame);
        menuButton.onClick.AddListener(BackToMenu);

    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("Menu");// Po kliknieciu powr�t do menu 
    }

    private void ExitGame()
    {
        Application.Quit(); //Wy��czenie gry, aplikacji
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(FirstIndex);// Oznacza to ze za�aduje nam 1 scene gry
                                           // indeksowanie jest od zera dlatego jest utworzona zmienna
                                           // firstindex ustawiona na 1 bo index zera ma menu
    }

    private void MoveToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// Przejscie do nastepnego levelu(za�adowanie sceny o indeksie wi�kszym o 1)
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Ladowanie aktualnej sceny
    }

    private void DisplayGameOverScreen()
    {
        gameOverScreenObject.SetActive(true); // Pokazanie ekranu game over , Aktywuje obiekt ekranu ko�ca gry po przegranej.
    }


    private void Update()// Funkcja to wywo�ywana jest co klatk�
    {
        // Aktualizuje tekst licznika owoc�w ,( licznik w prawym g�rnym rogu)
        fruitCounterText.text = $"{playerInventory.GetCollectedFruits()}/{FruitsOnMap}";
        // Sprawdzenie warunek wygranej(czy zebrane wszytkie owoce i czy ekran uko�czenia poziomu nie jest aktywny 
        if (playerInventory.GetCollectedFruits() == FruitsOnMap && !levelCompleteScreenObject.activeSelf) 
        {
            // Jezeli wygramy natsepuje wylaczenie obiektu gracza po uko�czeniu poziomu
            player.gameObject.SetActive(false);

            //Sprawdzenie czy istnieje kolejny Level
            if(Application.CanStreamedLevelBeLoaded(SceneManager.GetActiveScene().buildIndex + 1))
            {
                levelCompleteScreenObject.SetActive(true);// czyli go w��czymy jezeli istnieje  
            }
            else
            {
                gameCompleteScreenObject.SetActive(true);// W przeciwnym przypadku odpalamy Obraz konca gry
            }

            
        }

    }
}
