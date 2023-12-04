using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D playerRigidbody; // referencja do komponentu Rigidbody2D, który kontroluje ruch gracza.
    [SerializeField] private GroundChecker groundChecker;//referencja do obiektu GroundChecker, który sprawdza, czy gracz jest na ziemi.

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 5f; // zmienna predkosci ruchu gracza
    [SerializeField] private float jumpPower = 5f;// zmienna okreœla si³ê skoku gracza.

    [Header("Sounds")]
    [SerializeField] private AudioClip jumpSound;// dzwiek skoku gracza
    [SerializeField] private float moveSoundDelay = 0.1f;// opoznienine miedzy dzwiekami ruchu
    [SerializeField] private AudioClip moveSound;//dzwiek ruchu gracza

    private float moveSoundTimer = 0f;// licznik na zero, œledzenia czasu od ostatniego odtworzenia dŸwiêku ruchu.
    private float inputX;//przechowuj¹ca wartoœæ wejœcia od gracza (ruch w lewo/prawo).
    private bool isJumpingInput = false;//sprawdza czy gracz wciska spacje( klawisz skoku)
    private void Update()
    {
        inputX = Input.GetAxis("Horizontal"); // Pobiera wartoœæ osi poziomej od gracza, co odpowiada ruchowi w lewo/prawo.
        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.IsGrounded)//Jezeli gracz nacisn¹³ spacjê i  jest na ziemi. 
        {
            isJumpingInput = true;//jest w skoku
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);// odtwarza dŸwiêk skoku.
        }
        if(isMoving() && groundChecker.IsGrounded)// Jezeli jest w ruchu i jest na ziemi 
        {
            moveSoundTimer += Time.deltaTime;// zaczynamy zliczaæ czas. Time.deltaTime to czas, jaki up³yn¹³ od ostatniej klatki,
                                             // co pozwala na p³ynne dzia³anie gry niezale¿nie od iloœci klatek na sekundê.
            if (moveSoundTimer >= moveSoundDelay)// Sprawdzamy, czy up³yn¹³ wystarczaj¹cy czas od ostatniego odtworzenia dŸwiêku ruchu.
            {
                moveSoundTimer -= moveSoundDelay;//gdy up³ynie odpowiednio du¿o czasu, zaczynamy odliczaæ ten czas,
                                                 //odejmuj¹c moveSoundDelay od moveSoundTimer
                AudioSource.PlayClipAtPoint(moveSound, transform.position);// odtworzenie dzwieku ruchu
            }
        }
    }

    private void FixedUpdate()
    {
        //Ta linjka reprezentuje, jak szybko gracz powinien siê poruszaæ w danym kroku fizycznym.
        float moveInput = inputX * Time.fixedDeltaTime * moveSpeed;//Time.fixedDeltaTime to czas, jaki up³yn¹³ od ostatniego kroku
                                                                   //fizycznego, co pomaga uzyskaæ sta³¹ prêdkoœæ niezale¿nie od iloœci klatek na sekundê.
        playerRigidbody.velocity = new Vector2(moveInput, playerRigidbody.velocity.y);// Ustawia prêdkoœæ gracza na podstawie obliczonej
                                                                                      // wartoœci moveInput. playerRigidbody.velocity.y pozostaje
                                                                                      // niezmienione, co oznacza, ¿e nie wp³ywamy na prêdkoœæ pionow¹ gracza.

        if (isJumpingInput)//Jezeli chce skoczyc 
        {
            //Dodaje impuls do cia³a gracza, co simuluje skok
            playerRigidbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);//gdzie 0 oznacza brak impulsu w poziomie,
                                                                                     //a jumpPower to si³a skoku w pionie
                                                                                     //ForceMode2D.Impulse oznacza, ¿e si³a jest dodawana natychmiastowo.
            isJumpingInput = false; //jezeli wykona sie skok to ustawiam false zeby warunek sie znowu nie wykona³(nie ma podwójnych skoków)
        }
    }

    public bool isMoving()// Zwraca true, jeœli gracz siê porusza (uzyte w aniimacjach).
    {
        return inputX != 0;
    }
    public float GetCurrentInputX()//Zwraca bie¿¹c¹ wartoœæ wejœcia osi poziomej od gracza (rotacje)
    {
        return inputX;
    
    }
}
