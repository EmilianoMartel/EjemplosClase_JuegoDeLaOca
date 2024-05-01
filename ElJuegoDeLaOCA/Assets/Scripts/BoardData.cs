using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Board Data", menuName = "BoarData")]
public class BoardData : ScriptableObject
{
    [Header("ThrowAgain")]
    [SerializeField] public int[] throwAgain = null;
    [Header("GoFoward")]
    [SerializeField] public List<int> keyFoward = new();
    [SerializeField] public List<int> valueFoward = new();
    [Header("GoBackward")]
    [SerializeField] public List<int> keyBackward = new();
    [SerializeField] public List<int> valueBackward = new();
    [Header("LooseTurn")]
    [SerializeField] public int[] looseTrun = null;
}