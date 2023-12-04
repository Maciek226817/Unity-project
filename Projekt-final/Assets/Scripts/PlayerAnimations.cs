using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;//Referencja do komponentu Animator, który kontroluje animacje postaci.
    [SerializeField] private PlayerMovment movement;//Referencja do skryptu PlayerMovement, który kontroluje ruch postaci.
    [SerializeField] private Rigidbody2D playerRigidbody;// Referencja do komponentu Rigidbody2D postaci, który kontroluje fizykê postaci
    [SerializeField] private Transform graphicsTransform;// Referencja do transformacji grafiki postaci, który bêdzie obracany 

    [Header("Parameters")]
    [SerializeField] private string isMovingParamater;//Parametr animatora odpowiadaj¹cy za ruch postaci
    [SerializeField] private string isJumpingParamater;//Parametr animatora odpowiadaj¹cy za skok postaci
    [SerializeField] private string isFallingParamater;//Parametr animatora odpowiadaj¹cy za opadanie postaci

    private void Update()
    {
        animator.SetBool(isMovingParamater, movement.isMoving());//Ustawia wartoœæ parametru boolowskiego w animatorze odpowiadaj¹cego
                                                                 //za ruch postaci na podstawie informacji z PlayerMovement.
        //Animiacje 
        if (playerRigidbody.velocity.y > 0.1f)//Jezeli skladowa Y predkosc gracza jest wieksza od minimalnej wielkosci 
        {
            animator.SetBool(isJumpingParamater, true);// Jest w trakcie skoku
            animator.SetBool(isFallingParamater, false);
        }
        else if (playerRigidbody.velocity.y < -0.1f)
        {
            animator.SetBool(isJumpingParamater, false);
            animator.SetBool(isFallingParamater, true);// jest w trakcie spadania 
        }
        else
        {
            //Ani skacze ani opada
            animator.SetBool(isJumpingParamater, false);
            animator.SetBool(isFallingParamater, false);
        }

        //Rotacje
        if(movement.GetCurrentInputX() > 0)// Jezeli idzie w prawo to nic sie nie dzieje (rotacje) 
        {
            graphicsTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (movement.GetCurrentInputX() < 0)// a tutaj jezzeli w lewo to postac sie rotuje
        {
            graphicsTransform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
