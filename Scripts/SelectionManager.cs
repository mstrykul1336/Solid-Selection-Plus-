﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    private IRayProvider _rayProvider;
    private ISelectionResponse _selectionResponse;
    private ISelector _selector;
    private Transform _currentSelection;
    private Transform _selection;

    private void Awake()
    {
        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
        _selectionResponse = GetComponent<ISelectionResponse>();
        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }

    private void Update()
    {
        if (_currentSelection != null) _selectionResponse.OnDeselect(_currentSelection);
    
        _selector.Check(_rayProvider.CreateRay());
        _currentSelection = _selector.GetSelection();

        if (_currentSelection != null) _selectionResponse.OnSelect(_currentSelection);

    } 

}