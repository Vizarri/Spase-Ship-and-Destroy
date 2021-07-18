using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// —крипт , при помощи которого игровой объект может двигатьс€ по ос€м x и y при помощи нажати€ клавишь и если сталкиваетс€ с рамками камеры у него 
// отнимаетс€ 10 жизней и иконка становитс€ менее €ркой , когда жизни =0 , игровой объект уничтожаетс€.

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

        // ѕлавное движение
        //_rb.AddForce(movement * Speed); 

        // строгое движение
        if (gameObject!=null)
        {
            _rb.transform.Translate(movement * Speed * Time.deltaTime);
        }
    }

    // метод обнаружени€ столкновени€ и взрыв объекта
    void OnCollisionEnter2D(Collision2D myCollision)
    {
        // определение столкновени€ с двум€ разноименными объектами
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
