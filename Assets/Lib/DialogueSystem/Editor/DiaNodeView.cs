using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor.Experimental.GraphView;
using System;

public class DiaNodeView : UnityEditor.Experimental.GraphView.Node
{

    public Action<DiaNodeView> OnNodeSelected;

    public DiaNode node;
    public Port inputPort;
    public Port[] ouputPorts;

    public DiaNodeView(DiaNodeView node)
    {
           
    }

    private void CreateOutputPorts()
    {
        //if (node is ActionNode)
        //{

        //}
        //else if (node is DecoratorNode)
        //{
        //    outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
        //}
        //else if (node is CompositeNode)
        //{
        //    outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
        //}
        //else if (node is RootNode)
        //{
        //    outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
        //}

        //if (outputPort != null)
        //{
        //    outputPort.portName = "";
        //    outputContainer.Add(outputPort);
        //}
    }

    private void CreateInputPorts()
    {
        //if (node is ActionNode)
        //{
        //    inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
        //}
        //else if (node is DecoratorNode)
        //{
        //    inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
        //}
        //else if (node is CompositeNode)
        //{
        //    inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
        //}
        //else if (node is RootNode)
        //{

        //}

        //if (inputPort != null)
        //{
        //    inputPort.portName = "";
        //    inputContainer.Add(inputPort);
        //}
    }

    public override void SetPosition(Rect newPos)
    {
        base.SetPosition(newPos);
        node.position.x = newPos.xMin;
        node.position.y = newPos.yMin;
    }

    public override void OnSelected()
    {
        base.OnSelected();
        if (OnNodeSelected != null)
            OnNodeSelected.Invoke(this);
    }
}
