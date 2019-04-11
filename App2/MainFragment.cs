using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace App2
{
    public class MainFragment : Fragment, View.IOnClickListener
    {
        EditText etQuestion;
        RadioGroup radioGroupColor;
        RadioGroup radioGroupPrice;
        public static MainFragment newInstance()
        {
            return new MainFragment(); ;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            var view = inflater.Inflate(Resource.Layout.main_fragment, container, false);

            etQuestion = view.FindViewById<EditText>(Resource.Id.et_question);
            radioGroupColor = view.FindViewById<RadioGroup>(Resource.Id.rg_color);
            radioGroupPrice = view.FindViewById<RadioGroup>(Resource.Id.rg_price);



            EditText editText = view.FindViewById<EditText>(Resource.Id.et_question);
            Button btnContinue = view.FindViewById<Button>(Resource.Id.btn_continue);
            btnContinue.SetOnClickListener(this);
            return view;
        }
        public void OnClick(View v)
        {
            switch (v.Id)
            {
                case Resource.Id.btn_continue:

                    int selectedIdColor = radioGroupColor.CheckedRadioButtonId;
                    int selectedIdPrice = radioGroupPrice.CheckedRadioButtonId;
                    RadioButton radioButtonColor = radioGroupColor.FindViewById<RadioButton>(selectedIdColor);
                    RadioButton radioButtonPrice = radioGroupPrice.FindViewById<RadioButton>(selectedIdPrice);
                    string text = radioButtonColor.Text + " flower, which costs " + radioButtonPrice.Text;
                    DependFragment dependFragment = DependFragment.newInstance($"{etQuestion.Text.ToString()} ({text})");
                    FragmentTransaction transaction = this.FragmentManager.BeginTransaction();
                    transaction.Replace(Resource.Id.container, dependFragment);
                    etQuestion.Text = "";
                    transaction.AddToBackStack(null);
                    transaction.Commit();
                    break;
            }
        }
    }
}