using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private string groundTag;//Prywatne pole tekstowe do przechowywania tagu obiektu uznawanego za grunt
    public bool IsGrounded { get; private set; } = false;// Zmienna jest publiczna dla inncyh skrypt�w ale dzieki temu get; private set;  mozemy j� ustawi� tylko wewnatrz tego skyptu

    private void OnTriggerEnter2D(Collider2D collision) //  Ta metoda jest wywo�ywana, gdy inny collider wejdzie w kolizj� z colliderem,
                                                        //  do kt�rego jest przypisany ten skrypt
    {
        if (collision.CompareTag(groundTag)) //Sprawdza, czy obiekt, kt�ry wszed� w kolizj�, ma tag zdefiniowany jako groundTag.
                                             //Je�li tak, to ustawia IsGrounded na true.
        {
            IsGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // A ta metoda jest wywo�ywana gdy kolizja si� sko�czy pomi�dzy colliderami
    {
        if (collision.CompareTag(groundTag))//Sprawdza, czy obiekt, kt�ry wszed� w kolizj�, ma tag zdefiniowany jako groundTag.
                                            //Je�li tak, to ustawia IsGrounded na false.
        {
            IsGrounded = false;
        }
    }
}
