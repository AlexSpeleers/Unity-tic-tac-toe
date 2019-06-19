using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int gridNumber = 0;
        
    private void OnMouseDown() => GameObject.Find("Main Camera").GetComponent<PlayerController>().SendMessage("GridClicked", gameObject);
    
}
