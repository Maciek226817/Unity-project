using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour// g��wny obiekt gracza w grze
{
    public event Action OnLose;//OnLose to zdarzenie (event), kt�re mo�e by� wywo�ane w okre�lonych przypadkach.
                               //W tym przypadku, event ten b�dzie wywo�ywany, gdy gracz przegra.
                               //Inne funkcje w grze mog� nas�uchiwa� tego zdarzenia i reagowa� na nie.


    public void TakeDamage()//TakeDamage to metoda, kt�ra jest wywo�ywana, gdy gracz otrzymuje obra�enia.
                            //W tym przypadku, gdy gracz otrzymuje obra�enia, zostaje wywo�ane zdarzenie OnLose,
                            //co oznacza, �e gracz przegra�
    {
        
        OnLose?.Invoke();//wywo�uje zdarzenie OnLose, ale sprawdza najpierw, czy jest ono null.(? sprawdza, czy OnLose nie jest r�wny null przed pr�b� wywo�ania metody Invoke.
                         //Dzi�ki temu, nawet je�li �adna funkcja nie jest przypisana do tego zdarzenia, nie spowoduje to b��du
        gameObject.SetActive(false);//deaktywuje obiekt gracza, co oznacza, �e gracz nie jest ju� aktywny w scenie.(znika nie wida� go)
    }
}
