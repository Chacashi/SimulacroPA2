using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : RayCastBase
{
    private Rigidbody2D _compRigidbody2D;
    public Vector2 direction;
    public float speed;
    public float horizontal;
    public float vertical;
    SpriteRenderer _compSpriteRenderer; 
    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }
   

    // Update is called once per frame


    private void FixedUpdate()
    {
        _compRigidbody2D.velocity = direction * speed;
        RaycastHit2D raycast2D = Physics2D.Raycast(OriginPoint, direction, RayDistance, LayerTargets);
        if(raycast2D.collider != null)
{
            CollisionPoint = direction.normalized * raycast2D.distance;
            HasCollide = true;
        }
        else
        {
            CollisionPoint = direction.normalized * RayDistance;
            HasCollide = false;
        }
        DrawRayPoint();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.tag=="Color")
        {
            _compSpriteRenderer.color = collision.gameObject.GetComponent<SpriteRenderer>().color;
        }

        if(collision != null && collision.tag=="Shape")
        {
            _compSpriteRenderer.sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;    
        }
    }

    protected override void Start()
    {
        base.Start();
        Debug.Log("Called from 2D Child");
    }
    protected override void Update()
    {
        base.Update();
      
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector2(horizontal, vertical);
    }

}
