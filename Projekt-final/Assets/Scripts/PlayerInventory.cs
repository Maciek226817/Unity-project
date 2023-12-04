using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int fruitCounter = 0; // Prywatna zmienna licznika owoców 

    public void AddFruit()//  s³u¿y do zwiêkszania licznika owoców o 1 za ka¿dym razem, gdy gracz zbierze owoc.
    {
        fruitCounter += 1;//  Inkrementacja licznika owoców.
        Debug.Log($"Fruit Number: {fruitCounter}");// Wypisanie w konsoli iloœci zebranych owoców
    }

    public int GetCollectedFruits() //metoda s³u¿¹ca do pobierania aktualnej liczby zebranych owoców.
    {
        return fruitCounter;// Zwraca wartoœæ aktualnej liczby zebranych owoców.
    }
}
