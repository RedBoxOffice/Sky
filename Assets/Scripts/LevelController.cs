using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;

    private void Awake()
    {
        _enemies = FindObjectsOfType<Enemy>();       
    }
    
    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {           
            enemy.Dying += LoadScene;
        }        
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Dying -= LoadScene;
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
