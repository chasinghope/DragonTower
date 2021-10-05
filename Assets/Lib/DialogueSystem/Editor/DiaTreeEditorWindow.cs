using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class DiaTreeEditorWindow : EditorWindow
{
    DiaGraphView diaGraphView;
    DiaInspectorView diaInspectorView;
    ToolbarMenu toolBarMenu;

    [MenuItem("Window/DiaTreeEditorWindow")]
    public static void ShowExample()
    {
        DiaTreeEditorWindow wnd = GetWindow<DiaTreeEditorWindow>();
        wnd.titleContent = new GUIContent("DiaTreeEditorWindow");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Lib/DialogueSystem/Editor/DiaTreeEditorWindow.uxml");
        visualTree.CloneTree(root);

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Lib/DialogueSystem/Editor/DiaTreeEditorWindow.uss");
        root.styleSheets.Add(styleSheet);

        toolBarMenu = root.Q<ToolbarMenu>();
        diaGraphView = root.Q<DiaGraphView>();
        diaInspectorView = root.Q<DiaInspectorView>();

        toolBarMenu.menu.AppendAction("Refresh", (a) => OnSelectionChange());                                                  
        diaGraphView.OnSelectedDiaNode = diaInspectorView.UpdateSelection;
    }


    private void OnSelectionChange()
    {
        DiaTree tree = Selection.activeObject as DiaTree;
        if (tree)
        {
            diaGraphView.PopulateView(tree);
        }
    }
}