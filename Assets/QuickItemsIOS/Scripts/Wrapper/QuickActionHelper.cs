using System;

namespace QuickActionsiOS
{
	/// <summary>
	/// Enum, representing apple built-in icons for QuickActions
	/// ---
	/// Author: Vladislav Chartanovich
	/// Date: 2 october 2018
	/// </summary>
	public enum QuickActionDefaultIcon
	{
		None,
		Compose,
		Play,
		Pause,
		Add,
		Location,
		Search,
		Share,
		Prohibit,
		Contact,
		Home,
		MarkLocation,
		Favorite,
		Love,
		Cloud,
		Invitation,
		Confirmation,
		Mail,
		Message,
		Date,
		Time,
		Photo,
		Video,
		Task,
		TaskCompleted,
		Alarm,
		Bookmark,
		Shuffle,
		Audio,
		Update
	}

	/// <summary>
	/// Helper methods to convert QuiActionDefaultIcon to String and vice versa.
	/// </summary>
	public static class QuickActionsExtension
	{
		private const string EmptyField = "_";

		public static QuickActionItem ToQuickActionItem(this string nativeRepresentation)
		{
			if (string.IsNullOrEmpty(nativeRepresentation)) return null;
			var itemParts = nativeRepresentation.Split(' ');
			if (itemParts.Length < 2) return null;
			if (string.Equals(itemParts[0], EmptyField) || string.Equals(itemParts[1], EmptyField)) return null;
			string subtitle = null;
			if (itemParts.Length >= 3)
				subtitle = string.Equals(itemParts[2], EmptyField) ? null : itemParts[2];
			return new QuickActionItem(itemParts[0], itemParts[1], subtitle);
		}
		
		public static string IconToString(this QuickActionDefaultIcon icon)
		{
			switch (icon)
			{
				case QuickActionDefaultIcon.None: return "";
				case QuickActionDefaultIcon.Compose: return "compose";
				case QuickActionDefaultIcon.Play: return "play";
				case QuickActionDefaultIcon.Pause: return "pause";
				case QuickActionDefaultIcon.Add: return "add";
				case QuickActionDefaultIcon.Location: return "location";
				case QuickActionDefaultIcon.Search: return "search";
				case QuickActionDefaultIcon.Share: return "share";
				case QuickActionDefaultIcon.Prohibit: return "prohibit";
				case QuickActionDefaultIcon.Contact: return "contact";
				case QuickActionDefaultIcon.Home: return "home";
				case QuickActionDefaultIcon.MarkLocation: return "markLocation";
				case QuickActionDefaultIcon.Favorite: return "favorite";
				case QuickActionDefaultIcon.Love: return "love";
				case QuickActionDefaultIcon.Cloud: return "cloud";
				case QuickActionDefaultIcon.Invitation: return "invitation";
				case QuickActionDefaultIcon.Confirmation: return "confirmation";
				case QuickActionDefaultIcon.Mail: return "mail";
				case QuickActionDefaultIcon.Message: return "message";
				case QuickActionDefaultIcon.Date: return "date";
				case QuickActionDefaultIcon.Time: return "time";
				case QuickActionDefaultIcon.Photo: return "photo";
				case QuickActionDefaultIcon.Video: return "video";
				case QuickActionDefaultIcon.Task: return "task";
				case QuickActionDefaultIcon.TaskCompleted: return "taslCompleted";
				case QuickActionDefaultIcon.Alarm: return "alarm";
				case QuickActionDefaultIcon.Bookmark: return "bookmark";
				case QuickActionDefaultIcon.Shuffle: return "shuffle";
				case QuickActionDefaultIcon.Audio: return "audio";
				case QuickActionDefaultIcon.Update: return "update";
				default:
					throw new ArgumentOutOfRangeException(nameof(icon), icon, null);
			}

		}
		
		public static QuickActionDefaultIcon ToQuickActionIcon(this string name)
		{
			if (name == null) return QuickActionDefaultIcon.None;

			if (string.Equals(name, "compose")) return QuickActionDefaultIcon.Compose;
			if (string.Equals(name, "play")) return QuickActionDefaultIcon.Play;
			if (string.Equals(name, "pause")) return QuickActionDefaultIcon.Pause;
			if (string.Equals(name, "add")) return QuickActionDefaultIcon.Add;
			if (string.Equals(name, "location")) return QuickActionDefaultIcon.Location;
			if (string.Equals(name, "search")) return QuickActionDefaultIcon.Search;
			if (string.Equals(name, "share")) return QuickActionDefaultIcon.Share;
			if (string.Equals(name, "prohibit")) return QuickActionDefaultIcon.Prohibit;
			if (string.Equals(name, "contact")) return QuickActionDefaultIcon.Compose;
			if (string.Equals(name, "home")) return QuickActionDefaultIcon.Home;
			if (string.Equals(name, "marklocation")) return QuickActionDefaultIcon.MarkLocation;
			if (string.Equals(name, "favorite")) return QuickActionDefaultIcon.Favorite;
			if (string.Equals(name, "love")) return QuickActionDefaultIcon.Love;
			if (string.Equals(name, "cloud")) return QuickActionDefaultIcon.Cloud;
			if (string.Equals(name, "invitation")) return QuickActionDefaultIcon.Invitation;
			if (string.Equals(name, "confirmation")) return QuickActionDefaultIcon.Confirmation;
			if (string.Equals(name, "mail")) return QuickActionDefaultIcon.Mail;
			if (string.Equals(name, "message")) return QuickActionDefaultIcon.Message;
			if (string.Equals(name, "date")) return QuickActionDefaultIcon.Date;
			if (string.Equals(name, "time")) return QuickActionDefaultIcon.Time;
			if (string.Equals(name, "photo")) return QuickActionDefaultIcon.Photo;
			if (string.Equals(name, "video")) return QuickActionDefaultIcon.Video;
			if (string.Equals(name, "task")) return QuickActionDefaultIcon.Task;
			if (string.Equals(name, "taskCompleted")) return QuickActionDefaultIcon.TaskCompleted;
			if (string.Equals(name, "alarm")) return QuickActionDefaultIcon.Alarm;
			if (string.Equals(name, "bookmark")) return QuickActionDefaultIcon.Bookmark;
			if (string.Equals(name, "shuffle")) return QuickActionDefaultIcon.Shuffle;
			if (string.Equals(name, "audio")) return QuickActionDefaultIcon.Audio;
			if (string.Equals(name, "update")) return QuickActionDefaultIcon.Update;
			return QuickActionDefaultIcon.None;
		}
	}
}