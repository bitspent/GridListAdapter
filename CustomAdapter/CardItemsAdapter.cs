using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace CustomAdapter
{
    internal class CardItemsAdapter : BaseAdapter<CardItem>
    {
        private readonly IList<CardItem> _values;

        private readonly CardsViewMaker _gen;

        public CardItemsAdapter(Activity context, IList<CardItem> values)
        {
            _gen = new CardsViewMaker(context, values);
            _values = values;
        }

        public CardItemsAdapter(Activity context, int height, int spacing, IList<CardItem> values)
        {
            _gen = new CardsViewMaker(context, height, spacing, values);
            _values = values;
        }

        public override CardItem this[int position]
        {
            get { return _values[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _gen.GenerateView(position);

            _gen.ReSize(view, position);

            return view;
        }

        public override int Count
        {
            get
            {
                return _values.Count / 4 + (_values.Count % 4 == 0 ? 0 : 1);
            }
        }
    }
}