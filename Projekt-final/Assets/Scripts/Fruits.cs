using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{

    [SerializeField] private AudioClip pickupSound;//Pole prywatne u¿ywane do przypisania dŸwiêku,
                                                   //który zostanie odtworzony po zebraniu owocu.
    [SerializeField] private GameObject pickupEffectPrefab;//Prefabrykat efektu (animiacji), który
                                                           //zostanie utworzony po zebraniu owocu.
    private void OnTriggerEnter2D(Collider2D collision)//Metoda ta jest wywo³ywana, gdy inny obiekt zderza siê z
                                                       //obiektem posiadaj¹cym ten skrypt, a ten inny obiekt posiada
                                                       //komponent Collider2D.
    {
        if(collision.TryGetComponent(out PlayerInventory playerInventory))// Sprawdzenie, czy obiekt, który wszed³ w interakcjê,
                                                                          // posiada skrypt PlayerInventory.
                                                                          // Jeœli tak, oznacza to, ¿e jest to gracz.
        {
            playerInventory.AddFruit();//Wywo³anie metody AddFruit z skryptu PlayerInventory,
                                       //co zwiêksza licznik zebranych owoców przez gracza.

            //Utworzenie efektu wizualnego w miejscu zebranego owocu. Prefab efektu ma brak rotacji
            var spawnePrefab = Instantiate(pickupEffectPrefab, transform.position, Quaternion.identity);
            Destroy(spawnePrefab, 1f);//Zniszczenie tego efektu po 1 sekundzie 

            AudioSource.PlayClipAtPoint(pickupSound, transform.position);// Odtworzenie dŸwiêku zbierania owocu w miejscu zebranego owocu.
            Destroy(gameObject); //Zniszenie jablek po zebraniu

           
        }
    }
}
