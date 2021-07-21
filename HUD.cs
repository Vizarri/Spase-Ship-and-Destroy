using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Класс отвечающий за вывод на экран количества столкновений

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text textOutput;
    int collision=0;

    public void AddBounce()
    {
        collision += 1;
        textOutput.text = collision.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        textOutput.text = collision.ToString();
    }
}
