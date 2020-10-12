using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Group3d.Localization
{
    public class TranslateTextOnStart : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField] private string localizationKey;
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
                TranslateText();
            }
            else
            {
                Debug.LogWarning("No text component found, skipping translation", gameObject);
            }
        }

#if DEBUG
        private void Start()
        {
            if (string.IsNullOrWhiteSpace(localizationKey)) Debug.LogError("Forgot to set localization key?", this);
        }
#endif

        public void TranslateText()
        {
            var translation = Localization.Translate(localizationKey);
            if (translation != null)
            {
                if (hasText) textComponent.text = translation;
                if (hasTmpText) tmpTextComponent.text = translation;
            }
        }
    }
}
