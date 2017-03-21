using UnityEngine;
using UnityEngine.UI;

namespace CustomUiElements
{
    public class ImageCarousel : MonoBehaviour
    {
        [Tooltip("The different images to show in the carousel")]
        public Sprite[] Sprites;
        private Image currentImage;
        private int index;

        void Awake()
        {
            currentImage = GetComponent<Image>();

            if (Sprites.Length > 0)
            {
                currentImage.sprite = Sprites[0];
            }
        }

        public void NextImage()
        {
            index = (index + 1) % Sprites.Length;
            currentImage.sprite = Sprites[index];
        }

        public void PreviousImage()
        {
            index = (index == 0) ? Sprites.Length - 1 : (index - 1) % Sprites.Length;
            currentImage.sprite = Sprites[index];
        }
    }
}