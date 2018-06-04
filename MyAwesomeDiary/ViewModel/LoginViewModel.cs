using MyAwesomeDiary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyAwesomeDiary.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public MainWindow MainWD { get; set; }
        public IEnumerable<Nation> LstNation;
        public ICommand LoginCommand { get; set; }
        public ICommand ToSignUpViewCommand { get; set; }
        public ICommand ToSignInViewCommand { get; set; }
        public ICommand SignUpCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand ToForgetPasswordViewCommand { get; set; }
        public ICommand ToSignInFromForgetpwCommand { get; set; }
        public LoginViewModel()
        {
            using (var db = new MyContext())
            {
                LstNation = db.Nations.ToList();
            }
            LoginCommand = new RelayCommand<UserControl>(p => { return true; }, p =>
            {
                if (p is SignInView si)
                {
                    PasswordSecurityProvider psp = new PasswordSecurityProvider();
                    if (psp.Validate(si.txtUserName.Text, si.pwSignIn.Password))
                    {
                        User toGet;
                        using (var db = new MyContext())
                        {
                            toGet = db.Users.Find(si.txtUserName.Text);
                        }
                        FrameworkElement fe = GetWindow(p);
                        (fe as LoginView).Visibility = Visibility.Hidden;
                        MainWD = new MainWindow(toGet, fe as LoginView);
                        MainWD.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                    }
                }
            });
            SignUpCommand = new RelayCommand<UserControl>(p => { return true; }, p =>
            {
                if (p is SignUpView su)
                {
                    User result = PasswordSecurityProvider.Find(su.txtUserName.Text);
                    if (result == null)
                    {
                        PasswordSecurityProvider psp = new PasswordSecurityProvider();
                        string hashedpassword = psp.GetHashPassword(su.pwSignUp.Password);

                        if (su.dpSignUp.SelectedDate == null)
                        {

                            MessageBox.Show("Bạn phải nhập ngày tháng");
                        }
                        else
                        {
                            var ToAdd = new User
                            {
                                UserID = su.txtUserName.Text,
                                Password = hashedpassword,
                                BirthDate = (DateTime)su.dpSignUp.SelectedDate,
                                NationID = su.cbNation.SelectedIndex + 1,
                                PrivateAnswer = su.txtAns.Text
                            };
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    db.Users.Add(ToAdd);
                                    db.SaveChanges();
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Đăng ký thất bại");
                                }
                            }
                            MessageBox.Show("Đăng ký Thành công");
                        }
                    }
                    else
                    {

                        MessageBox.Show("Đã tồn tại UserID này");
                    }
                    

                }
            });

            ToSignUpViewCommand = new RelayCommand<UserControl>(p => { return true; }, p =>
            {
                try
                {
                    FrameworkElement fe = GetWindow(p);
                    (fe as LoginView).uCSignIn.Visibility = Visibility.Hidden;
                    (fe as LoginView).uCSignUp.Visibility = Visibility.Visible;
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.StackTrace.ToString());
                    return;
                }
            });
            ToSignInViewCommand = new RelayCommand<UserControl>(p => { return true; }, p =>
            {
                try
                {
                    FrameworkElement fe = GetWindow(p);
                    (fe as LoginView).uCSignUp.Visibility = Visibility.Hidden;
                    (fe as LoginView).uCSignIn.Visibility = Visibility.Visible;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.StackTrace.ToString());
                    return;
                }
            });
            ToForgetPasswordViewCommand = new RelayCommand<UserControl>(p => { return true; }, p =>
            {
                try
                {
                    FrameworkElement fe = GetWindow(p);
                    //(fe as LoginView).uCSignUp.Visibility = Visibility.Hidden;
                    (fe as LoginView).uCSignIn.Visibility = Visibility.Hidden;
                    (fe as LoginView).ucForgetpw.Visibility = Visibility.Visible;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.StackTrace.ToString());
                    return;
                }
            });
            ToSignInFromForgetpwCommand = new RelayCommand<UserControl>(p => { return true; }, p =>
            {
                try
                {
                    FrameworkElement fe = GetWindow(p);                    
                    (fe as LoginView).uCSignIn.Visibility = Visibility.Visible;
                    (fe as LoginView).ucForgetpw.Visibility = Visibility.Hidden;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.StackTrace.ToString());
                    return;
                }
            });

            ChangePasswordCommand = new RelayCommand<UserControl>(p => { return true; }, p =>
            {

                if (p is ForgetPasswordView view)
                {
                    using (var db = new MyContext())
                    {
                        var tmp = db.Users.Find(view.txtAccount.Text);
                        if (tmp == null)
                        {
                            MessageBox.Show("Tài khoản không tồn tại");
                            RemoveField(view);
                        }
                        else
                        {
                            if (tmp.PrivateAnswer.CompareTo(view.txtAns.Text) != 0)
                            {

                                MessageBox.Show("Sai câu trả lời bảo mật");
                                RemoveField(view);
                            }
                            else
                            {
                                if (view.txtNewPass.Password.CompareTo(view.txtConfirmPass.Password) != 0)
                                {

                                    MessageBox.Show("Mật khẩu mới không khớp");
                                }
                                else
                                {
                                    string hashpass = new PasswordSecurityProvider().GetHashPassword(view.txtConfirmPass.Password);
                                    tmp.Password = hashpass;
                                    db.SaveChanges();

                                    MessageBox.Show("Đổi mật khẩu thành công");
                                    RemoveField(view);
                                }
                            }
                        }
                    }
                }
            });

        }      
        //-------------------------------------------
        private void RemoveField(ForgetPasswordView view)
        {
            view.txtAccount.Text = "";
            view.txtAns.Text = "";
            view.txtNewPass.Password = "";
            view.txtConfirmPass.Password = "";
        }
        private FrameworkElement GetWindow(UserControl p)
        {
            if (p is FrameworkElement fe)
            {
                while (fe.Parent != null)
                    fe = fe.Parent as FrameworkElement;
                return fe;
            }
            return null;
        }
    }    
}
