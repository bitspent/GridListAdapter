using Android.App;
using Android.OS;
using Android.Widget;

namespace CustomAdapter
{
    [Activity(Label = "CustomAdapter", MainLauncher = true)]
    public class MainActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ListAdapter = new CardItemsAdapter(this, CardItem.GenerateSampleCardItems());

            ListView.DividerHeight = 0;

            ListView.SetBackgroundColor(Android.Graphics.Color.ParseColor("#FFE5E5E5"));
        }

        public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            int height = WindowManager.DefaultDisplay.Height;

            if (item.ItemId == Resource.Id.menu_small)
                ListAdapter = new CardItemsAdapter(this, height / 3, 50, CardItem.GenerateSampleCardItems());
            if (item.ItemId == Resource.Id.menu_medium)
                ListAdapter = new CardItemsAdapter(this, height / 2, 100, CardItem.GenerateSampleCardItems());
            if (item.ItemId == Resource.Id.menu_default)
                ListAdapter = new CardItemsAdapter(this, CardItem.GenerateSampleCardItems());
            if (item.ItemId == Resource.Id.menuabout)
                Toast.MakeText(this, "== F.Aro ==", ToastLength.Short).Show();

            return base.OnOptionsItemSelected(item);
        }
    }
}