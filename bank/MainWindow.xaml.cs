using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bank
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BankAccount bankAccount;
        public MainWindow()
        {
            InitializeComponent();
        }

            private void CreateAccount_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    var accountNumber = AccountNumberTextBox.Text;
                    var openingDate = OpeningDatePicker.SelectedDate ?? DateTime.Now;
                    var ownerFullName = OwnerFullNameTextBox.Text;
                    var ownerPassport = OwnerPassportTextBox.Text;
                    var ownerDOB = OwnerDOBPicker.SelectedDate ?? DateTime.Now;
                    var initialBalance = decimal.Parse(InitialBalanceTextBox.Text);
                    var depositTerm = int.Parse(DepositTermTextBox.Text);

                    var client = new Class1(ownerFullName, ownerPassport, ownerDOB);
                    bankAccount = new BankAccount(accountNumber, openingDate, client, initialBalance, depositTerm);

                    StatusTextBlock.Text = $"Счет создан! Статус: {bankAccount.GetDepositEndDate()}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }



