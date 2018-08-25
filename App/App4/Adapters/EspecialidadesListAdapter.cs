using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using App4.Models;
using App4.Services;
using Square.Picasso;

namespace App4.Adapters
{
    public class EspecialidadesListAdapter
    {
        public void SetUpRecyclerView(RecyclerView recyclerView, List<Especialidades> _especialidades, Resources res)
        {
            var values = _especialidades;
            recyclerView.SetLayoutManager(new LinearLayoutManager(recyclerView.Context));

            recyclerView.SetAdapter(new SimpleStringRecyclerViewAdapter(recyclerView.Context, values,res));
        }
        public class SimpleStringRecyclerViewAdapter : RecyclerView.Adapter
        {
            private readonly TypedValue mTypedValue = new TypedValue();
            private int mBackground;
            private List<Especialidades> mValues;
            Resources mResource;
            private Dictionary<int, int> mCalculatedSizes;

            public SimpleStringRecyclerViewAdapter(Context context, List<Especialidades> items, Resources res)
            {
                context.Theme.ResolveAttribute(Resource.Attribute.selectableItemBackground, mTypedValue, true);
                mBackground = mTypedValue.ResourceId;
                mValues = items;
                mResource = res;

                mCalculatedSizes = new Dictionary<int, int>();
            }

            public override int ItemCount
            {
                get
                {
                    return mValues.Count;
                }
            }

            public override async void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                var simpleHolder = holder as SimpleViewHolder;
                simpleHolder.mTxtView.Text = mValues[position].Name;

            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.List_Item, parent, false);
                view.SetBackgroundResource(mBackground);

                return new SimpleViewHolder(view);
            }
        }

        public class SimpleViewHolder : RecyclerView.ViewHolder
        {
            public string mBoundString;
            public readonly View mView;
            public readonly ImageView mImageView;
            public readonly TextView mTxtView;

            public SimpleViewHolder(View view) : base(view)
            {
                mView = view;
                //mImageView = view.FindViewById<ImageView>(Resource.Id.avatar);
                mTxtView = view.FindViewById<TextView>(Resource.Id.textName);
            }

            public override string ToString()
            {
                return base.ToString() + " '" + mTxtView.Text;
            }
        }
    }
}