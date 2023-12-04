using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)//Metoda OnTriggerEnter2D jest wywo³ywana, gdy inny obiekt wchodzi w kolizjê
                                                       //z obiektem, do którego jest przypisany ten skrypt. W tym przypadku
                                                       //chodzi o kolizje z graczem.
    {
        if (collision.TryGetComponent(out Player player))// jezeli  gracz wszed³ w kolizjê z kolcami
        {
            player.TakeDamage();// zadaje obrazenia graczowi
        }
    }
}
