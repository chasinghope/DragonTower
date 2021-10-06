using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

[System.Serializable]
[CreateAssetMenu()]
public class DiaTree : ScriptableObject
{
    //public const string path = "Assets/Lib/DialogueSystem/NewDiaTree.assets";
    [HideInInspector]
    public DiaNode root;
    public List<DiaNode> Tree = new List<DiaNode>();

    /// <summary>
    /// �����Ի����ڵ�
    /// </summary>
    /// <returns></returns>
    public DiaNode CreateRoot()
    {
        if(root == null)
        {
            root = CreateInstance<DiaNode>();
            root.Title = "ROOT";
            root.name = "���ڵ�";
            //root.position = pos;
            root.Guid = GUID.Generate().ToString();
            Tree.Add(root);
            AssetDatabase.AddObjectToAsset(root, this);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return root;
        }
        else
        {
            return null;
        }
        
    }


    /// <summary>
    /// ����һ���Ի��ڵ�
    /// </summary>
    /// <returns></returns>
    public DiaNode CreateNode()
    {
        DiaNode node = ScriptableObject.CreateInstance<DiaNode>();
        node.Title = "NULL";
        node.name = "Node" + Tree.Count.ToString();
        //node.position = pos;
        node.Guid = GUID.Generate().ToString();
        Tree.Add(node);

        AssetDatabase.AddObjectToAsset(node, this);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        return node;
    }

    /// <summary>
    /// ɾ��һ���Ի��ڵ�
    /// </summary>
    /// <param name="node"></param>
    public void DeleteNode(DiaNode node)
    {
        Tree.Remove(node);
        if (node.Title == "ROOT")
            root = null;
        AssetDatabase.RemoveObjectFromAsset(node);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    public void Remove(DiaNode front, DiaNode next)
    {
        DiaOutput entity = front.Output.Find(a=>a.NextNode.Guid == next.Guid);
        front.Output.Remove(entity);
        next.FrontNode = null;
    }

    /// <summary>
    /// �������
    /// </summary>
    /// <param name="front">ǰ�ڵ�</param>
    /// <param name="next">��һ���ڵ�</param>
    public void AddLink(DiaNode front, DiaNode next)
    {
        front.Output.Add(new DiaOutput() { NextNode = next });
        next.FrontNode = front;
    }


    public void SaveTheTree()
    {
        EditorUtility.SetDirty(this);
        AssetDatabase.Refresh();
        Debug.Log($"{this.name} ����ɹ�");
    }
 
}
