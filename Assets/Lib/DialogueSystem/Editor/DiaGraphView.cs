using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using System;
using UnityEngine;
using System.Linq;

public class DiaGraphView : GraphView
{
    public new class UxmlFactory : UxmlFactory<DiaGraphView, VisualElement.UxmlTraits> { }

    DiaTree diaTree;

    public Action<DiaNodeView> OnSelectedDiaNode;

    public DiaGraphView()
    {
        Insert(0, new GridBackground());

        // ��Ӳ�����
        this.AddManipulator(new ContentZoomer());
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());
        //this.AddManipulator(new ClickSelector());
        

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Lib/DialogueSystem/Editor/DiaGraphView.uss");
        styleSheets.Add(styleSheet);

        graphViewChanged = OnGraphViewChanged;

    }

    private GraphViewChange OnGraphViewChanged(GraphViewChange graphViewChange)
    {
        //ɾ��Ԫ��
        if(graphViewChange.elementsToRemove != null)
        {
            graphViewChange.elementsToRemove.ForEach((a) =>
            {
                DiaNodeView diaNodeView = a as DiaNodeView;
                if(diaNodeView != null)
                    diaTree.DeleteNode(diaNodeView.node);

                Edge edge = a as Edge;
                if(edge != null)
                {
                    DiaNodeView front = edge.output.node as DiaNodeView;
                    DiaNodeView next = edge.input.node as DiaNodeView;
                    if (front != null && next != null)
                        diaTree.Remove(front.node, next.node);
                }
            });
        }

        //��������
        if(graphViewChange.edgesToCreate != null)
        {
            graphViewChange.edgesToCreate.ForEach( edge =>
            {
                DiaNodeView front = edge.output.node as DiaNodeView;
                DiaNodeView next = edge.input.node as DiaNodeView;
                if(front != null && next != null)
                    diaTree.AddLink(front.node, next.node);
            });
        }

        return graphViewChange;
    }

    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        //return base.GetCompatiblePorts(startPort, nodeAdapter);
        return ports.ToList().Where(endPort =>
            endPort.direction != startPort.direction && endPort.node != startPort.node
        ).ToList();
    }




    public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
    {
        //evt.menu.AppendAction("��ӡ�ڵ���Ϣ", (a) => PrintPos(evt));
        evt.menu.AppendAction("��ӽڵ�", (a) => CreateNode());
        evt.menu.AppendAction("��Ӹ��ڵ�", (a)=>CreateRoot());
    }

    private void PrintPos(ContextualMenuPopulateEvent evt)
    {
        Debug.Log($"mousePosition   {evt.mousePosition.x}   {evt.mousePosition.y}");
        Debug.Log($"localMousePosition   {evt.localMousePosition.x}   {evt.localMousePosition.y}");
        Debug.Log($"mouseDelta   {evt.mouseDelta.x}   {evt.mouseDelta.y}");
    }

    public void PopulateView(DiaTree tree)
    {
        AssetDatabase.Refresh();
        this.diaTree = tree;
        graphElements.ForEach((a) => RemoveElement(a));

        diaTree.Tree.ForEach((a) => CreateNodeView(a));
        diaTree.Tree.ForEach(a =>{
            DiaNodeView front = FindNodeView(a);
            for (int i = 0; i < a.Output.Count; i++)
            {
                DiaNodeView next = FindNodeView(a.Output[i].NextNode);
                Edge edge = front.outputPorts[i].ConnectTo(next.inputPort);
                AddElement(edge);
            }
        });
    }


    DiaNodeView FindNodeView(DiaNode node)
    {
        return GetNodeByGuid(node.Guid) as DiaNodeView;
    }

    void CreateRoot()
    {
        var node = diaTree.CreateRoot();
        if (node)
        {
            CreateNodeView(node);
        }
    }

    void CreateNode()
    {
        var node =  diaTree.CreateNode();
        CreateNodeView(node);
    }

    void CreateNodeView(DiaNode node)
    {
        DiaNodeView nodeView = new DiaNodeView(node);
        nodeView.OnNodeSelected = OnSelectedDiaNode;
        AddElement(nodeView);
    }

    

}
