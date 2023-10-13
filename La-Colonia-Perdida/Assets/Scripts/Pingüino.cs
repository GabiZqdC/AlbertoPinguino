using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pingüino : MonoBehaviour
{
    private float velocidad = 5f;
    [SerializeField] private Rigidbody2D rigidbody;
    private float inputHorizontal;

    private float fuerzaSalto = 16f;

    private bool miraDerecha = true;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody=GetComponent<Rigidbody2D>();
        rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space) && EnTierra())
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, fuerzaSalto);
        }

        if (Input.GetKeyDown(KeyCode.Space) && rigidbody.velocity.y>0f)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * 0.5f);
        }


        Flip();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(inputHorizontal * velocidad, rigidbody.velocity.y);
    }

    private bool EnTierra()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void Flip()
    {
        if(miraDerecha && inputHorizontal < 0f || !miraDerecha && inputHorizontal > 0f)
        {
            miraDerecha = !miraDerecha;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
