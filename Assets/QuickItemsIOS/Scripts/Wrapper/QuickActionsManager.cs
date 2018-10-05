using System.Runtime.InteropServices;

namespace QuickActionsiOS
{
    public static class QuickActionsManager
    {
        #region Native Functions
        
        #if UNITY_IOS && !UNITY_EDITOR
        
        [DllImport ("__Internal")]
        public static extern int getNumberOfShortcuts();
        
        [DllImport ("__Internal")]
        public static extern string getCurrentItem();
        
        [DllImport ("__Internal")]
        public static extern string getItemAtIndex(int i);

        [DllImport ("__Internal")]
        public static extern bool removeItem(string itemType);

        [DllImport ("__Internal")]
        public static extern bool removeItemAtIndex(int i);
        
        [DllImport ("__Internal")]
        public static extern void setItem(string itemType, string localizedTitle, string localizedSubtitle,
            string customIconName, string builtinIconName);
        
        #endif

        #endregion
        
        #region C# Wrappers

        /// <summary>
        /// Get number of QuickActions in application which are
        /// available for user to activate
        /// </summary>
        /// <returns></returns>
        public static int GetNumberOfShortcuts()
        {
            #if UNITY_IOS && !UNITY_EDITOR
            return getNumberOfShortcuts();
            #endif
            return 0;
        }

        /// <summary>
        /// Get QuickAction which was triggered by user
        /// (which launched the app or moved it to foreground).
        /// This value will be reset to null in native part
        /// as soon as app will be moved to backgound.
        /// </summary>
        /// <returns></returns>
        public static QuickActionItem GetCurrentItem()
        {
            #if UNITY_IOS && !UNITY_EDITOR
            var nativeRepresentation = getCurrentItem();
            return nativeRepresentation.ToQuickActionItem();
            #endif
            return null;
        }

        /// <summary>
        /// Get QuickAction with given index from list
        /// of QuickActions already available for user to activate
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static QuickActionItem GetItemAtIndex(int i)
        {
            #if UNITY_IOS && !UNITY_EDITOR
            var nativeRepresentation = getItemAtIndex(i);
            return nativeRepresentation.ToQuickActionItem();
            #endif
            return null;
        }

        /// <summary>
        /// Remove QuickActionItem with given type from
        /// list of items available for user to activate.
        /// </summary>
        /// <param name="itemType">type of item to remove</param>
        /// <returns>success</returns>
        public static bool RemoveItem(string itemType)
        {
            if (string.IsNullOrEmpty(itemType)) return false;
            #if UNITY_IOS && !UNITY_EDITOR
            return removeItem(itemType);
            #endif
            return false;
        }
        
        /// <summary>
        /// Remove QuickActionItem from
        /// list of items available for user to activate.
        /// </summary>
        /// <param name="item">item to remove</param>
        /// <returns>success</returns>
        public static bool RemoveItem(QuickActionItem item)
        {
            if (item == null || string.IsNullOrEmpty(item.Type)) return false;
            #if UNITY_IOS && !UNITY_EDITOR
            return removeItem(item.Type);
            #endif
            return false;
        }

        /// <summary>
        /// Remove QuickActionItem with given index from list
        /// of items available for usr to activate.
        /// </summary>
        /// <param name="i">index in list</param>
        /// <returns>success</returns>
        public static bool RemoveItemAtIndex(int i)
        {
            #if UNITY_IOS && !UNITY_EDITOR
            return removeItemAtIndex(i);
            #endif
            return false;
        }

        /// <summary>
        /// Set new item available for user.
        /// </summary>
        /// <param name="itemType"></param>
        /// <param name="localizedTitle"></param>
        /// <param name="localizedSubtitle"></param>
        /// <param name="customIconName"></param>
        /// <param name="builtinIconName"></param>
        public static void SetItem(string itemType, string localizedTitle, string localizedSubtitle,
            string customIconName, string builtinIconName)
        {
            #if UNITY_IOS && !UNITY_EDITOR
            setItem(itemType, localizedTitle, localizedSubtitle, customIconName, builtinIconName);
            #endif
        }

        /// <summary>
        /// Set new item available for user.
        /// </summary>
        /// <param name="item"></param>
        public static void SetItem(QuickActionItem item)
        {
            #if UNITY_IOS && !UNITY_EDITOR
            setItem(item.Type, item.Title, item.Subtitle, item.CustomIconName, item.DefaultIcon.IconToString());
            #endif
        }
 
        #endregion
    }
}