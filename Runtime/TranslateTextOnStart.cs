using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Group3d.Localization
{
    public class TranslateTextOnStart : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField] private string translationKey;
#pragma warning restore CS0649

        private Text textComponent;
        private TMP_Text tmpTextComponent;
        private bool hasText;
        private bool hasTmpText;

        private void Awake()
        {
            textComponent = GetComponent<Text>();
            tmpTextComponent = GetComponent<TMP_Text>();

            hasText = textComponent != null;
            hasTmpText = tmpTextComponent != null;

            if (hasText || hasTmpText)
            {
                if (hasText) textComponent.text = "";
                if (hasTmpText) tmpTextComponent.text = "";
            }
            else
            {
                Debug.LogWarning("No text component found, skipping translation", gameObject);
            }
        }

        private IEnumerator Start()
        {
            if (string.IsNullOrWhiteSpace(translationKey))
            {
                Debug.LogError("Forgot to set localization key?", this);
            }
            else if (hasText || hasTmpText)
            {
                yield return Localization.WaitUntilReady();
                TranslateText();
            }
        }

        public void TranslateText()
        {
            var translation = Localization.Translate(translationKey);
            if (translation != null)
            {
                if (hasText) textComponent.text = translation;
                if (hasTmpText) tmpTextComponent.text = translation;
            }
        }
    }
}
