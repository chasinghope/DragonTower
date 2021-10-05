using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaNode : ScriptableObject
{
    [Header("节点关系")]
    public DiaNode FrontNode;
    public List<DiaOutput> Output = new List<DiaOutput>();


    [Header("节点内容")]
    public string Title = "Null";
    public Sprite Icon;
    public string Name;
    public DiaType Type = DiaType.None;
    [TextArea(10, 20)]
    public string Text;


    public bool IsOver => Output == null;
    public string Guid { get; internal set; }

    [HideInInspector]
    public Vector2 position = Vector2.one * 30;


}

[System.Serializable]
public class DiaOutput
{
    public string Descirbe;
    [TextArea]
    public string Answer;
    public DiaNode NextNode;
}