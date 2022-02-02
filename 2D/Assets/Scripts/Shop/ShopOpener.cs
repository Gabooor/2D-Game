using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOpener : MonoBehaviour
{
    public GameObject shop;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            if (!isOpen)
            {
                shop.SetActive(true);
                isOpen = true;
                Time.timeScale = 0f;
            }
            else
            {
                shop.SetActive(false);
                isOpen = false;
                Time.timeScale = 1f;
            }
        }
    }
}
