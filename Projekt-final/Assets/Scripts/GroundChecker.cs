using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private string groundTag;//Prywatne pole tekstowe do przechowywania tagu obiektu uznawanego za grunt
    public bool IsGrounded { get; private set; } = false;// Zmienna jest publiczna dla inncyh skryptów ale dzieki temu get; private set;  mozemy j¹ ustawiæ tylko wewnatrz tego skyptu

    private void OnTriggerEnter2D(Collider2D collision) //  Ta metoda jest wywo³ywana, gdy inny collider wejdzie w kolizjê z colliderem,
                                                        //  do którego jest przypisany ten skrypt
    {
        if (collision.CompareTag(groundTag)) //Sprawdza, czy obiekt, który wszed³ w kolizjê, ma tag zdefiniowany jako groundTag.
                                             //Jeœli tak, to ustawia IsGrounded na true.
        {
            IsGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // A ta metoda jest wywo³ywana gdy kolizja siê skoñczy pomiêdzy colliderami
    {
        if (collision.CompareTag(groundTag))//Sprawdza, czy obiekt, który wszed³ w kolizjê, ma tag zdefiniowany jako groundTag.
                                            //Jeœli tak, to ustawia IsGrounded na false.
        {
            IsGrounded = false;
        }
    }
}
