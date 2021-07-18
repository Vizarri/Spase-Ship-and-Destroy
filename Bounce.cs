using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Скрипт , при помощи которого игровой объект может двигаться по осям x и y при помощи нажатия клавишь и если сталкивается с рамками камеры у него 
// отнимается 10 жизней и иконка становится менее яркой , когда жизни =0 , игровой объект уничтожается.

public class Bou : MonoBehaviour
{
    float Speed = 10f;
    private Rigidbody2D _rb;
    float Health = 100;
    Color color;


    // метод отвечающий за движение RigidBody
    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Плавное движение
        //_rb.AddForce(movement * Speed); 

        // строгое движение
        if (gameObject!=null)
        {
            _rb.transform.Translate(movement * Speed * Time.deltaTime);
        }
    }

    // метод обнаружения столкновения и взрыв объекта
    void OnCollisionEnter2D(Collision2D myCollision)
    {
        // определение столкновения с двумя разноименными объектами
        if (myCollision.gameObject.CompareTag("MainCamera"))
        {
            Health -= 10;
            color.a -= 0.1f;
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
        // взрывв если здоровье <=0
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
