using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D playerRigidbody; // referencja do komponentu Rigidbody2D, kt�ry kontroluje ruch gracza.
    [SerializeField] private GroundChecker groundChecker;//referencja do obiektu GroundChecker, kt�ry sprawdza, czy gracz jest na ziemi.

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 5f; // zmienna predkosci ruchu gracza
    [SerializeField] private float jumpPower = 5f;// zmienna okre�la si�� skoku gracza.

    [Header("Sounds")]
    [SerializeField] private AudioClip jumpSound;// dzwiek skoku gracza
    [SerializeField] private float moveSoundDelay = 0.1f;// opoznienine miedzy dzwiekami ruchu
    [SerializeField] private AudioClip moveSound;//dzwiek ruchu gracza

    private float moveSoundTimer = 0f;// licznik na zero, �ledzenia czasu od ostatniego odtworzenia d�wi�ku ruchu.
    private float inputX;//przechowuj�ca warto�� wej�cia od gracza (ruch w lewo/prawo).
    private bool isJumpingInput = false;//sprawdza czy gracz wciska spacje( klawisz skoku)
    private void Update()
    {
        inputX = Input.GetAxis("Horizontal"); // Pobiera warto�� osi poziomej od gracza, co odpowiada ruchowi w lewo/prawo.
        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.IsGrounded)//Jezeli gracz nacisn�� spacj� i  jest na ziemi. 
        {
            isJumpingInput = true;//jest w skoku
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);// odtwarza d�wi�k skoku.
        }
        if(isMoving() && groundChecker.IsGrounded)// Jezeli jest w ruchu i jest na ziemi 
        {
            moveSoundTimer += Time.deltaTime;// zaczynamy zlicza� czas. Time.deltaTime to czas, jaki up�yn�� od ostatniej klatki,
                                             // co pozwala na p�ynne dzia�anie gry niezale�nie od ilo�ci klatek na sekund�.
            if (moveSoundTimer >= moveSoundDelay)// Sprawdzamy, czy up�yn�� wystarczaj�cy czas od ostatniego odtworzenia d�wi�ku ruchu.
            {
                moveSoundTimer -= moveSoundDelay;//gdy up�ynie odpowiednio du�o czasu, zaczynamy odlicza� ten czas,
                                                 //odejmuj�c moveSoundDelay od moveSoundTimer
                AudioSource.PlayClipAtPoint(moveSound, transform.position);// odtworzenie dzwieku ruchu
            }
        }
    }

    private void FixedUpdate()
    {
        //Ta linjka reprezentuje, jak szybko gracz powinien si� porusza� w danym kroku fizycznym.
        float moveInput = inputX * Time.fixedDeltaTime * moveSpeed;//Time.fixedDeltaTime to czas, jaki up�yn�� od ostatniego kroku
                                                                   //fizycznego, co pomaga uzyska� sta�� pr�dko�� niezale�nie od ilo�ci klatek na sekund�.
        playerRigidbody.velocity = new Vector2(moveInput, playerRigidbody.velocity.y);// Ustawia pr�dko�� gracza na podstawie obliczonej
                                                                                      // warto�ci moveInput. playerRigidbody.velocity.y pozostaje
                                                                                      // niezmienione, co oznacza, �e nie wp�ywamy na pr�dko�� pionow� gracza.

        if (isJumpingInput)//Jezeli chce skoczyc 
        {
            //Dodaje impuls do cia�a gracza, co simuluje skok
            playerRigidbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);//gdzie 0 oznacza brak impulsu w poziomie,
                                                                                     //a jumpPower to si�a skoku w pionie
                                                                                     //ForceMode2D.Impulse oznacza, �e si�a jest dodawana natychmiastowo.
            isJumpingInput = false; //jezeli wykona sie skok to ustawiam false zeby warunek sie znowu nie wykona�(nie ma podw�jnych skok�w)
        }
    }

    public bool isMoving()// Zwraca true, je�li gracz si� porusza (uzyte w aniimacjach).
    {
        return inputX != 0;
    }
    public float GetCurrentInputX()//Zwraca bie��c� warto�� wej�cia osi poziomej od gracza (rotacje)
    {
        return inputX;
    
    }
}
