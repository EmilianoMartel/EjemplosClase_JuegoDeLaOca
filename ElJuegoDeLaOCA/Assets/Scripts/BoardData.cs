using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Board Data", menuName = "BoarData")]
public class BoardData : ScriptableObject
{
    [SerializeField] private string _name;
    [Header("ThrowAgain")]
    [SerializeField] public int[] _throwAgain = null;
    [Header("GoFoward")]
    [SerializeField] public List<int> _keyFoward = new();
    [SerializeField] public List<int> _valueFoward = new();
    [Header("GoBackward")]
    [SerializeField] public List<int> _keyBackward = new();
    [SerializeField] public List<int> _valueBackward = new();
    [Header("LooseTurn")]
    [SerializeField] public int[] _looseTurn = null;

    public string nameData { get { return _name; } }
    public int[] throwAgain { get { return _throwAgain; } }
    public List<int> keyFoward { get { return _keyFoward; } }
    public List<int> valueFoward { get { return _valueFoward; } }
    public List<int> keyBackward { get { return _keyBackward; } }
    public List<int> valueBackward { get { return _valueBackward; } }
    public int[] looseTurn { get { return _looseTurn; } }
}