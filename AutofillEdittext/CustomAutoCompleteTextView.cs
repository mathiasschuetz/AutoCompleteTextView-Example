using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;

namespace AutofillEdittext
{
    public class CustomAutoCompleteTextView : AutoCompleteTextView
    {
        public CustomAutoCompleteTextView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public CustomAutoCompleteTextView(Context context) : base(context)
        {
        }

        public CustomAutoCompleteTextView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public CustomAutoCompleteTextView(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
        }

        public CustomAutoCompleteTextView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        public override bool EnoughToFilter()
        {
            return true; //Show suggestions always
        }
    }
}