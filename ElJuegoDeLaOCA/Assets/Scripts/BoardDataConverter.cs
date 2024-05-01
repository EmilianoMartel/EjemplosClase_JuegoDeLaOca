using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardDataConverter
{
    private List<BoardRule> _boardRuleList = new();

    public List<BoardRule> BoardRules(BoardData data)
    {
        _boardRuleList.Clear();
        _boardRuleList.Add(new ThrowAgain(data.throwAgain));
        _boardRuleList.Add(new GoBackward(DictionaryConverter(data.keyBackward,data.valueBackward)));
        _boardRuleList.Add(new GoForward(DictionaryConverter(data.keyFoward, data.valueFoward)));
        _boardRuleList.Add(new LooseTurn(data.looseTurn));
        return _boardRuleList;
    }

    public Dictionary<int,int> DictionaryConverter(List<int> key, List<int> value)
    {
        Dictionary<int, int> temp = new();
        for (int i = 0; i < key.Count; i++)
        {
            temp.Add(key[i], value[i]);
        }
        return temp;
    }
}