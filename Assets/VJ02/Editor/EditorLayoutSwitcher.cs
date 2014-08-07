using UnityEngine;
using UnityEditor;

public class EditorLayoutSwitcher : EditorWindow
{
    [MenuItem("Window/Layout Hotkeys/Edit #%1", false, 100)]
    static void Layout1()
    {
        EditorApplication.ExecuteMenuItem("Window/Layouts/Edit");
    }

    [MenuItem("Window/Layout Hotkeys/Reaktion #%2", false, 100)]
    static void Layout2()
    {
        EditorApplication.ExecuteMenuItem("Window/Layouts/Reaktion");
    }
}
