using System.Collections.Generic;

namespace CustomAdapter
{
    internal class CardItem
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public int ResId { get; set; }

        public static IList<CardItem> GenerateSampleCardItems()
        {
            return new[]
            {
                new CardItem
                {
                    ResId = Resource.Drawable.phone,
                    SubTitle = "Dial contact",
                    Title = "Phone"
                },
                new CardItem
                {
                    ResId = Resource.Drawable.book,
                    SubTitle = "Read book",
                    Title = "Library"
                },
                new CardItem
                {
                    ResId = Resource.Drawable.buzz,
                    SubTitle = "Send Message",
                    Title = "Chat"
                },
                new CardItem
                {
                    ResId = Resource.Drawable.calculator,
                    SubTitle = "Do your calculations. Scientific and programmer mode included",
                    Title = "Calculator"
                },
                new CardItem
                {
                    ResId = Resource.Drawable.calendar,
                    SubTitle = "Events and Birthdays",
                    Title = "Calendar"
                },
                new CardItem
                {
                    ResId = Resource.Drawable.music,
                    SubTitle = "Listen music",
                    Title = "Music Player"
                },
                new CardItem
                {
                    ResId = Resource.Drawable.sdk,
                    SubTitle = "Documentation",
                    Title = "SDK docs"
                },
                new CardItem
                {
                    ResId = Resource.Drawable.store,
                    SubTitle = "Search for new apps",
                    Title = "Android Market"
                },
                new CardItem
                {
                    ResId = Resource.Drawable.camera,
                    SubTitle = "Open camera",
                    Title = "Camera"
                },
                new CardItem
                {
                    ResId = Resource.Drawable.gallery,
                    SubTitle = "Open Gallery",
                    Title = "Gallery"
                },
                new CardItem
                {
                    ResId = Resource.Drawable.android,
                    SubTitle = "Share your apps",
                    Title = "Android Share"
                },
				new CardItem
				{
					ResId = Resource.Drawable.voice,
					SubTitle = "Open voice command",
					Title = "Voice Commands"
				},
				new CardItem
				{
					ResId = Resource.Drawable.maps,
					SubTitle = "Location and Maps",
					Title = "Location"
				},
				new CardItem
				{
					ResId = Resource.Drawable.news,
					SubTitle = "See latest News and Weather",
					Title = "News and Weather"
				},
				new CardItem
				{
					ResId = Resource.Drawable.twitter,
					SubTitle = "Tweet and read latest tweets",
					Title = "Twitter"
				}
            };
        }
    }
}