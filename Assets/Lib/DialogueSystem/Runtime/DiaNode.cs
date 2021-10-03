using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DiaNode : ScriptableObject
{
    [Header("节点关系")]
    public DiaNode FrontNode;
    public DiaOutput[] Output;


    [Header("节点内容")]
    public Sprite Icon;
    public DiaType Type = DiaType.None;
    [TextArea(10, 20)]
    public string Text;


    public bool IsOver => Output == null;

    [HideInInspector]
    public Vector2 position;
}

[System.Serializable]
public class DiaOutput
{
    public string Descirbe;
    [TextArea]
    public string Answer;
    public DiaNode NextNode;
}