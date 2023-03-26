using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInstructions : MonoBehaviour
{
    [SerializeField] private Instructions _instruction;  

    private void Start()
    {
        _instruction.gameObject.SetActive(false);
    }

    private void Update()
    {
        ControlPressButtonF();
    }

    private void OnTriggerEnter(Collider other)
    {       
        Time.timeScale = 0;
        _instruction.gameObject.SetActive(true);        
    }   

    private void ControlPressButtonF()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _instruction.gameObject.SetActive(false);
            Time.timeScale = 1;            
        }        
    }
}
