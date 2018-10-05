namespace QuickActionsiOS
{
	public class QuickActionItem
	{
		#region Public Variables
		
		/// <summary>
		/// Name of your action. It's good practice to write it 
		/// in reversed dns style.
		/// Example: com.MyCoolApp.MyCoolAction
		/// Required Field.
		/// </summary>
		public string Type;
		
		/// <summary>
		/// Text description, what user will see. It's length
		/// may be about 20 characters. You may set more than 20,
		/// but it will be cut by iOS and added ... instead.
		/// Required Field
		/// </summary>
		public string Title;
		
		/// <summary>
		/// Small text description, which user will see under Title.
		/// Font is smaller.
		/// Optional Field.
		/// </summary>
		public string Subtitle;
		
		/// <summary>
		/// Name of file with the icon, including file extension
		/// Example: "myCoolIcon.png"
		/// Optional field. If no custom icon specified - default icon will
		/// be used instead. If no default icon will be set - default system
		/// icon ( o ) will be set by iOS itself.
		/// Optional Field.
		/// </summary>
		public string CustomIconName;
		
		/// <summary>
		/// Type of build-in icon.
		/// Optional field. If no custom icon specified - default icon will
		/// be used instead. If no default icon will be set - default system
		/// icon ( o ) will be set by iOS itself.
		/// Optional Field.
		/// </summary>
		public QuickActionDefaultIcon DefaultIcon;
		
		#endregion
		
		#region ctors

		private QuickActionItem() { }
		private QuickActionItem(string type) { }
	
		public QuickActionItem(string type, string title) 
			: this(type, title, null, null)
		{}

		public QuickActionItem(string type, string title, string subtitle)
			: this(type, title, subtitle, null, QuickActionDefaultIcon.None)
		{}

		public QuickActionItem(string type, 
							   string title, 
							   string subtitle = null, 
							   string customIconName = null,
							   QuickActionDefaultIcon defaultIcon = QuickActionDefaultIcon.None)
		{
			Type = type;
			Title = title;
			Subtitle = subtitle;
			CustomIconName = customIconName;
			DefaultIcon = defaultIcon;
		}
		
		#endregion

	}
}