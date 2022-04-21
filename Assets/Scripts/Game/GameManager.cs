using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard};

   public Difficulty difficultySelected;
    public bool isSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected) Debug.Log(difficultySelected);
        
    }
}
