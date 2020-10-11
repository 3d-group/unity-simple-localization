using UnityEditor;
using UnityEngine;

namespace Group3d.Localization
{
    public class LocalizationEditorExtensions
    {
        [MenuItem("GameObject/Localization", false, 10)]
        public static void CreateLocalizationGameObject(MenuCommand menuCommand)
        {
            var gameObject = new GameObject("Localization");
            gameObject.AddComponent<Localization>();

            var parent = menuCommand.context as GameObject;
            GameObjectUtility.SetParentAndAlign(gameObject, parent);

            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(gameObject, "Create " + gameObject.name);
            
            Selection.activeObject = gameObject;
        }

        [MenuItem("GameObject/UI/Text - Localized", false)]
        public static void CreateLocalizedTextGameObject(MenuCommand menuCommand)
        {
            var gameObject = new GameObject("Text");
            gameObject.AddComponent<LocalizedText>();

            var parent = menuCommand.context as GameObject;
            GameObjectUtility.SetParentAndAlign(gameObject, parent);

            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(gameObject, "Create " + gameObject.name);

            Selection.activeObject = gameObject;
        }
    }
}
