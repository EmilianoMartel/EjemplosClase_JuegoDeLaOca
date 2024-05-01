using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private List<BoardData> _boardData = new();
    [SerializeField] private TMP_Dropdown _dropDown;
    [SerializeField] private Button _button;

    public Action<BoardData> sendData = delegate { };

    private void OnEnable()
    {
        _button.onClick.AddListener(HandleButton);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(HandleButton);
    }

    private void Awake()
    {
        List<TMP_Dropdown.OptionData> temp = new();
        for (int i = 0; i < _boardData.Count; i++)
        {
            temp.Add(new TMP_Dropdown.OptionData(_boardData[i].nameData, null));
        }
        _dropDown.AddOptions(temp);
    }

    private void HandleButton()
    {
        sendData?.Invoke(_boardData[_dropDown.value]);
        gameObject.SetActive(false);
    }
}
