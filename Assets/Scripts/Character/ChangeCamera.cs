using UnityEngine;

[RequireComponent(typeof(Flying))]
public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Camera _aimCamera;    
    
    private Flying _flying;    

    private void Start()
    {
        _flying = GetComponent<Flying>();        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && _flying.enabled == true)
        {
            
            _mainCamera.gameObject.SetActive(false);
            _aimCamera.gameObject.SetActive(true);            
        }
        else if (Input.GetMouseButtonUp(1))
        {
            _mainCamera.gameObject.SetActive(true);
            _aimCamera.gameObject.SetActive(false);            
        }        
    }    
}
