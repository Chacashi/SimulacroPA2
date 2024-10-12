using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _compRigidbody2D;
    [SerializeField] float speed;
    [SerializeField] int livesPlayer = 3;
    float vertical;

    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(_compRigidbody2D.velocity.x, speed * vertical);
    }

    public void Vertical(InputAction.CallbackContext context)
    {
        vertical = context.ReadValue<float>();
    }

     public  int GetLivesPlayer()
    {
        return livesPlayer;
    }
}
