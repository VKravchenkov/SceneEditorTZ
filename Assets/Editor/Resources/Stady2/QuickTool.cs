using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System;
using System.Collections.Generic;

public class QuickTool : EditorWindow
{
    [MenuItem("Window/UIElements/QuickTool")]
    public static void ShowExample()
    {
        QuickTool wnd = GetWindow<QuickTool>();
        wnd.titleContent = new GUIContent("QuickTool");
    }

    public void OnEnable()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/Resources/Stady2/QuickTool.uxml");
        VisualElement labelFromUXML = visualTree.CloneTree();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/Resources/Stady2/QuickTool.uss");
        root.styleSheets.Add(styleSheet);

        UQueryBuilder<Image> uQueryBuilder = rootVisualElement.Query<Image>();
        uQueryBuilder.ForEach(SetupImage);
    }

    private void SetupImage(Image obj)
    {
        GameObject go = AssetDatabase.LoadAssetAtPath<GameObject>($"Assets/Prefabs/Interactables/{obj.parent.name}.prefab");

        VisualElement visualElement = obj.Q(className: "quicktool-image-icon");

        string iconPath = $"Icons/{obj.parent.name}-icon";

        Texture2D texture2D = Resources.Load<Texture2D>(iconPath);

        visualElement.style.backgroundImage = texture2D;

        Label label = (Label)obj.Q(className: "quicktool-label");

        label.text = obj.parent.name;

        visualElement.RegisterCallback<MouseDownEvent>(evt =>
        {
            DragAndDrop.PrepareStartDrag();
            DragAndDrop.StartDrag("Dragging");
            DragAndDrop.objectReferences = new UnityEngine.Object[] { go };
        });

        visualElement.RegisterCallback<DragUpdatedEvent>(evt =>
        {
            DragAndDrop.visualMode = DragAndDropVisualMode.Move;
        });
    }
}