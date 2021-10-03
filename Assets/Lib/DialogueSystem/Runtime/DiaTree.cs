using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class DiaTree : ScriptableObject
{
    public List<DiaNode> Tree = new List<DiaNode>();





    public void AddNode(DiaNode node)
    {
        if (!Tree.Contains(node))
        {
            Tree.Add(node);
            AssetDatabase.AddObjectToAsset(this, node);
            RefreshAsset();
        }
    }

    public void Remove(DiaNode node)
    {
        if (Tree.Contains(node))
        {
            Tree.Remove(node);
            AssetDatabase.RemoveObjectFromAsset(node);
            RefreshAsset();
        }
    }


    private void RefreshAsset()
    {
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
