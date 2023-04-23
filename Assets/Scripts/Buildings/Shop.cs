using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shopUI = null;
    
    public void OnExitRange()
    {
        _shopUI.SetActive(false);
    }
    
    public void OnInteract()
    {
        Debug.Log($"INTERAGIU COM A LOJA");
        _shopUI.SetActive(true);
    }
}
