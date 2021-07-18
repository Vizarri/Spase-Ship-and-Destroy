using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ������ , ��� ������ �������� ������� ������ ����� ��������� �� ���� x � y ��� ������ ������� ������� � ���� ������������ � ������� ������ � ���� 
// ���������� 10 ������ � ������ ���������� ����� ����� , ����� ����� =0 , ������� ������ ������������.

public class Bou : MonoBehaviour
{
    float Speed = 10f;
    private Rigidbody2D _rb;
    float Health = 100;
    Color color;


    // ����� ���������� �� �������� RigidBody
    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // ������� ��������
        //_rb.AddForce(movement * Speed); 

        // ������� ��������
        if (gameObject!=null)
        {
            _rb.transform.Translate(movement * Speed * Time.deltaTime);
        }
    }

    // ����� ����������� ������������ � ����� �������
    void OnCollisionEnter2D(Collision2D myCollision)
    {
        // ����������� ������������ � ����� ������������� ���������
        if (myCollision.gameObject.CompareTag("MainCamera"))
        {
            Health -= 10;
            color.a -= 0.1f;
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
        // ������ ���� �������� <=0
        if (Health <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        color = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementLogic();  
    }
}
