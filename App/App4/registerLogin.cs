using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using App4.Data;
using App4.Models;
namespace App4
{
    [Activity(Label = "registerLogin")]
    public class registerLogin : Activity
    {
        private LinearLayout layautRegister;
        private TextInputLayout passwordLayout;
        private TextInputEditText passwordView;
        private TextInputLayout emailLayout;
        private TextInputEditText emailView;
        private TextInputLayout usernameLayout;
        private TextInputEditText usernameView;
        private TextInputLayout nameLayout;
        private TextInputEditText nameView;
        private TextInputLayout firstSurnameLayout;
        private TextInputEditText firstSurnameView;
        private TextInputLayout secondSurnameLayout;
        private TextInputEditText secondSurnameView;
        private TextInputLayout passwordConfirmLayout;
        private TextInputEditText passworConfirmdView;

        private TextInputLayout DNILayout;
        private TextInputEditText DNIView;
        
        private Button btnRegister;
        private Button btnLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register);
            layautRegister = FindViewById< LinearLayout > (Resource.Id.layaut_register);

            emailView = FindViewById<TextInputEditText>(Resource.Id.txtEmail);
            emailLayout = FindViewById<TextInputLayout>(Resource.Id.email_layout);

            passworConfirmdView = FindViewById<TextInputEditText>(Resource.Id.txtPasswordConfirm);
            passwordConfirmLayout = FindViewById<TextInputLayout>(Resource.Id.passwordConfirm_layout);

            passwordView = FindViewById<TextInputEditText>(Resource.Id.txtPassword);
            passwordLayout = FindViewById<TextInputLayout>(Resource.Id.password_layout);

            usernameView = FindViewById<TextInputEditText>(Resource.Id.txtUserName);
            usernameLayout = FindViewById<TextInputLayout>(Resource.Id.username_layout);

            nameView = FindViewById<TextInputEditText>(Resource.Id.txtName);
            nameLayout = FindViewById<TextInputLayout>(Resource.Id.name_layout);

            firstSurnameView = FindViewById<TextInputEditText>(Resource.Id.txtFirstSurname);
            firstSurnameLayout = FindViewById<TextInputLayout>(Resource.Id.firstSurname_layout);

            secondSurnameView = FindViewById<TextInputEditText>(Resource.Id.txtSecondSurname);
            secondSurnameLayout = FindViewById<TextInputLayout>(Resource.Id.secondSurname_layout);

            DNIView = FindViewById<TextInputEditText>(Resource.Id.txtDNI);
            DNILayout = FindViewById<TextInputLayout>(Resource.Id.dni_layout);

            btnRegister = FindViewById<Button>(Resource.Id.btnRegistrar);
            btnLogin = FindViewById<Button>(Resource.Id.btnIngresar);
            // Create your application here
            btnRegister.Click += (s, e) =>
            {
                bool isValid = ValidateUserName() && ValidateName() && ValidateApellidoP() && ValidateApellidoM() && ValidateDNI() && ValidateEmail() && ValidatePassword() && ValidatePasswordConfirm();
                if (isValid)
                {

                    new DataConnection(this, "setUser", nameView.Text, usernameView.Text, firstSurnameView.Text, secondSurnameView.Text,DNIView.Text, emailView.Text , passwordView.Text);
                }
                else
                {

                }
            };
            btnLogin.Click += (s, e) =>
            {
                Intent newActivity = new Intent(this, typeof(MainActivity));
                Finish();
                StartActivity(newActivity);
            };
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
                if (passwordView.Text!=passworConfirmdView.Text)
                {
                    Toast.MakeText(this, "Contraseña no coincide", ToastLength.Long).Show();
                    passwordConfirmLayout.ErrorEnabled = true;
                    passwordConfirmLayout.Error = "Contraseña no coincide";
                    return false;
                }
                else
                {
                    passwordLayout.ErrorEnabled = true;
                    passwordConfirmLayout.ErrorEnabled = false;
                    return true;
                }
            }
        }
        bool ValidatePasswordConfirm()
        {
            if (string.IsNullOrWhiteSpace(passworConfirmdView.Text))
            {
                Toast.MakeText(this, "Debe ingresar una contraseña para confirmar", ToastLength.Long).Show();
                passwordConfirmLayout.ErrorEnabled = true;
                passwordConfirmLayout.Error = GetString(Resource.String.password_required_error_message);
                return false;
            }
            else
            {
                passwordConfirmLayout.ErrorEnabled = false;
                return true;
            }
        }
        bool ValidateApellidoP()
        {
            if (string.IsNullOrWhiteSpace(firstSurnameView.Text))
            {
                Toast.MakeText(this, "Debe ingresar apellido paterno", ToastLength.Long).Show();
                firstSurnameLayout.ErrorEnabled = true;
                firstSurnameLayout.Error = GetString(Resource.String.password_required_error_message);
                return false;
            }
            else
            {
                firstSurnameLayout.ErrorEnabled = false;
                return true;
            }
        }
        bool ValidateApellidoM()
        {
            if (string.IsNullOrWhiteSpace(secondSurnameView.Text))
            {
                Toast.MakeText(this, "Debe ingresar apellido materno", ToastLength.Long).Show();
                secondSurnameLayout.ErrorEnabled = true;
                secondSurnameLayout.Error = GetString(Resource.String.password_required_error_message);
                return false;
            }
            else
            {
                secondSurnameLayout.ErrorEnabled = false;
                return true;
            }
        }
        bool ValidateDNI()
        {
            if (string.IsNullOrWhiteSpace(DNIView.Text))
            {
                Toast.MakeText(this, "Debe ingresar un dni", ToastLength.Long).Show();
                DNILayout.ErrorEnabled = true;
                DNILayout.Error = GetString(Resource.String.password_required_error_message);
                return false;
            }
            else
            {
                DNILayout.ErrorEnabled = false;
                return true;
            }
        }
        bool ValidateName()
        {
            if (string.IsNullOrWhiteSpace(nameView.Text))
            {
                Toast.MakeText(this, "Debe ingresar un nombre", ToastLength.Long).Show();
                nameLayout.ErrorEnabled = true;
                nameLayout.Error = GetString(Resource.String.password_required_error_message);
                return false;
            }
            else
            {
                nameLayout.ErrorEnabled = false;
                return true;
            }
        }
        bool ValidateUserName()
        {
            if (string.IsNullOrWhiteSpace(usernameView.Text))
            {
                Toast.MakeText(this, "Debes ingresar un usuario", ToastLength.Long).Show();
                usernameLayout.ErrorEnabled = true;
                usernameLayout.Error = GetString(Resource.String.password_required_error_message);
                return false;
            }
            else
            {
                usernameLayout.ErrorEnabled = false;
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
                emailLayout.ErrorEnabled = false;
                return true;
            }
        }
    }
}