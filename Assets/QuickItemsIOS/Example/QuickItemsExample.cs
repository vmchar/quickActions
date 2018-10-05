using QuickActionsiOS;
using UnityEngine;
using UnityEngine.UI;

public class QuickItemsExample : MonoBehaviour
{
	public Text CurrentItemLabel;
	public Text NumberOfItemsText;
	public Text ZeroItem;
	
	private void Start()
	{
		var currentItem = QuickActionsManager.GetCurrentItem();
		if (currentItem == null) CurrentItemLabel.text = "No item";
		else CurrentItemLabel.text = currentItem.Type;
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		//app returned from background - checking for item
		if (pauseStatus == false)
		{
			var currentItem = QuickActionsManager.GetCurrentItem();
			if (currentItem == null) CurrentItemLabel.text = "No item ";
			else CurrentItemLabel.text = currentItem.Type + "  " + currentItem.Title + "  " + currentItem.Subtitle;
		}
	}

	public void OnGetNumberOfItems()
	{
		var numberOfItem = QuickActionsManager.GetNumberOfShortcuts();
		NumberOfItemsText.text = string.Format("" + numberOfItem);
	}
	
	public void OnGetItem()
	{
		var numberOfItems = QuickActionsManager.GetNumberOfShortcuts();
		if (numberOfItems == 0) ZeroItem.text = "No item";
		var zeroItem = QuickActionsManager.GetCurrentItem();
		if (zeroItem == null) ZeroItem.text = "No item";
		else ZeroItem.text = zeroItem.Type + "  " + zeroItem.Title + "  " + zeroItem.Subtitle;
	}

	public void OnSetItemWithCustomIcon()
	{
		var item = new QuickActionItem("com.testapp.testaction", "test action Unity", "test subtitle", "testIcon.png");
		QuickActionsManager.SetItem(item);
	}
	
	public void OnSetItemWithDefaultIcon()
	{
		var item = new QuickActionItem("com.testapp.testactionDefault", "action test Unity", "test subtitle", "", QuickActionDefaultIcon.Home);
		QuickActionsManager.SetItem(item);
	}

	public void RemoveZeroItem()
	{
		QuickActionsManager.RemoveItemAtIndex(0);
	}
	
}

