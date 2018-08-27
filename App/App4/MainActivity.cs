using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using System.Threading;
using Android.Content;
using Android.Views;
using Android.Support.Design.Widget;
using App4.Services;
using App4.Activities;
using System;

namespace App4
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btnLogin,btnRegister;
        private ProgressBar pgrLogin;
        private TextInputLayout passwordLayout;
        private TextInputEditText passwordView;

        private TextInputLayout emailLayout;
        private TextInputEditText emailView;
        private View rootView;
        private ISharedPreferences session;
        private UsersService _usersService = new UsersService();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            rootView = FindViewById<View>(Android.Resource.Id.Content);
            SetContentView(Resource.Layout.activity_main);

            passwordView = FindViewById<TextInputEditText>(Resource.Id.txtPassword);
            passwordLayout = FindViewById<TextInputLayout>(Resource.Id.password_layout);

            btnLogin = FindViewById<Button>(Resource.Id.btnIngresar);

            emailView = FindViewById<TextInputEditText>(Resource.Id.txtEmail);
            emailLayout = FindViewById<TextInputLayout>(Resource.Id.email_layout);
            pgrLogin = FindViewById<ProgressBar>(Resource.Id.pgrLogin);
            btnRegister = FindViewById<Button>(Resource.Id.btnCrear);
            btnLogin.Click += BtnLoginClick;
            btnRegister.Click += BtnRegisterClick;

            emailView.Text = "i1520761@continental.edu.pe";
            passwordView.Text = "abc123++";
            session = GetSharedPreferences("SessionLogin", FileCreationMode.Private);
        }
        private void BtnLoginClick(object sender,System.EventArgs e)
        {
            /*
            var connection = _usersService.CheckConnection();
            if (!connection.Result.IsSuccess)
            {
                Toast.MakeText(this, "No tiene conexion a internet", ToastLength.Long).Show();
                return;
            }
            */

            bool isValid = ValidateEmail()&&ValidatePassword();
            if (isValid)
            {
                pgrLogin.Visibility = ViewStates.Visible;
                var users = _usersService.GetUsersAutentication(emailView.Text, passwordView.Text);
                if (users != null)
                {
                    ISharedPreferencesEditor sessionEditor = NewMethod();
                    sessionEditor.PutString("SessionName", users.pNombres);
                    sessionEditor.PutString("SessionId", Convert.ToString(users.id));
                    sessionEditor.PutString("SessionUserName", users.pUsuario);
                    sessionEditor.PutString("SessionCorreo", users.pCorreoE);
                    sessionEditor.Commit();
                    Toast.MakeText(this, "Bienvenido " + users.pUsuario, ToastLength.Long).Show();
                    pgrLogin.Visibility = ViewStates.Invisible;

                    Intent newActivity = new Intent(this, typeof(Activities.MenuPrincipal));
                    Finish();
                    StartActivity(newActivity);

                }
                else
                {

                    Toast.MakeText(this, "Clave incorrecta", ToastLength.Long).Show();
                    pgrLogin.Visibility = ViewStates.Invisible;

                    return;
                }
            }
            else
            {
                Toast.MakeText(this,Resource.String.enter_required_fields_thank_you, ToastLength.Long).Show();
                return;
            }
        }

        private ISharedPreferencesEditor NewMethod()
        {
            return session.Edit();
        }

        private void BtnRegisterClick(object sende, System.EventArgs e)
        {
            Intent newActivity = new Intent(this, typeof(registerLogin));
            Finish();
            StartActivity(newActivity);
        }
        bool ValidatePassword()
        {
            if (string.IsNullOrWhiteSpace(passwordView.Text))
            {
                Toast.MakeText(this, "Debe ingresar una contraseña", ToastLength.Long).Show();
                passwordLayout.ErrorEnabled = true;
                passwordLayout.Error = GetString(Resource.String.password_required_error_message);
                return false;
            }
            else
            {
                return true;
            }
        }
        bool ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(emailView.Text))
            {
                Toast.MakeText(this, "Debe ingresar un correo", ToastLength.Long).Show();
                emailLayout.ErrorEnabled = true;
                emailLayout.Error = GetString(Resource.String.email_required_error_message);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

