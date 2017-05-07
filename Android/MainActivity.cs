using Android.App;
using Android.OS;
using Android.Widget;
using Domain.Entities;

namespace Android
{
    [Activity(Label = "Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
#pragma warning disable CS0436 // Conflitos de tipo com o tipo importado
            SetContentView(Resource.Layout.Main);
#pragma warning restore CS0436 // Conflitos de tipo com o tipo importado

            Button btnTest = ;

        }
    }
}

