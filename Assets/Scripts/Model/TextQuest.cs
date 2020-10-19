using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TextQuest : ScriptableObject
{
    public string Name;
    public Sprite Image;
    [TextArea]
    public string Text;
    [NaughtyAttributes.ReorderableList]
    public QuestVariant[] Variants;

    public void Prepare()
    {
        //normalize probabilities
        foreach (var variant in Variants)
        {
            if (variant.Results.Length == 0)
                continue;
            var sum = variant.Results.Sum(r=>r.Probability);
        }
    }

    static System.Random rnd = new System.Random();

    public QuestResult OnPlayerSelectedVariant(QuestVariant variant)
    {
        if (variant.Results.Length == 0)
            return null;

        var sum = (float)variant.Results.Sum(r => r.Probability);

        try
        {
            var probs = variant.Results.Select(r => (float)r.Probability).ToList();
            var res = variant.Results.GetRnd(probs, rnd, sum);
            return res;
        }catch
        {
            return null;
        }
    }
}

[Serializable]
public class QuestVariant
{
    public QuestCondition Condition;
    [TextArea]
    public string Text;
    [NaughtyAttributes.ReorderableList]
    public QuestResult[] Results;
}

[Serializable]
public class QuestResult
{
    [InspectorName("Probability %")]
    [Range(0, 100)]
    public int Probability = 100;
    [TextArea]
    public string Text;
    public QuestAction Act;
}

[Serializable]
public enum QuestCondition
{
    None, CanThrowGrenade
}

[Serializable]
public enum QuestAction
{
    None = 0,
    SteamPackAdd2 = 1,
    StimulatorSub1 = 2,
    SoulSub1 = 3
}