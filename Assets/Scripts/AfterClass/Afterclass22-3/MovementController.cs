using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Movement movementComponent;
    [SerializeField] private Vector3 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        movementComponent.SetCharacterName("Giorgio");
        Debug.Log("Hola:" + movementComponent.GetCharacterName());
    }

    // Update is called once per frame
    void Update()
    {
        movementComponent.Move(0.1f, movementDirection, transform);
    }
}