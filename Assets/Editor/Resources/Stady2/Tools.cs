using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System;

public class Tools : EditorWindow
{
    [MenuItem("Window/UIElements/Tools")]
    public static void ShowExample()
    {
        Tools wnd = GetWindow<Tools>();
        wnd.titleContent = new GUIContent("Tools");
    }

    public void OnEnable()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        //VisualElement label = new Label("Hello World! From C#");
        //root.Add(label);

        Action action = () =>
        {
            root.Query<Button>().ForEach((btn) =>
            {
                btn.text = btn.text.EndsWith("Button") ? "Button (Clicked)" : "Button";
            });
        };

        Button button = new Button();

        button.text = "Select and Move";

        button.RegisterCallback<MouseUpEvent>(evt => action());

        root.Add(button);

        //Rotation

        Button buttonRot = new Button();

        buttonRot.text = "Select and Rotation";

        //buttonRot.RegisterCallback<MouseUpEvent>(evt => action());

        root.Add(buttonRot);

        //Scale

        Button buttonScale = new Button();

        buttonScale.text = "Select and Rotation";

        //buttonScale.RegisterCallback<MouseUpEvent>(evt => action());

        buttonScale.clickable.clicked += OnClickButtonScale;

        root.Add(buttonScale);
    }

    private void OnClickButtonScale()
    {
        Debug.Log("Click to Button Scale");
    }
}