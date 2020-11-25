using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] GameObject characterPanel;
    [SerializeField] GameObject playerHud;
    [SerializeField] KeyCode[] toggleInventoryKeys;

    [SerializeField] private AudioClip buttonClickSFX;
    
   
    void Update()
    {
        for (int i = 0; i < toggleInventoryKeys.Length; i++)
        {
            if (Input.GetKeyDown(toggleInventoryKeys[i]))
            {
                SoundManager.Instance.PlaySFX(buttonClickSFX, 1);

                characterPanel.SetActive(!characterPanel.activeSelf);
                playerHud.SetActive(!characterPanel.activeSelf);

                if (characterPanel.activeSelf)
                {
                    ShowMouseCursor();
                }
                else
                {
                    HideMouseCursor();
                }

                break;
            }
        }
    }

    public void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
