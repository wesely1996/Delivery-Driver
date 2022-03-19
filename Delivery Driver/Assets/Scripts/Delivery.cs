using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPizza = false;
    [SerializeReference] GameObject pizza;
    [SerializeReference] GameObject customer;
    [SerializeReference] TextMeshProUGUI pizzaScore;
    public int pizzaCounter = 0;

    Vector3[] listOfCustomers = new Vector3[] { new Vector3(-13f,1.5f,0),
                                                new Vector3(-11.5f,-1.25f,0),
                                                new Vector3(-1.3f,19.4f,0),
                                                new Vector3(-1.3f,36f,0),
                                                new Vector3(1.3f,36f,0),
                                                new Vector3(-24.5f,43.5f,0),
                                                new Vector3(22f,30f,0),
                                                new Vector3(30.9f,10.4f,0),
                                                new Vector3(22.5f,19.5f,0),
                                                new Vector3(48.4f,-2f,0),
                                                new Vector3(48.4f,10.2f,0),
                                                new Vector3(48.4f,21.6f,0),
                                                new Vector3(48.4f,33.7f,0),
                                                new Vector3(48.4f,47.4f,0),
                                                new Vector3(48.4f,59.3f,0),
                                                new Vector3(45.8f,59.3f,0),
                                                new Vector3(45.8f,47.1f,0),
                                                new Vector3(45.8f,33.2f,0),
                                                new Vector3(45.8f,21.2f,0),
                                                new Vector3(11.2f,-29.1f,0),
                                                new Vector3(-1.8f,-34.2f,0),
                                                new Vector3(-19f,-21.7f,0),
                                                new Vector3(-29.7f,-21.6f,0),
                                                new Vector3(-39.9f,-15f,0),
                                                new Vector3(-41.6f,-17.6f,0),
                                                new Vector3(-47.8f,-11.6f,0),
                                                new Vector3(-75.9f,-22.6f,0),
                                                new Vector3(-64.4f,3f,0),
                                                new Vector3(-78.9f,23.4f,0),
                                                new Vector3(-64f,43f,0),
                                                new Vector3(-79.4f,63.5f,0)};

    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        hasPizza = false;
        pizzaCounter = 0;
        pizza.SetActive(!hasPizza);
        customer.SetActive(hasPizza);
        transform.GetChild(0).gameObject.SetActive(hasPizza);
        pizzaScore.text = "Pizza: " + pizzaCounter;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pizza" && !hasPizza)
        {
            hasPizza = true;
            pizza.SetActive(!hasPizza);
            customer.SetActive(hasPizza);
            customer.transform.position = listOfCustomers[Random.Range(0, listOfCustomers.Length-1)];
            transform.GetChild(0).gameObject.SetActive(hasPizza);
        }else if (collision.tag == "Customer" && hasPizza)
        {
            hasPizza = false;
            pizzaCounter++;
            pizza.SetActive(!hasPizza);
            customer.SetActive(hasPizza);
            transform.GetChild(0).gameObject.SetActive(hasPizza);
            pizzaScore.text = "Pizza: " + pizzaCounter;
        }else if (collision.tag == "Boost")
        {
            transform.GetComponent<Movement>().IncreseSpeed();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.GetComponent<Movement>().DecreseSpeed();
    }
}
