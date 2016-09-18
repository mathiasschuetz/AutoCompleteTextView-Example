using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;

namespace AutofillEdittext
{
    [Activity(Label = "AutofillEdittext", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, View.IOnClickListener
    {
        #region fields

        private List<string> _database = new List<string> {"Biberach", "Berlin", "Stuttgart", "Ulm"};
            //SQL Database -> newest items first

        private ArrayAdapter<string> _arrayAdapter;

        #endregion

        #region properties

        private CustomAutoCompleteTextView AutoCompleteTextViewTextView { get; set; }

        #endregion

        #region lifecycle

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //View
            this.SetContentView(Resource.Layout.Main);

            //Items
            this.AutoCompleteTextViewTextView = this.FindViewById<CustomAutoCompleteTextView>(Resource.Id.myautocomplete);

            //Adapter
            this._arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line,
                this._database);
            this.AutoCompleteTextViewTextView.Adapter = this._arrayAdapter;

            //Events
            this.AutoCompleteTextViewTextView.EditorAction += this.SearchInSearchedItems;
            this.AutoCompleteTextViewTextView.FocusChange += (sender, args) =>
            {
                if (args.HasFocus)
                    this.AutoCompleteTextViewTextView.ShowDropDown();
            };
            this.AutoCompleteTextViewTextView.SetOnClickListener(this);
        }

        private void SearchInSearchedItems(object sender, TextView.EditorActionEventArgs editorActionEventArgs)
        {
            if (editorActionEventArgs.ActionId != ImeAction.Done)
                return;

            if (this._database.Any(f => f.Equals(this.AutoCompleteTextViewTextView.Text)))
                return;

            this._database.Add(this.AutoCompleteTextViewTextView.Text); //Add item to database
            this._database = this._database.OrderBy(f => f).ToList(); //Order by created date (newest one first)

            if (this._database.Count > 5)
                this._database = new List<string>(this._database.Take(5)); //Show only 5 items

            this._arrayAdapter.Clear();
            this._arrayAdapter.AddAll(this._database); //Update ArrayAdapter to see live change
            this._arrayAdapter.NotifyDataSetChanged();
        }

        #endregion

        #region methods

        #endregion

        #region IOnClickListener

        public void OnClick(View v)
        {
            if (v == this.AutoCompleteTextViewTextView)
                this.AutoCompleteTextViewTextView.ShowDropDown();
        }

        #endregion
    }
}