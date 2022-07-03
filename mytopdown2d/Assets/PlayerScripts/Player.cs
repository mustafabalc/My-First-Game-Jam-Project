using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public Camera sceneCamera;
    [SerializeField] float moveSpeed;

    Rigidbody2D rb;
    Vector2 moveDir;

    private Vector2 mousePosition;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    private void Update()
    {

        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(hor, ver).normalized;




    }

    private void FixedUpdate()
    {
        rb.velocity = moveDir * moveSpeed;
        processInput();
        Move();
    }

    void processInput()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Move()
    {
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngel = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngel;

    }
}
