using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Gms.Common.Apis.GoogleApiClient;
using Android.Gms.Plus;
using Android.Gms.Common.Apis;
using Android.Gms.Common;


namespace Droid.Demo
{
    [Activity(Label = "S57_MAPS", MainLauncher = true, Icon = "@drawable/globe")]
    
    public class MainActivity : Activity, IConnectionCallbacks, IOnConnectionFailedListener
    
    {
        private  GoogleApiClient mGoogleApiClient;
        private SignInButton mGoogleSignIn;
        private Button MapsButton;
        private Button logOutButton;

        private ConnectionResult mConnectionResult;

        private bool mIntentInProgress;
        private bool mSigneInClicked;
        private bool logOutButtonClicked;
     


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            mGoogleSignIn = FindViewById<SignInButton>(Resource.Id.sign_in_button);
          
            MapsButton = FindViewById<Button>(Resource.Id.button1);

            logOutButton = FindViewById<Button>(Resource.Id.logout_button);

            mGoogleSignIn.Click += mGoogleSignIn_Click;
            logOutButton.Click += logOutButton_Click;

            GoogleApiClient.Builder builder = new GoogleApiClient.Builder(this);
            builder.AddConnectionCallbacks(this);
            builder.AddOnConnectionFailedListener(this);
            builder.AddApi(PlusClass.API);
            builder.AddScope(PlusClass.ScopePlusProfile);
            builder.AddScope(PlusClass.ScopePlusLogin);


            MapsButton.Visibility = ViewStates.Gone;
            MapsButton.Click += (sender, e) =>
            {
                StartActivity(typeof(MyActivity));
            };
          

            //Build our IGoogleApiClient
            mGoogleApiClient = builder.Build();
              

        }
        void mGoogleSignIn_Click(object sender, EventArgs e)
        {

           //Fire sign in
           if (!mGoogleApiClient.IsConnecting)
            {
                mSigneInClicked = true;
                ResolveSignInError();
            }

        }

        void logOutButton_Click(object sender, EventArgs e)
        {
            //Fire sign out
            if (mGoogleApiClient.IsConnected)


            
            mGoogleApiClient.Disconnect();
            MapsButton.Visibility = ViewStates.Gone;
            Toast.MakeText(this, "Disconnected successfuly!", ToastLength.Long).Show();
            logOutButtonClicked = true;
               

        }

        private void ResolveSignInError()
        {
            
            if (mGoogleApiClient.IsConnected)
            {
                //No need to resolve errors, already connected
                return;
            }

                    
            
                        if (mConnectionResult.HasResolution)
                {
                    try
                    {
                        mIntentInProgress = true;
                        StartIntentSenderForResult(mConnectionResult.Resolution.IntentSender, 0, null, 0, 0, 0);
                    }

                    catch (Android.Content.IntentSender.SendIntentException)
                    {
                        //The intent was cancelled before it was sent. Return to the default
                        //state and attempt to connect to get an updated ConnectionResult
                        mIntentInProgress = false;
                        mGoogleApiClient.Connect();
                    }
                }            

            

       
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            
            if (requestCode == 0)
            {
                
                if (resultCode != Result.Ok)
                {
                    mSigneInClicked = false;
                }

                mIntentInProgress = false;
                if (!mGoogleApiClient.IsConnecting)
                {
                    mGoogleApiClient.Connect();
                }

                  
            }
                
        }

        protected override void OnStart()
        {
            base.OnStart();
            
            mGoogleApiClient.Connect();
        }

        protected override void OnStop()
        {
            base.OnStop();
            if (mGoogleApiClient.IsConnected)

                mGoogleApiClient.Disconnect();            
        }

        public void OnConnected(Bundle connectionHint)
        {   // We are logged in, hooray!!
            mSigneInClicked = false;
            Toast.MakeText(this, "Connected successfuly!", ToastLength.Long).Show();



            MapsButton.Visibility = ViewStates.Visible;
             
        }


        public void OnDisconnected()
        {
            Toast.MakeText(this, "Disconnected successfuly!", ToastLength.Long).Show();
        }


        public void OnConnectionFailed(ConnectionResult result)
        {
            if (!mIntentInProgress)
            {
                //Store the connection result so that we can use it later when the user clicks sign-in.
                mConnectionResult = result;

            }
            if (mSigneInClicked)
            {
                //The user has already clicked 'sign-in' so we attempt to resolve all
                //errors until the user is signed in, or the cancel
                ResolveSignInError();
            }
            Toast.MakeText(this, "Connection Failed!", ToastLength.Long).Show();
        }

        public void OnConnectionSuspended(int cause)
        {
            throw new NotImplementedException();
        }



       
    }
}