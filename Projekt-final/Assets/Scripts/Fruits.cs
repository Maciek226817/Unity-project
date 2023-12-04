using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{

    [SerializeField] private AudioClip pickupSound;//Pole prywatne u�ywane do przypisania d�wi�ku,
                                                   //kt�ry zostanie odtworzony po zebraniu owocu.
    [SerializeField] private GameObject pickupEffectPrefab;//Prefabrykat efektu (animiacji), kt�ry
                                                           //zostanie utworzony po zebraniu owocu.
    private void OnTriggerEnter2D(Collider2D collision)//Metoda ta jest wywo�ywana, gdy inny obiekt zderza si� z
                                                       //obiektem posiadaj�cym ten skrypt, a ten inny obiekt posiada
                                                       //komponent Collider2D.
    {
        if(collision.TryGetComponent(out PlayerInventory playerInventory))// Sprawdzenie, czy obiekt, kt�ry wszed� w interakcj�,
                                                                          // posiada skrypt PlayerInventory.
                                                                          // Je�li tak, oznacza to, �e jest to gracz.
        {
            playerInventory.AddFruit();//Wywo�anie metody AddFruit z skryptu PlayerInventory,
                                       //co zwi�ksza licznik zebranych owoc�w przez gracza.

            //Utworzenie efektu wizualnego w miejscu zebranego owocu. Prefab efektu ma brak rotacji
            var spawnePrefab = Instantiate(pickupEffectPrefab, transform.position, Quaternion.identity);
            Destroy(spawnePrefab, 1f);//Zniszczenie tego efektu po 1 sekundzie 

            AudioSource.PlayClipAtPoint(pickupSound, transform.position);// Odtworzenie d�wi�ku zbierania owocu w miejscu zebranego owocu.
            Destroy(gameObject); //Zniszenie jablek po zebraniu

           
        }
    }
}
