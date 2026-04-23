using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePrefab : MonoBehaviour
{
    public GameObject prefabNext;
    public GameObject PrefabCurrent;
    public GameObject FuelCan;
    public GameObject Laser;
    

    public float incrementxpos;

    private GameObject PrefabSwap;
    private int trigger1;
   

    // Start is called before the first frame update
    void Start()
    {
        trigger1 = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER");
        Debug.Log(trigger1);

       
        if (trigger1 >  0 & collision.gameObject.tag == "PrefabTrigger")

        {
            int choice = Random.Range(0, 4);
            Debug.Log("Choice");
            Debug.Log(choice);
                
           /* if (choice == 0)
            {
                FuelCan.SetActive(true);
                Laser.SetActive(true);
            }
            else if (choice == 1)
            {
                FuelCan.SetActive(false);
                Laser.SetActive(false);      
            }
            else if(choice == 2)
            {
                FuelCan.SetActive(false);
                Laser.SetActive(true);
            }
            else if (choice  == 3)
            {
                FuelCan.SetActive(true);
                Laser.SetActive(false);
            }*/
           
            
                Debug.Log("End of Prefab Triggered");
                Vector2 temPos = PrefabCurrent.transform.position;
                temPos.x = temPos.x + incrementxpos;
                prefabNext.transform.position = temPos;
                PrefabSwap = PrefabCurrent;
                PrefabCurrent = prefabNext;
                prefabNext = PrefabSwap;
                trigger1 = 0;
                
            
        }

        if (trigger1 == 0 & collision.gameObject.tag == "PrefabTrigger")
        {
            trigger1++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
