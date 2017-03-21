using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CustomUiElements
{
    public class UiSideMenu : MonoBehaviour
    {
        [Tooltip("Do we keep the side menu available through all the app?")]
        public bool KeepMenu;

        [Tooltip("Event system for the side menu. Only needed if KeepMenu = true")]
        public GameObject EventSystem;

        [Tooltip("The actual panel that slides and contains the menu")]
        public RectTransform MenuParent;
        private bool m_MenuActive = false;

        [Tooltip("Speed with which the menu opens/closes")]
        public float MenuSpeed = 0.1f;

        [Tooltip("If the menu is persistent through all the app, we can have background music")]
        public AudioSource BackgroundMusic;

        [Tooltip("Icon for when music is playing")]
        public Sprite MuteIcon;

        [Tooltip("Icon for when music is paused")]
        public Sprite PlayIcon;

        [Tooltip("Button to Play/Pause music")]
        public Image SideMenuMute;
   
        [Tooltip("Big invisible button to close menu by tapping outside")]
        public GameObject MenuCloser;

        void Awake()
        {
            // Since the side menu and event system can be persistent through the app, we ensure to have only 1
            if (GameObject.FindObjectsOfType<EventSystem>().Length > 1)
            {
                Destroy(EventSystem);
            }

            if (GameObject.FindObjectsOfType<UiSideMenu>().Length > 1)
            {
                Destroy(gameObject);
            }
            else if (KeepMenu)
            {
                DontDestroyOnLoad(gameObject);   
            }
        }

        public void ToggleMenu()
        {
            if (m_MenuActive)
            {
                StartCoroutine(HideMenu());
                m_MenuActive = false;
            }
            else
            {
                StartCoroutine(ShowMenu());
                m_MenuActive = true;
            }
        }

        public void ForceHideMenu()
        {
            if (m_MenuActive)
            {
                StartCoroutine(HideMenu());
                m_MenuActive = false;
            }
        }

        private IEnumerator ShowMenu()
        {
            float y = MenuParent.position.y;
            float z = MenuParent.position.z;
            while (MenuParent.pivot.x > 0)
            {
                float newX = MenuParent.pivot.x - MenuSpeed;
                MenuParent.pivot = new Vector2(newX, 1);
                MenuParent.position = new Vector3(0, y, z);
                yield return null;
            }
            MenuParent.pivot = new Vector2(0, 1);
            MenuParent.position = new Vector3(0, y, z);
            MenuCloser.SetActive(true);
            yield break;
        }

        private IEnumerator HideMenu()
        {
            float y = MenuParent.position.y;
            float z = MenuParent.position.z;
            while (MenuParent.pivot.x < (1 - MenuSpeed))
            {
                float newX = MenuParent.pivot.x + MenuSpeed;
                MenuParent.pivot = new Vector2(newX, 1);
                MenuParent.position = new Vector3(0, y, z);
                yield return null;
            }
            MenuParent.pivot = new Vector2(1, 1);
            MenuParent.position = new Vector3(0, y, z);
            MenuCloser.SetActive(false);
            yield break;
        }

        public void ToggleBackgroundMusic()
        {
            if (BackgroundMusic != null)
            {
                if (BackgroundMusic.isPlaying)
                {
                    BackgroundMusic.Pause();
                    SideMenuMute.sprite = MuteIcon;
                }
                else
                {
                    BackgroundMusic.Play();
                    SideMenuMute.sprite = PlayIcon;
                }
            }
        }
     
        // Here you can add your custom logic, with what your side-menu buttons do:

        public void OpenScene(string name)
        {
            // This can be changed for LoadSceneAsync if needed
            SceneManager.LoadScene(name);
        }

        public void PrintToConsole(string text)
        {
            Debug.Log(text);
        }
    }
}