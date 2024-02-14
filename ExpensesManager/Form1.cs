using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;


namespace ExpensesManager
{
    public partial class Form1 : Form
    {
        private List<ExpenseRecord> expenseRecords = new List<ExpenseRecord>();
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = @"C:\Users\Ельнур\Desktop\semester 3 assignments\ProgExam\invoice.txt"; // please chage for your path(link to txt)!!!
            Text = "ExpensesManager";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = textBox1.Text;
            if (File.Exists(filePath))
            {
                expenseRecords = ReadExpenseFile(filePath);
                DisplayExpenseRecords(expenseRecords);
            }
            else
            {
                MessageBox.Show($"File doesnt exist {filePath}", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (expenseRecords.Count > 0)
                DisplaySummary(expenseRecords);
            else
                MessageBox.Show("No data available", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private List<ExpenseRecord> ReadExpenseFile(string filePath)
        {
            List<ExpenseRecord> records = new List<ExpenseRecord>();
            try
            {
                foreach (string line in File.ReadLines(filePath).Skip(1))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3 && DateTime.TryParseExact(parts[0], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date) && decimal.TryParse(parts[1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal price))
                    {
                        records.Add(new ExpenseRecord { Date = date, Price = price, Category = parts[2] });
                    }
                    else
                    {
                        MessageBox.Show($"Invalid format in line: {line}!!!", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}!", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return records;
        }
        private void DisplayExpenseRecords(List<ExpenseRecord> records)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var record in records)
                sb.AppendLine($"{record.Date:yyyy-MM-dd} | {record.Price:C} | {record.Category}");

            textBox2.Text = sb.ToString();
        }
        private void DisplaySummary(List<ExpenseRecord> records)
        {
            decimal totalExpenses = records.Sum(record => record.Price);
            int numberOfCategories = records.Select(record => record.Category).Distinct().Count();
            int totalDatesOfPayments = records.Select(record => record.Date).Distinct().Count();

            StringBuilder summary = new StringBuilder();
            summary.AppendLine($"Total expenses: {totalExpenses:C}");
            summary.AppendLine($"Number of categories: {numberOfCategories}");
            summary.AppendLine($"Total dates of payments: {totalDatesOfPayments}");

            var categorySummary = records.GroupBy(record => record.Category).Select(group => new { Category = group.Key, TotalPurchases = group.Count(), PurchaseMonths = string.Join(", ", group.Select(record => record.Date.ToString("MMMM"))), TotalExpense = group.Sum(record => record.Price) });

            summary.AppendLine("Categories:");
            foreach (var category in categorySummary)
                summary.AppendLine($"    {category.Category} – bought {category.TotalPurchases} times in total. Purchases in: {category.PurchaseMonths}. Total expense: {category.TotalExpense:C}");

            textBox3.Text = summary.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class ExpenseRecord
    {
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}

