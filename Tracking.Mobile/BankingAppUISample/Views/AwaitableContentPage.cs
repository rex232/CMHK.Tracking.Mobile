using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrackingApp.Views
{

    public class AwaitableContentPage<T> : ContentPage
    {
        // Use this to wait on the page to be finished with/closed/dismissed
        public Task<T> PageClosedTask => tcs.Task;

        // Children classes should simply set this to the value being returned and pop async() 
        protected T PageResult { get; set; }

        private TaskCompletionSource<T> tcs { get; set; }

        public AwaitableContentPage()
        {
            tcs = new TaskCompletionSource<T>();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            tcs.SetResult(PageResult);
        }
    }

}