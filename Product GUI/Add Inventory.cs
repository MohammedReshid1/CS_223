﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApp.Model_Item;

namespace WinApp
{
    public partial class Add_Inventory : Form
    {

        public Add_Inventory(string user)
        {
            InitializeComponent();
            label7.Text = user;
        }

        private void Add_Inventory_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Item it = new Item();
            bool flag = false;
            //@ sign is used to skip escape character
            //$ sign indicates end of string 
            Regex regex = new Regex(@"^[a-z]{2}$");

            it.number = txt_number.Text;
            it.dates = dateTimePicker1.Value;
            it.inventory_number = txt_inventoryno.Text;
            it.object_name = txt_objectname.Text;
            it.count = txt_count.Text;
            it.price = txt_price.Text;
            it.isAvailable = checkBox1.Checked;

            //Checks if the Number entered has atleast 5 digits 
            if (txt_number.Text.Length < 5)
            {
                errorprovider.SetError(txt_number, "Digits must be 5");
            }
            //Checks if the Object name is given  
            else if (string.IsNullOrEmpty(txt_objectname.Text))
            {
                errorprovider.SetError(txt_objectname, "Object name is required");
            }
            //Checks if count is entered
            else if (txt_count.Text.Length < 1)
            {
                errorprovider.SetError(txt_count, "Count is required");
            }
            else
            {
                errorprovider.Clear();
                flag = true;
            }

            //Validate if Object name starts with characters 
            //if (!(regex.IsMatch(txt_objectname.Text)))
            //{ 
            //    MessageBox.Show("Object name must start with characters");
            //}


            if (flag)
            {
                MessageBox.Show(it.save() + " has been Successfully Added!!!");
                //Item.getAll();
                dgv.DataSource = null;
                dgv.DataSource = Item.getAll();
            }

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdbtn1.Checked)
                MessageBox.Show("Simple");
            else if (rdbtn2.Checked)
                MessageBox.Show("Variable");
            else
                Console.WriteLine(" ");

            string message = " ";
            foreach (var choice in chkList.CheckedItems)
            {
                message += choice.ToString() + " ";
            }
            MessageBox.Show(message);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void rdbtn2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_number_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
