using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor.Experimental.GraphView;
using UnityEditor;

public class DiaGraphView : GraphView
{
    public new class UxmlFactory : UxmlFactory<DiaGraphView, VisualElement.UxmlTraits> { }

    public DiaGraphView()
    {
        Insert(0, new GridBackground());

        // Ìí¼Ó²Ù×ÝÆ÷
        this.AddManipulator(new ContentZoomer());
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Lib/DialogueSystem/Editor/DiaGraphView.uss");
        styleSheets.Add(styleSheet);
    }

}
