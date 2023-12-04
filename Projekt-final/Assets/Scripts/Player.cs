using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour// g³ówny obiekt gracza w grze
{
    public event Action OnLose;//OnLose to zdarzenie (event), które mo¿e byæ wywo³ane w okreœlonych przypadkach.
                               //W tym przypadku, event ten bêdzie wywo³ywany, gdy gracz przegra.
                               //Inne funkcje w grze mog¹ nas³uchiwaæ tego zdarzenia i reagowaæ na nie.


    public void TakeDamage()//TakeDamage to metoda, która jest wywo³ywana, gdy gracz otrzymuje obra¿enia.
                            //W tym przypadku, gdy gracz otrzymuje obra¿enia, zostaje wywo³ane zdarzenie OnLose,
                            //co oznacza, ¿e gracz przegra³
    {
        
        OnLose?.Invoke();//wywo³uje zdarzenie OnLose, ale sprawdza najpierw, czy jest ono null.(? sprawdza, czy OnLose nie jest równy null przed prób¹ wywo³ania metody Invoke.
                         //Dziêki temu, nawet jeœli ¿adna funkcja nie jest przypisana do tego zdarzenia, nie spowoduje to b³êdu
        gameObject.SetActive(false);//deaktywuje obiekt gracza, co oznacza, ¿e gracz nie jest ju¿ aktywny w scenie.(znika nie widaæ go)
    }
}
