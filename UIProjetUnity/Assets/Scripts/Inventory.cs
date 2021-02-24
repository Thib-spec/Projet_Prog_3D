using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Inventory : MonoBehaviour
    {
        
        // [SerializeField] private GameObject inventoryUI;
        // [SerializeField] private Button itemButton;
        public List<Item> content = new List<Item>();

        public static int contentCurrentIndex = 0;
       public Image itemImageUI;
       public TextMeshProUGUI itemNameUI;
       public TextMeshProUGUI itemDescriptionUI;


       private void Start()
       {
           UpdateInventoryUI();
       }

       void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                //inventoryUI.SetActive(!inventoryUI.activeSelf);
            }
        }
        public void ConsumeItem()
        {
            if (content.Count == 0)
            {
                return;
            }
            Item currentItem = content[contentCurrentIndex];
            Debug.Log(("ok"));
            content.Remove(currentItem);
            GetNextItem();
            UpdateInventoryUI();
        
        }

        public void GetNextItem()
        {
            if (content.Count == 0)
            {
                return;
            }
            contentCurrentIndex++;
            
            if (contentCurrentIndex > content.Count - 1)
            {

                contentCurrentIndex = 0;
            }
            
            UpdateInventoryUI();
            //Debug.Log(contentCurrentIndex);
        
        }
    
        public void GetPreviousItem()
        {
            if (content.Count == 0)
            {
                return;
            }
            contentCurrentIndex--;
            if (contentCurrentIndex < 0)
            {
                contentCurrentIndex = content.Count - 1;
            }
            UpdateInventoryUI();
        }

        public void UpdateInventoryUI()
        {
            if(content.Count > 0 )
            {
                itemImageUI.sprite = content[contentCurrentIndex].icon;
                itemNameUI.text = content[contentCurrentIndex].fullName;
                itemDescriptionUI.text = content[contentCurrentIndex].itemDescription;
            }
            else
            {
                //itemNameUI.text = "";
            }
        
        }
    }
}