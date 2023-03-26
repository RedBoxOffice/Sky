using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEndGame : MonoBehaviour
{
    [SerializeField] private Instructions _instruction;

    private void Start()
    {
        _instruction.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Invoke(nameof(ShowMenu), 1.5f);
        }
    }

    private void ShowMenu()
    {
        _instruction.gameObject.SetActive(true);
    }
}
