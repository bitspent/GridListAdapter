using Android.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomAdapter
{
    internal class CardsViewMaker
    {
        private static readonly Random _gen = new Random();

        private readonly Activity _context;

        private readonly IList<CardItem> _items;

        public CardsViewMaker(Activity context, IList<CardItem> items)
        {
            _context = context;
            _items = items;
            Pad = 80;
            DefaultHeight = _context.WindowManager.DefaultDisplay.Width;
        }

        public CardsViewMaker(Activity context, int height, int pad, IList<CardItem> items)
        {
            Pad = pad;
            DefaultHeight = height;

            _items = items;
            _context = context;
        }

        public int Pad { get; private set; }

        public int DefaultHeight { get; private set; }

        public View GenerateView(int position)
        {
            var inflater = _context.LayoutInflater;

            var rootView = new LinearLayout(_context)
            {
                Orientation = Orientation.Horizontal
            };

            var rootParams = new AbsListView.LayoutParams(ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.WrapContent);

            rootView.LayoutParameters = rootParams;

            var card1 = (LinearLayout)inflater.Inflate(Resource.Layout.CardItem, null);
            var card2 = (LinearLayout)inflater.Inflate(Resource.Layout.CardItem, null);
            var card3 = (LinearLayout)inflater.Inflate(Resource.Layout.CardItem, null);
            var card4 = (LinearLayout)inflater.Inflate(Resource.Layout.CardItem, null);

            card1.Id = 1;
            card2.Id = 2;
            card3.Id = 3;
            card4.Id = 4;

            var leftView = new LinearLayout(_context)
            {
                Orientation = Orientation.Vertical
            };

            var leftParams = new AbsListView.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            leftView.LayoutParameters = leftParams;

            leftView.AddView(card1);
            leftView.AddView(card2);

            var rightView = new LinearLayout(_context)
            {
                Orientation = Orientation.Vertical
            };

            var rightParams = new AbsListView.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);

            rightView.LayoutParameters = rightParams;

            rightView.AddView(card3);
            rightView.AddView(card4);

            rootView.AddView(leftView);
            rootView.AddView(rightView);

            rootView.SetBackgroundColor(Android.Graphics.Color.ParseColor("#FFE5E5E5"));

            return rootView;
        }

        public void ReSize(View view, int position)
        {
            if (_sizes.ContainsKey(position))
            {
                var gens = _sizes[position].Split(' ').Select(int.Parse);
                var enumerable = gens as int[] ?? gens.ToArray();
                SetSize(view, enumerable.ElementAt(0), enumerable.ElementAt(1));
            }
            else
            {
                var leftrnd = _gen.Next(30, 70);
                var rightrnd = _gen.Next(30, 70);
                SetSize(view, leftrnd, rightrnd);
                _sizes.Add(position, string.Format("{0} {1}", leftrnd, rightrnd));
            }

            var id = 4 * position;

            SetViewInfo(view, 1, id);
            SetViewInfo(view, 3, id + 1);
            SetViewInfo(view, 2, id + 2);
            SetViewInfo(view, 4, id + 3);
        }

        private void SetViewInfo(View view, int id, int position)
        {
            if (position >= _items.Count)
                view.FindViewById(id).Visibility = ViewStates.Invisible;
            else
            {
                var card = _items[position];
                view.FindViewById(id).FindViewById<TextView>(Resource.Id.card_title).Text = card.Title;
                view.FindViewById(id).FindViewById<TextView>(Resource.Id.card_subtitle).Text = card.SubTitle;
                view.FindViewById(id).FindViewById<ImageView>(Resource.Id.card_logo).SetImageResource(card.ResId);
                view.FindViewById(id).Visibility = ViewStates.Visible;
            }
        }

        private readonly Dictionary<int, string> _sizes = new Dictionary<int, string>();

        public void SetSize(View view, int leftRand, int rightRand)
        {
            var width = _context.WindowManager.DefaultDisplay.Width;

            var card1 = view.FindViewById<LinearLayout>(1);
            var card2 = view.FindViewById<LinearLayout>(2);
            var card3 = view.FindViewById<LinearLayout>(3);
            var card4 = view.FindViewById<LinearLayout>(4);

            var bh = DefaultHeight + Pad;

            var bh1 = (int)(bh * leftRand / 100.0f - Pad / 2.0f);
            var bh2 = (int)(bh * (1 - leftRand / 100.0f) - Pad / 2.0f);

            var params1 = new LinearLayout.LayoutParams(width / 2 - 3 * Pad / 4, bh1);
            var params2 = new LinearLayout.LayoutParams(width / 2 - 3 * Pad / 4, bh2);

            bh1 = (int)(bh * rightRand / 100.0f - Pad / 2.0f);
            bh2 = (int)(bh * (1 - rightRand / 100.0f) - Pad / 2.0f);

            var params3 = new LinearLayout.LayoutParams(width / 2 - 3 * Pad / 4, bh1);
            var params4 = new LinearLayout.LayoutParams(width / 2 - 3 * Pad / 4, bh2);

            params1.SetMargins(Pad / 2, Pad / 4, 0, Pad / 4);
            params2.SetMargins(Pad / 2, Pad / 4, 0, 0);

            params3.SetMargins(Pad / 2, Pad / 2, 0, Pad / 4);
            params4.SetMargins(Pad / 2, Pad / 4, 0, 0);

            card1.LayoutParameters = params1;
            card2.LayoutParameters = params2;
            card3.LayoutParameters = params3;
            card4.LayoutParameters = params4;
        }
    }
}