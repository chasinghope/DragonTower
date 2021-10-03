using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class DiaTreeEditorWindow : EditorWindow
{
    [MenuItem("Window/UI Toolkit/DiaTreeEditorWindow")]
    public static void ShowExample()
    {
        DiaTreeEditorWindow wnd = GetWindow<DiaTreeEditorWindow>();
        wnd.titleContent = new GUIContent("DiaTreeEditorWindow");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

   

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Lib/DialogueSystem/Editor/DiaTreeEditorWindow.uxml");

        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Lib/DialogueSystem/Editor/DiaTreeEditorWindow.uss");
        VisualElement labelWithStyle = new Label("Hello World! With Style");
        labelWithStyle.styleSheets.Add(styleSheet);
        root.Add(labelWithStyle);
    }
}