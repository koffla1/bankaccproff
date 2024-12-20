using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    using System;
        /// <summary>
        /// Класс, представляющий банковский счет.
        /// </summary>
        public class BankAccount
        {
            private string accountNumber;
            private DateTime openingDate;
            private Class1 owner;
            private decimal balance;
            private int depositTerm; // Срок вклада в днях
            private string status; // Статус: открыт, закрыт, банкрот

            /// <summary>
            /// Конструктор по умолчанию.
            /// </summary>
        public BankAccount()
            {
                status = "открыт";
                balance = 0;
                openingDate = DateTime.Now;
            }

            /// <summary>
            /// Конструктор с параметрами.
            /// </summary>
            /// <param name="accountNumber">Номер счета.</param>
            /// <param name="openingDate">Дата открытия счета.</param>
            /// <param name="owner">Владелец счета.</param>
            /// <param name="initialBalance">Начальный баланс.</param>
            /// <param name="depositTerm">Срок вклада в днях.</param>
            public BankAccount(string accountNumber, DateTime openingDate, Class1 owner, decimal initialBalance, int depositTerm)
            {
                this.accountNumber = accountNumber;
                this.openingDate = openingDate;
                this.owner = owner;
                this.balance = initialBalance;
                this.depositTerm = depositTerm;
                status = "открыт";
            }

            /// <summary>
            /// Метод для пополнения счета.
            /// </summary>
            /// <param name="amount">Сумма для пополнения.</param>
            public void Deposit(decimal amount)
            {
                if (amount > 0)
                {
                    balance += amount;
                    UpdateStatus();
                }
                else
                {
                    throw new ArgumentException("Сумма пополнения должна быть положительной.");
                }
            }

            /// <summary>
            /// Метод для снятия средств со счета.
            /// </summary>
            /// <param name="amount">Сумма для снятия.</param>
            public void Withdraw(decimal amount)
            {
                if (amount > 0 && amount <= balance)
                {
                    balance -= amount;
                    UpdateStatus();
                }
                else
                {
                    throw new InvalidOperationException("Недостаточно средств на счете или сумма снятия неверна.");
                }
            }

            /// <summary>
            /// Метод для перевода средств на другой счет.
            /// </summary>
            /// <param name="targetAccount">Целевой банковский счет.</param>
            /// <param name="amount">Сумма для перевода.</param>
            public void Transfer(BankAccount targetAccount, decimal amount)
            {
                if (targetAccount == null)
                throw new ArgumentNullException(nameof(targetAccount));

                Withdraw(amount);
                targetAccount.Deposit(amount);
            }

            /// <summary>
            /// Метод для определения даты окончания вклада.
            /// </summary>
            /// <returns>Дата окончания вклада.</returns>
            public DateTime GetDepositEndDate()
            {
                return openingDate.AddDays(depositTerm);
            }

            /// <summary>
            /// Метод для обновления статуса счета.
            /// </summary>
            private void UpdateStatus()
            {
                if (balance <= 0)
                    status = "банкрот";
                else if (balance > 0 && depositTerm == 0)
                    status = "закрыт";
                else
                    status = "открыт";
            }
        }
    }
