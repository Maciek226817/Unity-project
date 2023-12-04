using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int fruitCounter = 0; // Prywatna zmienna licznika owoc�w 

    public void AddFruit()//  s�u�y do zwi�kszania licznika owoc�w o 1 za ka�dym razem, gdy gracz zbierze owoc.
    {
        fruitCounter += 1;//  Inkrementacja licznika owoc�w.
        Debug.Log($"Fruit Number: {fruitCounter}");// Wypisanie w konsoli ilo�ci zebranych owoc�w
    }

    public int GetCollectedFruits() //metoda s�u��ca do pobierania aktualnej liczby zebranych owoc�w.
    {
        return fruitCounter;// Zwraca warto�� aktualnej liczby zebranych owoc�w.
    }
}
