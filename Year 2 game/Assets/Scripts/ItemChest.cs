﻿using UnityEngine;

public class ItemChest : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] int amount = 1;
    [SerializeField] Inventory inventory;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Color emptyColor;
    [SerializeField] KeyCode itemPickUpKeyCode = KeyCode.E;

    private bool isInRange;
    private bool isEmpty;

    [SerializeField] private AudioClip buttonClickSFX;
    

    private void OnValidate()
    {
        if (inventory == null)
            inventory = FindObjectOfType<Inventory>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.sprite = item.Icon;
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        if (isInRange && !isEmpty && Input.GetKeyDown(itemPickUpKeyCode))
        {
            Debug.Log("you have added stuff hopefully");
            SoundManager.Instance.PlaySFX(buttonClickSFX, 1);
            Item itemCopy = item.GetCopy();
            if (inventory.AddItem(itemCopy))
            {
                amount--;
                if (amount == 0)
                {
                    isEmpty = true;
                    spriteRenderer.color = emptyColor;
                }
            }
            else
            {
                itemCopy.Destroy();
            }
                        
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckCollision(other.gameObject, true);
    }

    private void OnTriggerExit(Collider other)
    {
        CheckCollision(other.gameObject, false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollision(collision.gameObject, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CheckCollision(collision.gameObject, false);
    }

    private void CheckCollision(GameObject gameObject, bool state)
    {
        if (gameObject.CompareTag("Player"))
        {
            isInRange = state;
            spriteRenderer.enabled = state;
        }
    }
}
