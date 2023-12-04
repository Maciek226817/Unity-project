using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)//Metoda OnTriggerEnter2D jest wywo�ywana, gdy inny obiekt wchodzi w kolizj�
                                                       //z obiektem, do kt�rego jest przypisany ten skrypt. W tym przypadku
                                                       //chodzi o kolizje z graczem.
    {
        if (collision.TryGetComponent(out Player player))// jezeli  gracz wszed� w kolizj� z kolcami
        {
            player.TakeDamage();// zadaje obrazenia graczowi
        }
    }
}
