using UnityEngine;

public class MovePrefab : MonoBehaviour
{
    public GameObject prefabNext;
    public GameObject prefabCurrent;
    public GameObject FuelCan;
    public GameObject Laser;
    int movePrefab = 0;

    public float prefabWidth;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "PrefabTrigger") return;

        if (movePrefab == 0)
        {
            // Skip the very first trigger hit — prefab 2 is already in position
            Debug.Log("Ignoring first trigger");
            movePrefab++;
            return;
        }
        else
        {
            // Every subsequent trigger: move the trailing prefab to the front
            float newX = prefabCurrent.transform.position.x + prefabWidth;
            prefabNext.transform.position = new Vector2(newX, prefabNext.transform.position.y);

            // Swap so prefabCurrent always refers to the one ahead
            GameObject temp = prefabCurrent;
            prefabCurrent = prefabNext;
            prefabNext = temp;
            Debug.Log("MovePrefab " + movePrefab);
                        
            int choice = Random.Range(0, 4);
            Debug.Log("Choice"+movePrefab + " " + choice);

            if (movePrefab == 1) // Affects objects in Prefab 1
            {
                switch (choice)
                {
                    case 0:
                        FuelCan.SetActive(true);
                        Laser.SetActive(true);
                        break;

                    case 1:
                        FuelCan.SetActive(false);
                        Laser.SetActive(false);
                        break;

                    case 2:
                        FuelCan.SetActive(false);
                        Laser.SetActive(true);
                        break;

                    case 3:
                        FuelCan.SetActive(true);
                        Laser.SetActive(false);
                        break;
                }
            }
            movePrefab = (movePrefab % 2) + 1;
        }
    }
}