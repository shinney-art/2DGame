using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float movespeed = 5;
    private Rigidbody2D rigid;
    private Vector2 movement;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        Vector3 Cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Cursor.z = 0;
        Vector2 direction = (Cursor - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
     void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + movement * movespeed * Time.fixedDeltaTime);
    }
}
