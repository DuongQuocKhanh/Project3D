using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorLocomotion : MonoBehaviour
{
    
    private Animator playerAnmin;
    private Vector2 userInput;
    // Start is called before the first frame update
    void Start()
    {
        playerAnmin = GetComponent<Animator>();
       

    }

    // Update is called once per frame
    void Update()
    {
        userInput.x = Input.GetAxis("Horizontal"); 
        userInput.y = Input.GetAxis("Vertical");

        playerAnmin.SetFloat("InputX", userInput.x);
        playerAnmin.SetFloat("InputY", userInput.y);
       

    }
}
