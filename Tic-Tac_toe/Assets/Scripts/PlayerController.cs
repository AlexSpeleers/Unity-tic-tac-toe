using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
   // [SerializeField]
    //List<GameObject> grid = new List<GameObject>();
    public float rayLenght;
    public LayerMask layerMask;
    public GameObject cross;
    public GameObject ring;
    int turn = 1;
    int[] grids = new int[9];

    void NextTurn()
    {
        turn += 1;
        if (turn == 3)
            turn = 1;
    }

    public void GridClicked(GameObject grid)
    {
        int gridNumber = grid.GetComponent<Counter>().gridNumber;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //переменная для ханения номера клетки
            int gridNumber = hit.transform.GetComponent<Counter>().gridNumber;
            
            //присваиваем номеру клетки номер игрока
            grids[gridNumber] = turn;

            if (Physics.Raycast(ray, out hit, rayLenght, layerMask))
            {
                if (turn == 1)
                    Instantiate(cross, hit.transform.position, Quaternion.identity);
                
                else
                    Instantiate(ring, hit.transform.position, Quaternion.Euler(90, 0, 0));

                NextTurn();
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
