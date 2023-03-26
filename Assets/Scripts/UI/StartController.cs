using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartController : MonoBehaviour
{
    [SerializeField] private UIStartPanel _startPanel;  

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player) && other.TryGetComponent(out AudioSource audio))
        {
            DisableStartPanel();
            audio.Play();             
        }
    }

    private void DisableStartPanel()
    {
        _startPanel.gameObject.SetActive(false);        
    }    
}
