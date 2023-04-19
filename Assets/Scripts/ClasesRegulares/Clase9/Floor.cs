using System;
using UnityEngine;

namespace ClasesRegulares.Clase9
{
    public class Floor : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log($"{collision.impulse}");
            }
        }
    }
}