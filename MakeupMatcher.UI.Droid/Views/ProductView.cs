﻿using System;   
//using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MakeupMatcher.Core.Repositories;
using MakeupMatcher.Core.Models;

using Android.App;
using Java.IO;
using Android.Graphics;
using Com.Airbnb.Lottie;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
//using SQLite.Net;
//using SQLite.Net.Platform.XamarinAndroid;
using MakeupMatcher.Core.ViewModels;
using MakeupMatcher.UI.Droid.DroidServices;
using SQLite;
using Android.Provider;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;

namespace MakeupMatcher.UI.Droid.Views
{
    [Activity(Label = "ProductView")]
    public class ProductView : MvxActivity<ProductViewModel>
    {
        private RecyclerView mRecyclerView;
        private RecyclerView.LayoutManager mLayoutManager;
        private ProductAdapter mAdapter;
        private ProductModel _productModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _productModel = new ProductModel();

            SetContentView(Resource.Layout.Product);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            //mRecyclerView.AddOnItemTouchListener();

            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            mAdapter = new ProductAdapter(_productModel);
            //mAdapter.ItemClick += OnItemClick;
            mRecyclerView.SetAdapter(mAdapter);

        }

        /*void OnItemClick(object sender, int position)
        {
            var activity = new Intent(this, typeof(ProductDetailView));
                activity.PutExtra("Name", "Test123");
                activity.PutExtra("Brand", "Test123");
            }*/
        }
    }
